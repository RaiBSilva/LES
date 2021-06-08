using LES.Controllers;
using LES.Controllers.Facade;
using LES.Data.DAO;
using LES.Models.Entity;
using LES.Models.Schedulers;
using LES.Models.ViewHelpers.CarrinhoCompra;
using LES.Models.ViewHelpers.Conta;
using LES.Models.ViewHelpers.Shared;
using LES.Models.ViewModel.Carrinho;
using LES.Models.ViewModel.Conta;
using LES.Models.ViewModel.Shared;
using LES.Views.Conta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LES.Views.CarrinhoCompra
{
    [Authorize]
    public class CarrinhoCompraController : BaseController
    {
        IDAOTabelaRel<CarrinhoLivro> _daoCarrinhoLivro { get; set; }
        IDAOTabelaRel<CartaoPedido> _daoCartaoPedido { get; set; }
        IFacadeCrud _facade { get; set; }

        public CarrinhoCompraController(
            IDAOTabelaRel<CarrinhoLivro> daoCarrinhoLivro,
            IDAOTabelaRel<CartaoPedido> daoCartaoPedido,
            IFacadeCrud facade)
        {
            _daoCarrinhoLivro = daoCarrinhoLivro;
            _daoCartaoPedido = daoCartaoPedido;
            _facade = facade;
        }

        public IActionResult FinalizarCompra() {

            Cliente c = GetClienteComEmail();
            Cliente clienteDb = _facade.GetAllInclude(c);
            Carrinho carrinho = clienteDb.Carrinho;

            if (carrinho == null || carrinho.CarrinhoLivro.Count == 0) 
            {
                TempData["Alert"] = "Você não possui livros no carrinho!";
                return RedirectToAction("Loja", "Livros");
            }

            Pedido pedNaoFinalizado = GetPedidoNaoFinalizado(clienteDb);
            bool naoTemPedido = pedNaoFinalizado == null;

            if(naoTemPedido)
            {
                pedNaoFinalizado = new Pedido();
                pedNaoFinalizado.CartaoPedidos = new List<CartaoPedido>
                {
                    new CartaoPedido
                    {
                        Cartao = clienteDb.Cartoes.Where(c => c.EFavorito && !c.Inativo).FirstOrDefault(),
                        Pedido = pedNaoFinalizado,
                        Valor = carrinho.PrecoTotal()
                    }
                };
                pedNaoFinalizado.Endereco = clienteDb.Enderecos
                    .Where(e => e.EFavorito && !e.Inativo).FirstOrDefault();
            }

            pedNaoFinalizado.Cliente = clienteDb;
            pedNaoFinalizado.DtCadastro = DateTime.Now;
            pedNaoFinalizado.Inativo = false;
            pedNaoFinalizado.LivrosPedidos = new List<LivroPedido>();
            foreach (var entry in carrinho.CarrinhoLivro)
                for(int i = 0; i < entry.Quantia; i++)
                    pedNaoFinalizado.LivrosPedidos.Add(new LivroPedido
                    {
                        Livro = entry.Livro,
                        Pedido = pedNaoFinalizado,
                        Trocado = false
                    });
            pedNaoFinalizado.Status = StatusPedidos.NaoFinalizado;

            if(naoTemPedido)
                clienteDb.Pedidos.Add(pedNaoFinalizado);
            _facade.Editar(clienteDb);

            //PREPARAÇÃO DO VIEWMODEL

            IDictionary<CartaoCredito, double> dicCartoes = new Dictionary<CartaoCredito, double>();
            foreach (var item in pedNaoFinalizado.CartaoPedidos)
                dicCartoes[item.Cartao] = item.Valor;

            IDictionary<string, object> entidades = new Dictionary<string, object>
            {
                [typeof(Endereco).Name] = pedNaoFinalizado.Endereco,
                [typeof(IDictionary<CartaoCredito, double>).Name] = dicCartoes,
                [typeof(Carrinho).Name] = carrinho
            };
            if (pedNaoFinalizado.Cupom != null)
                entidades[typeof(Cupom).Name] = pedNaoFinalizado.Cupom;

            _vh = new PaginaFinalizarCompraViewHelper
            {
                Entidades = entidades
            };

            ViewData["FinalizarCompra"] = true;
            if (!String.IsNullOrEmpty((string)TempData["Alert"])) ViewData["Alert"] = TempData["Alert"];

            return View(_vh.ViewModel); 
        }

        public IActionResult Comprar()
        {
            Cliente clienteDb = GetClienteDb();
            Pedido p = GetPedidoNaoFinalizado(clienteDb);
            Carrinho c = GetCarrinho();

            if (p == null)
            {
                TempData["Alert"] = "Ocorreu um erro. Tente novamente\n.";
                return RedirectToAction(nameof(FinalizarCompra));
            }

            IEnumerable<Livro> livros = p.LivrosPedidos.Select(l => l.Livro).Distinct();

            p.ValorTotal = p.CalcularValorTotal();

            if(p.Cupom != null || p.CodigoPromocional != null)
            {
                Cupom cupom = p.Cupom ?? new Cupom { Valor = 0 };
                CodigoPromocional codigo = p.CodigoPromocional ?? new CodigoPromocional { Valor = 0};

                if(cupom.Valor + codigo.Valor >= p.ValorTotal)
                {
                    foreach(var cupomCliente in clienteDb.Cupons)
                    {
                        if (cupomCliente.Valor + codigo.Valor < p.ValorTotal) 
                        {
                            TempData["Alert"] = "Você possui um cupom de troca que não ultrapassa o valor máximo. Use ele ao invés do atual!\n.";
                            return RedirectToAction(nameof(FinalizarCompra));
                        }
                    }
                    var diferenca = cupom.Valor + codigo.Valor - p.ValorTotal;
                    if(diferenca > 0)
                    {
                        addCupom(clienteDb, diferenca);
                    }
                }
            }

            //Cupom
            if (p.Cupom != null)
            { 
                p.Cupom.Inativo = true;
            }

            //Codigo
            if(p.CodigoPromocional != null)
            {
                p.CodigoPromocional.UsosRestantes -= 1;
                if(p.CodigoPromocional.UsosRestantes == 0)
                {
                    p.CodigoPromocional.Inativo = true;
                }
            }

            //Atualização estoque
            foreach (var livro in livros)
            {
                var quantiaPedido = p.LivrosPedidos.Where(l => l.LivroId == livro.Id).Count();
                livro.EstoqueBloqueado -= quantiaPedido;
                livro.Estoque -= quantiaPedido;

                //Inativação Automática de Livros fora de estoque
                if (livro.Estoque <= 0) 
                { 
                    livro.Inativo = true;
                    livro.Inativacoes.Add(new Inativacao { CategoriaId = 1, LivroId = livro.Id });
                }
            }

            p.Status = StatusPedidos.Processamento;
            string msg = _facade.Editar(p);

            //Limpar Carrinho (feito decrescente pois estou removendo da lista)
            msg += _facade.Deletar(c);

            if (msg != "")
                TempData["Alert"] = msg;
            return RedirectToAction("Loja", "Livros");
        }

        #region Selecionar Endereco e Cartao

        public IActionResult _SelecionarEndereco()
        {
            Cliente clienteDb = GetClienteDb();

            _vh = new SelecionarEnderecoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Endereco>).Name] = clienteDb.Enderecos
                }
            };

            SelecionarEnderecoModel vm = (SelecionarEnderecoModel)_vh.ViewModel;
            vm.TiposEnderecos = _facade.Listar<TipoEndereco>().OrderBy(t => t.Nome).ToList();
            vm.EnderecoId = GetPedidoNaoFinalizado(clienteDb).EnderecoId;

            return PartialView("../CarrinhoCompra/PartialViews/_SelecionarEndereçoPartial", vm);
        }

        [HttpPost]
        public IActionResult AlterarEndereco(SelecionarEnderecoModel vm)
        {
            _vh = new SelecionarEnderecoViewHelper
            {
                ViewModel = vm
            };

            int id = ((Endereco)_vh.Entidades[typeof(Endereco).Name]).Id;
            Cliente clienteDb = GetClienteDb();
            Endereco e = clienteDb.Enderecos.Where(e => e.Id == id).FirstOrDefault();
            Pedido p = GetPedidoNaoFinalizado(clienteDb);

            p.Endereco = e;
            string msg = _facade.Editar(p);

            if (msg != "")
                TempData["Alert"] = msg;
            return RedirectToAction(nameof(FinalizarCompra));
        }

        public IActionResult _SelecionarCartao()
        {
            Cliente clienteDb = GetClienteDb();
            Pedido p = GetPedidoNaoFinalizado(clienteDb);
            IList<CartaoPedido> cartaoPedido = p.CartaoPedidos;
            IList<CartaoCredito> cartoes = clienteDb.Cartoes;

            _vh = new SelecionarCartaoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    ["CartaoPedio"] = cartaoPedido,
                    [typeof(IList<CartaoCredito>).Name] = cartoes
                }
            };
            SelecionarCartaoModel vm = (SelecionarCartaoModel)_vh.ViewModel;
            vm.Bandeiras = _facade.Listar<BandeiraCartaoCredito>().OrderBy(b => b.Nome).ToList();
            vm.Vencimento = DateTime.Now;
            vm.ValorTotal = p.CalcularValorTotal();

            return PartialView("../CarrinhoCompra/PartialViews/_SelecionarCartaoPartial", _vh.ViewModel);
        }

        [HttpPost]
        public IActionResult AlterarPagamento(SelecionarCartaoModel vm)
        {
            _vh = new SelecionarCartaoViewHelper
            {
                ViewModel = vm
            };

            IList<CartaoPedido> cartaoPedidos = (IList<CartaoPedido>)_vh.Entidades[typeof(IList<CartaoPedido>).Name];

            Cliente clienteDb = GetClienteDb();
            Pedido pedido = GetPedidoNaoFinalizado(clienteDb);

            int lastIndex = pedido.CartaoPedidos.Count() - 1;

            for (int i = lastIndex; i >= 0; i--)
                _daoCartaoPedido.Remove(pedido.CartaoPedidos[i]);

            pedido.CartaoPedidos = new List<CartaoPedido>();

            for (int i = 0; i < cartaoPedidos.Count(); i++)
            {
                cartaoPedidos[i].Cartao = clienteDb.Cartoes.Where(c => c.Id == cartaoPedidos[i].CartaoId).FirstOrDefault();
                cartaoPedidos[i].Pedido = pedido;
                pedido.CartaoPedidos.Add(cartaoPedidos[i]);
            }

            string msg = _facade.Editar(pedido);

            if (msg != "")
                TempData["Alert"] = msg;
            return RedirectToAction(nameof(FinalizarCompra));
        }

        [HttpPost]
        public IActionResult AdicionarNovoEndereco(DetalhesEnderecoModel vm)
        {
            _vh = new DetalhesEnderecoViewHelper
            {
                ViewModel = vm
            };

            Endereco endereco = (Endereco)_vh.Entidades[typeof(Endereco).Name];
            endereco.TipoEndereco = _facade.GetEntidade(endereco.TipoEndereco);

            Cliente clienteDb = GetClienteDb();
            clienteDb.Enderecos.Add(endereco);

            string msg = _facade.Editar(clienteDb);

            if (msg != "")
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(FinalizarCompra));
        }

        [HttpPost]
        public IActionResult AdicionarNovoCartao(DetalhesCartaoModel vm)
        {
            _vh = new DetalhesCartaoViewHelper
            {
                ViewModel = vm
            };

            CartaoCredito cartao = (CartaoCredito)_vh.Entidades[typeof(CartaoCredito).Name];
            cartao.Bandeira = _facade.GetEntidade(cartao.Bandeira);

            Cliente clienteDb = GetClienteDb();
            clienteDb.Cartoes.Add(cartao);

            string msg = _facade.Editar(clienteDb);

            if (msg != "") 
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(FinalizarCompra));
        }

        #endregion

        #region Carrinho

        public IActionResult _CarrinhoPartial()
        {
            Carrinho c = GetCarrinho();

            if (c == null) return PartialView("_CarrinhoPartial", new CarrinhoModel());

            _vh = new CarrinhoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Carrinho).Name] = c
                }
            };

            return PartialView("_CarrinhoPartial", _vh.ViewModel);
        }

        [HttpPost]
        public IActionResult _AddToCarrinho(string codBar, int quantia = 1)
        {
            Carrinho c = GetCarrinho();
            Livro livro = _facade.GetAllInclude(new Livro { CodigoBarras = codBar});
            IEnumerable<CarrinhoLivro> carrinhoLivro = c.CarrinhoLivro.Where(c => c.LivroId == livro.Id);

            if (quantia > livro.Estoque - livro.EstoqueBloqueado)
            {
                return Json(new { valor = false, ex = "Estoque insuficiente.\n" });
            }

            if (carrinhoLivro.Count() == 0) 
            {
                CarrinhoLivro livroNovo = new CarrinhoLivro
                {
                    Livro = _facade.GetEntidade(livro),
                    Carrinho = c,
                    Quantia = quantia
                };

                c.CarrinhoLivro.Add(livroNovo);
            }
            else
            {
                carrinhoLivro.FirstOrDefault().Quantia+= 1;
            }

            livro.EstoqueBloqueado += quantia;

            string msg = _facade.Editar(c);
            msg += _facade.Editar(livro);

            //INSERIR MÉTODO DE DESATIVAÇÃO AUTOMÁTICA AQUI

            if (msg == "")
                return Json(new { valor = true });
            return Json(new { valor = false, ex = msg });
        }
        

        [HttpPost]
        public IActionResult _RemoverDoCarrinho(string codBar)
        {
            Carrinho c = GetCarrinho();
            Livro livro = _facade.Query<Livro>(l => l.CodigoBarras == codBar,
                l => l).FirstOrDefault();

            if (livro == null) 
            {
                return Json(new { valor = false, ex = "Algo deu errado.\n" });
            }

            CarrinhoLivro carrinhoLivro = c.CarrinhoLivro.Where(c => c.LivroId == livro.Id).FirstOrDefault();

            if (carrinhoLivro == null)
            {
                return Json(new { valor = false, ex = "O livro não está no carrinho.\n" });
            }

            livro.EstoqueBloqueado -= carrinhoLivro.Quantia;
            c.CarrinhoLivro.Remove(carrinhoLivro);

            string msg = _daoCarrinhoLivro.Remove(carrinhoLivro);
            msg += _facade.Editar(livro);

            if (msg == "")
                return Json(new { valor = true });
            return Json(new { valor = false, ex = msg });
        }
        public IActionResult _AlterarQuantiaNoCarrinho(string codBar, string op) 
        {
            Carrinho c = GetCarrinho();
            CarrinhoLivro carrinhoLivro = c.CarrinhoLivro.Where(l => l.Livro.CodigoBarras == codBar).FirstOrDefault();

            IDictionary<string, int> operacoes = new Dictionary<string, int>
            {
                ["+"] = 1,
                ["-"] = -1
            };

            if (carrinhoLivro == null)
                return Json(new { valor = false, ex = "Livro não está no carrinho.\n" });

            if (carrinhoLivro.Livro.EstoqueBloqueado == carrinhoLivro.Livro.Estoque && op == "+")
                return Json(new { valor = false, ex = "Estoque insuficiente.\n" });

            carrinhoLivro.Quantia += operacoes[op];
            carrinhoLivro.Livro.EstoqueBloqueado += operacoes[op];

            string msg = _facade.Editar(c);

            //INSERIR MÉTODO DE DESATIVAÇÃO AUTOMÁTICA AQUI

            if (msg == "")
                return Json(new { valor = true });
            return Json(new { valor = false, ex = msg });
        }

        [HttpPost]
        public IActionResult _MaisQuantiaNoCarrinho(string codBar)
        {
            return RedirectToAction(nameof(_AlterarQuantiaNoCarrinho), new { codBar, op = "+" });
        }
        [HttpPost]
        public IActionResult _MenosQuantiaNoCarrinho(string codBar)
        {
            return RedirectToAction(nameof(_AlterarQuantiaNoCarrinho), new { codBar, op = "-" });
        }
        #endregion

        #region Calcular Frete

        public IActionResult _CalcularFretePartial()
        {
            return PartialView("../CarrinhoCompra/PartialViews/_CalcularFretePartial");
        }

        #endregion

        #region Usar Cupom
        public IActionResult _UsarCupomPartial()
        {
            IList<Cupom> cupons = _facade.GetAllInclude(GetClienteComEmail()).Cupons
                .Where(c => c.Inativo == false)
                .OrderBy(c => c.Codigo)
                .ToList();

            _vh = new UsarCupomViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Cupom>).Name] = cupons
                }
            };


            return PartialView("../CarrinhoCompra/PartialViews/_UsarCupomPartial", _vh.ViewModel);
        }

        public IActionResult UsarCupom(string cod) 
        {
            Cliente clienteDb = GetClienteDb();
            Cupom cupom = clienteDb.Cupons.Where(c => c.Inativo == false && c.Codigo == cod).FirstOrDefault();
            Pedido pedido = GetPedidoNaoFinalizado(clienteDb);
            
            if(cupom == null)
                TempData["Alert"] = "Ocorreu um erro. Tente novamente. \n";
            else { 
                pedido.Cupom = cupom;
                _facade.Editar(clienteDb);
            }

            return RedirectToAction(nameof(FinalizarCompra));
        }

        public IActionResult RemoverCupom()
        {
            Cliente clienteDb = GetClienteDb();
            Pedido pedido = GetPedidoNaoFinalizado(clienteDb);

            pedido.CupomId = null;
            pedido.Cupom = null;
            _facade.Editar(clienteDb);
            return RedirectToAction(nameof(FinalizarCompra));
        }

        public IActionResult _UsarCodigoPromocional(string cod)
        {
            CodigoPromocional codigo = _facade.Query<CodigoPromocional>(c => c.Codigo == cod && !c.Inativo,
                c => c).FirstOrDefault();

            CodigoPromocionalModel vm = null;

            if (codigo == null)
                ViewData["Error"] = "O código não existe.";
            else
            {
                if(codigo.UsosRestantes <= 0)
                    ViewData["Error"] = "Esse código expirou. Tente outro código. \n";
                else
                {
                    _vh = new CodigoPromocionalViewHelper
                    {
                        Entidades = new Dictionary<string, object>
                        {
                            [typeof(CodigoPromocional).Name] = codigo
                        }
                    };
                    vm = (CodigoPromocionalModel)_vh.ViewModel;
                }
            }

            return PartialView("../CarrinhoCompra/PartialViews/_UsarCodigoPartial", vm);
        }

        public IActionResult UsarCodigo(string cod)
        {
            Cliente clienteDb = GetClienteDb();
            Pedido pedido = GetPedidoNaoFinalizado(clienteDb);
            CodigoPromocional codigo = _facade.Query<CodigoPromocional>(c => c.Codigo == cod && !c.Inativo,
                c => c).FirstOrDefault();
            string msg = "";

            if(codigo == null)
            {
                TempData["Alert"] = "Código inválido. \n";
            }
            else { 

                if (codigo.UsosRestantes <= 0)
                    TempData["Alert"] = "Esse código expirou. Tente outro código. \n";
                else
                {
                    pedido.CodigoPromocional = codigo;
                    msg = _facade.Editar(pedido);
                }

            }

            if (msg != "")
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(FinalizarCompra));
        }

        public IActionResult RemoverCodigo()
        {
            Cliente clienteDb = GetClienteDb();
            Pedido pedido = GetPedidoNaoFinalizado(clienteDb);

            pedido.CodigoPromocional = null;
            pedido.CodigoId = null;
            string msg = _facade.Editar(clienteDb);
            return RedirectToAction(nameof(FinalizarCompra));
        }

        #endregion

        #region Troca

        public IActionResult _RealizarTrocaPartial(int id)
        {
            LivroPedido p = _facade.Query<LivroPedido>(p => p.Id == id, p => p, p=>p.Livro).FirstOrDefault();
            Livro l = _facade.GetAllInclude(p.Livro);

            if (p.Trocado) 
            {
                ViewData["ErrorMessage"] = "Esse livro tem uma troca ativa associada.";
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }

            _vh = new LivroBaseViewHelper { Entidades = new Dictionary<string, object>{ [typeof(Livro).Name] = l } };
            KeyValuePair<int, LivroBaseModel> vm = new KeyValuePair<int, LivroBaseModel>(p.Id, (LivroBaseModel)_vh.ViewModel);

            return PartialView("../Conta/PartialViews/_RealizarTrocaPartial", vm);
        }

        public IActionResult RealizarTroca(int id)
        {
            LivroPedido p = _facade.Query<LivroPedido>(p => p.Id == id,
                p => p).FirstOrDefault();
            p.Trocado = true;

            Troca t = new Troca
            {
                Cliente = _facade.GetAllInclude(GetClienteComEmail()),
                LivroPedido = p,
                StatusTroca = StatusTroca.Processamento
            };

            string msg = _facade.Editar(p);
            msg += _facade.Cadastrar(t);

            if (msg != "")
                TempData["Alert"] = msg;
            return RedirectToAction("Detalhes","Conta");
        }

        public IActionResult CancelarTroca(int id)
        {
            Troca t = _facade.GetAllInclude(new Troca { Id = id });
            LivroPedido p = _facade.Query<LivroPedido>(p => t.LivroPedidoId == p.Id,
                p => p).FirstOrDefault();

            t.StatusTroca = StatusTroca.Cancelada;
            p.Trocado = false;

            string msg = _facade.Editar(t);
            msg += _facade.Editar(p);

            if (msg != "")
                TempData["Alert"] = msg;
            return RedirectToAction("Detalhes", "Conta");
        }

        #endregion

        #region Utilidades
        public void addCupom(Cliente c, double valor)
        {
            Cupom cupom = new Cupom { Cliente = c, Valor = valor };

            Random rnd = new Random();

            while (true)
            {
                int codigo = rnd.Next(0, 1000000);
                var items = _facade.Query<Cupom>(
                    c => Convert.ToInt32(c.Codigo) == codigo,
                    c => c);

                if (items.Count() == 0)
                {
                    cupom.Codigo = codigo.ToString("D7");
                    break;
                }
                codigo = rnd.Next(0, 1000000); ;
            }

            c.Cupons.Add(cupom);
        }

        public static Dictionary<string, string> GetFretePrazo(Pedido pedido)
        {
            double peso = pedido.LivrosPedidos.FirstOrDefault().Livro.Peso;
            double comprimento = pedido.LivrosPedidos.FirstOrDefault().Livro.Comprimento;
            double altura = pedido.LivrosPedidos.FirstOrDefault().Livro.Altura;
            double largura = pedido.LivrosPedidos.FirstOrDefault().Livro.Largura;

            // VALIDAÇÃO DE PESO MÍNIMO
            if (peso < 1) peso = 1;

            // VALIDAÇÃO DE COMPRIMENTO MÁXIMO E MÍNIMO
            if (comprimento < 15)
            {
                comprimento = 15;
            }else if (comprimento > 100)
            {
                comprimento = 100;
            }

            // VALIDAÇÃO DE ALTURA MÁXIMA E MÍNIMA
            if (altura < 1)
            {
                altura = 1;
            }else if (altura > 100)
            {
                altura = 100;
            }

            // VALIDAÇÃO DE LARGURA MÁXIMA E MÍNIMA
            if (largura < 10)
            {
                largura = 10;
            }
            else if (largura > 100)
            {
                largura = 100;
            }


            StringBuilder sb = new StringBuilder("http://ws.correios.com.br/calculador/CalcPrecoPrazo.aspx?");
            sb.Append("nCdEmpresa=");
            sb.Append("&sDsSenha=");
            sb.Append("&nCdServico=04014");
            sb.Append("&sCepOrigem=08773600");
            sb.Append(String.Format("&sCepDestino={0}", pedido.Endereco.Cep));
            sb.Append(String.Format("&nVlPeso={0}", peso));
            sb.Append("&nCdFormato=1");
            sb.Append(String.Format("&nVlComprimento={0}", comprimento));
            sb.Append(String.Format("&nVlAltura={0}", altura));
            sb.Append(String.Format("&nVlLargura={0}", largura));
            sb.Append("&nVlDiametro=1");
            sb.Append("&sCdMaoPropria=N");
            sb.Append("&nVlValorDeclarado=0");
            sb.Append("&sCdAvisoRecebimento=N");
            sb.Append("&StrRetorno=xml");
            sb.Append("&nIndicaCalculo=3");

            XmlDocument myXml = new XmlDocument();
            myXml.Load(sb.ToString());

            XmlNodeList frete = myXml.GetElementsByTagName("Valor");
            XmlNodeList prazo = myXml.GetElementsByTagName("PrazoEntrega");

            Dictionary<string, string> parametros = new Dictionary<string, string>();

            parametros.Add("Frete", frete.Item(0).InnerText);
            parametros.Add("Prazo", prazo.Item(0).InnerText);

            return parametros;
        }

        private Cliente GetClienteDb() 
        {
            return _facade.GetAllInclude(GetClienteComEmail());
        }

        private Carrinho GetCarrinho()
        {
            Cliente clienteCookie = GetClienteComEmail();
            Carrinho c = _facade.GetAllInclude(new Carrinho { Cliente = clienteCookie });

            if (c != null)
                return c;

            c = new Carrinho();
            Cliente clienteDb = GetClienteDb();
            clienteDb.Carrinho = c;
            _facade.Editar(clienteDb);

            c = _facade.GetAllInclude(clienteDb).Carrinho;
            return c;
        }

        private Pedido GetPedidoNaoFinalizado(Cliente c)
        {
            return c.Pedidos.Where(p => p.Status == StatusPedidos.NaoFinalizado).FirstOrDefault();
        }

        #endregion

    }
}
