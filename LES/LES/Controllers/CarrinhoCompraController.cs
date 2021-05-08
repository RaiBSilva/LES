﻿using LES.Controllers;
using LES.Controllers.Facade;
using LES.Data.DAO;
using LES.Models.Entity;
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
using System.Threading.Tasks;

namespace LES.Views.CarrinhoCompra
{
    [Authorize]
    public class CarrinhoCompraController : BaseController
    {
        IDAOTabelaRel<CarrinhoLivro> _daoCarrinhoLivro { get; set; }
        IDAOTabelaRel<CartaoPedido> _daoCartaoPedido { get; set; }
        IFacadeCrud<BandeiraCartaoCredito> _facadeBandeiras { get; set; }
        IFacadeCrud<Carrinho> _facadeCarrinho { get; set; }
        IFacadeCrud<Cliente> _facadeCliente { get; set; }
        IFacadeCrud<Livro> _facadeLivro { get; set; }
        IFacadeCrud<LivroPedido> _facadeLivrosPedidos { get; set; }
        IFacadeCrud<Pedido> _facadePedido { get; set; }
        IFacadeCrud<TipoEndereco> _facadeTipoEndereco { get; set; }
        IFacadeCrud<Troca> _facadeTroca { get; set; }

        public CarrinhoCompraController(
            IDAOTabelaRel<CarrinhoLivro> daoCarrinhoLivro,
            IDAOTabelaRel<CartaoPedido> daoCartaoPedido,
            IFacadeCrud<BandeiraCartaoCredito> facadeBandeira, 
            IFacadeCrud<Carrinho> facadeCarrinho,
            IFacadeCrud<Cliente> facadeCliente,
            IFacadeCrud<Livro> facadeLivro,
            IFacadeCrud<LivroPedido> facadeLivrosPedidos,
            IFacadeCrud<Pedido> facadePedido,
            IFacadeCrud<TipoEndereco> facadeTipoEndereco,
            IFacadeCrud<Troca> facadeTroca)
        {
            _facadeBandeiras = facadeBandeira;
            _facadeCarrinho = facadeCarrinho;
            _facadeCliente = facadeCliente;
            _facadeLivro = facadeLivro;
            _facadePedido = facadePedido;
            _facadeTipoEndereco = facadeTipoEndereco;
            _daoCarrinhoLivro = daoCarrinhoLivro;
            _daoCartaoPedido = daoCartaoPedido;
            _facadeLivrosPedidos = facadeLivrosPedidos;
            _facadeTroca = facadeTroca;
        }

        public IActionResult FinalizarCompra() {

            Cliente c = GetClienteComEmail();
            Cliente clienteDb = _facadeCliente.GetAllInclude(c);
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
            _facadeCliente.Editar(clienteDb);

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
            if (TempData["Alert"] != null) ViewData["Alert"] = TempData["Alert"];

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

            //Limpar Carrinho (feito decrescente pois estou removendo da lista)
            int lastIndex = c.CarrinhoLivro.Count() - 1;

            for (int i = lastIndex; i >= 0; i--)
                _daoCarrinhoLivro.Remove(c.CarrinhoLivro[i]);

            IEnumerable<Livro> livros = p.LivrosPedidos.Select(l => l.Livro).Distinct();

            p.ValorTotal = p.CalcularValorTotal();

            //Cupom
            if (p.Cupom != null)
                p.ValorTotal -= p.Cupom.Valor;

            //Atualização estoque
            foreach(var livro in livros)
            {
                var quantiaPedido = p.LivrosPedidos.Where(l => l.LivroId == livro.Id).Count();
                livro.EstoqueBloqueado -= quantiaPedido;
                livro.Estoque -= quantiaPedido;
            }

            p.Status = StatusPedidos.Processamento;
            string msg = _facadePedido.Editar(p);

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
            vm.TiposEnderecos = _facadeTipoEndereco.Listar().OrderBy(t => t.Nome).ToList();
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
            string msg = _facadePedido.Editar(p);

            if (msg != "")
                TempData["Alert"] = msg;
            return RedirectToAction(nameof(FinalizarCompra));
        }

        public IActionResult _SelecionarCartao()
        {
            Cliente clienteDb = GetClienteDb();
            IList<CartaoPedido> cartaoPedido = GetPedidoNaoFinalizado(clienteDb).CartaoPedidos;
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
            vm.Bandeiras = _facadeBandeiras.Listar().OrderBy(b => b.Nome).ToList();
            vm.Vencimento = DateTime.Now;
            vm.ValorTotal = GetCarrinho().PrecoTotal();

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

            string msg = _facadePedido.Editar(pedido);

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
            endereco.TipoEndereco = _facadeTipoEndereco.GetEntidade(endereco.TipoEndereco);

            Cliente clienteDb = GetClienteDb();
            clienteDb.Enderecos.Add(endereco);

            string msg = _facadeCliente.Editar(clienteDb);

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
            cartao.Bandeira = _facadeBandeiras.GetEntidade(cartao.Bandeira);

            Cliente clienteDb = GetClienteDb();
            clienteDb.Cartoes.Add(cartao);

            string msg = _facadeCliente.Editar(clienteDb);

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
            Livro livro = _facadeLivro.GetAllInclude(new Livro { CodigoBarras = codBar});
            IEnumerable<CarrinhoLivro> carrinhoLivro = c.CarrinhoLivro.Where(c => c.LivroId == livro.Id);

            if (quantia > livro.Estoque - livro.EstoqueBloqueado)
            {
                return Json(new { valor = false, ex = "Estoque insuficiente.\n" });
            }

            if (carrinhoLivro.Count() == 0) 
            {
                CarrinhoLivro livroNovo = new CarrinhoLivro
                {
                    Livro = _facadeLivro.GetEntidade(livro),
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

            string msg = _facadeCarrinho.Editar(c);
            msg += _facadeLivro.Editar(livro);

            //INSERIR MÉTODO DE DESATIVAÇÃO AUTOMÁTICA AQUI

            if(msg == "")
                return Json(new { valor = true });
            return Json(new { valor = false, ex = msg });
        }
        

        [HttpPost]
        public IActionResult _RemoverDoCarrinho(string codBar)
        {
            Carrinho c = GetCarrinho();
            Livro livro = _facadeLivro.Query(l => l.CodigoBarras == codBar,
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
            msg += _facadeLivro.Editar(livro);

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

            string msg = _facadeCarrinho.Editar(c);

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
            IList<Cupom> cupons = _facadeCliente.GetAllInclude(GetClienteComEmail()).Cupons
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
                _facadeCliente.Editar(clienteDb);
            }

            return RedirectToAction(nameof(FinalizarCompra));
        }

        public IActionResult RemoverCupom()
        {
            Cliente clienteDb = GetClienteDb();
            Pedido pedido = GetPedidoNaoFinalizado(clienteDb);

            pedido.CupomId = null;
            pedido.Cupom = null;
            _facadeCliente.Editar(clienteDb);
            return RedirectToAction(nameof(FinalizarCompra));
        }
        #endregion

        #region Troca

        public IActionResult _RealizarTrocaPartial(int id)
        {
            LivroPedido p = _facadeLivrosPedidos.GetEntidade(new LivroPedido { Id = id });
            Livro l = _facadeLivro.GetAllInclude(p.Livro);

            _vh = new LivroBaseViewHelper { Entidades = new Dictionary<string, object>{ [typeof(Livro).Name] = l } };
            KeyValuePair<int, LivroBaseModel> vm = new KeyValuePair<int, LivroBaseModel>(p.Id, (LivroBaseModel)_vh.ViewModel);

            return PartialView("../Conta/PartialViews/_RealizarTrocaPartial", vm);
        }

        public IActionResult RealizarTroca(int id)
        {
            LivroPedido p = _facadeLivrosPedidos.GetEntidade(new LivroPedido { Id = id });
            p.Trocado = true;

            Troca t = new Troca
            {
                Cliente = _facadeCliente.GetAllInclude(GetClienteComEmail()),
                LivroPedido = p,
                StatusTroca = StatusTroca.Processamento
            };

            string msg = _facadeLivrosPedidos.Editar(p);
            msg += _facadeTroca.Cadastrar(t);

            if (msg != null)
                TempData["Alert"] = msg;
            return RedirectToAction("Detalhes","Conta");
        }

        public IActionResult CancelarTroca(int id)
        {
            Troca t = _facadeTroca.GetAllInclude(new Troca { Id = id });

            t.StatusTroca = StatusTroca.Cancelada;

            string msg = _facadeTroca.Editar(t);

            if (msg != null)
                TempData["Alert"] = msg;
            return RedirectToAction("Detalhes", "Conta");
        }

        #endregion

        #region Utilidades

        private Cliente GetClienteDb() 
        {
            return _facadeCliente.GetAllInclude(GetClienteComEmail());
        }

        private Carrinho GetCarrinho()
        {
            return _facadeCarrinho.GetAllInclude(new Carrinho { Cliente = GetClienteComEmail() });

        }

        private Pedido GetPedidoNaoFinalizado(Cliente c)
        {
            return c.Pedidos.Where(p => p.Status == StatusPedidos.NaoFinalizado).FirstOrDefault();
        }

        #endregion

    }
}
