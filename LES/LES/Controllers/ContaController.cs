using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Security.Cryptography;
using LES.Controllers;
using LES.Controllers.Facade;
using LES.Models.Entity;
using LES.Models.ViewHelpers.Conta;
using LES.Models.ViewModel;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LES.Views.Conta
{
    public class ContaController : BaseController
    {
        private IFacadeCrud _facade { get; set; }

        public ContaController(IFacadeCrud facade)
        {
            _facade = facade;
        }

        #region Login, Registro, Logout e Detalhes
        //GET /Conta/Login
        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Login(PaginaLoginModel usuario)
        {
            if (String.IsNullOrEmpty(usuario.Senha) || String.IsNullOrEmpty(usuario.Username))
            {
                ViewData["Alert"] = "Username e/ou senha incorreta.";
                return View(new PaginaLoginModel { Falhou = true });
            }

            _vh = new PaginaLoginViewHelper
            {
                ViewModel = usuario
            };

            Cliente clienteLogin = new Cliente
            {
                Usuario = (Usuario)_vh.Entidades[typeof(Usuario).Name]
            };

            Cliente clienteDb = _facade.Query<Cliente>(
                c => c.Usuario.Email == clienteLogin.Usuario.Email, 
                c => c,
                c => c.Usuario).FirstOrDefault();

            if (clienteDb != null) {  
                if (GerenciadorLogin.comparaSenha(usuario.Senha, clienteDb.Usuario.Senha)) 
                {
                    HttpContext.SignInAsync(GerenciadorLogin.FazerLogin(clienteDb));

                    if(HttpContext.User.IsInRole("1") || HttpContext.User.IsInRole("2"))
                        return RedirectToAction("Home", "Admin");
                    return RedirectToAction("Index", "Home");
                }
                ViewData["Alert"] = "Senha incorreta.";
                return View(new PaginaLoginModel
                {
                    Username = clienteLogin.Usuario.Email,
                    Falhou = true
                });
            }
            ViewData["Alert"] = "Username e/ou senha incorreta.";
            return View(new PaginaLoginModel { Falhou = true});
        }

        //GET /Conta/Registro
        public IActionResult Registro() 
        {

            PaginaRegistroModel vm = new PaginaRegistroModel()
            {
                InfoUsuario = new InfoBaseModel
                {
                    DtNascimento = DateTime.Now
                },
                Cartao = new CartaoBaseModel
                {
                    Bandeiras = GetBandeiras(),
                    Vencimento = DateTime.Now
                },
                Telefone = new TelefoneBaseModel
                {
                    TipoTelefones = GetTipoTelefones()
                },
                Endereco = new EnderecoBaseModel 
                { 
                    TiposEnderecos = GetTipoEnderecos() 
                }
            };

            if (TempData["Alert"] != null) ViewData["Alert"] = TempData["Alert"];

            return View(vm);
        }

        //POST
        [HttpPost]
        public IActionResult Registro(PaginaRegistroModel usuarioNovo)
        {
            _vh = new PaginaRegistroViewHelper
            {
                ViewModel = usuarioNovo
            };

            Cliente cliente = (Cliente)_vh.Entidades[typeof(Cliente).Name];
            cliente.Cartoes[0].Bandeira = _facade.GetEntidade(cliente.Cartoes[0].Bandeira);
            cliente.Enderecos[0].TipoEndereco = _facade.GetEntidade(cliente.Enderecos[0].TipoEndereco);
            cliente.Telefones[0].TipoTelefone = _facade.GetEntidade(cliente.Telefones[0].TipoTelefone);
            cliente.Codigo = GeraCodigoCliente();
            cliente.Carrinho = new Carrinho();

            string msg = _facade.Cadastrar(cliente);

            if (msg == "")  return RedirectToAction(nameof(Login));
            TempData["Alert"] = msg;
            return RedirectToAction(nameof(Registro));
        }

        [Authorize]
        //Get /Conta/Detalhes
        public IActionResult Detalhes() 
        {
            Cliente cliente = GetClienteComEmail();

            var clienteDb = _facade.GetAllInclude(cliente);

            clienteDb.Cartoes = clienteDb.Cartoes.Where(c => c.Inativo == false).ToList();
            clienteDb.Enderecos = clienteDb.Enderecos.Where(e => e.Inativo == false).ToList();
            clienteDb.Telefones = clienteDb.Telefones.Where(c => c.Inativo == false).ToList();

            IDictionary<string, object> e = new Dictionary<string, object>
            {
                [typeof(Cliente).Name] = clienteDb
            };

            _vh = new PaginaDetalhesViewHelper
            {
                Entidades = e
            };

            if (TempData["Alert"] != null) ViewData["Alert"] = TempData["Alert"];

            return View(_vh.ViewModel);
        }

        //GET /Conta/Logout
        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        #endregion

        #region Editar

        //GET Conta/_EditarInfoPessoalPartial
        public IActionResult _EditarInfoPessoalPartial(int id)
        {
            Cliente cliente = _facade.Query<Cliente>(c => c.Codigo == id.ToString(),
                c => c,
                c => c.Usuario).FirstOrDefault();

            if(cliente == null)
            {
                return  PartialView("../Conta/PartialViews/_ErroPartial"); 
            }

            IDictionary<string, object> entidades = new Dictionary<string, object>
            {
                [typeof(Cliente).Name] = cliente
            };

            _vh = new DetalhesInfoViewHelper
            {
                Entidades = entidades
            };

            return PartialView("../Conta/PartialViews/_EditarInfoPartial", _vh.ViewModel);
        }

        //POST
        [HttpPost]
        public IActionResult EditarInfo(InfoBaseModel info)
        {
            _vh = new InfoBaseModelViewHelper
            {
                ViewModel = info
            };

            Cliente clienteRequest = (Cliente)_vh.Entidades[typeof(Cliente).Name];

            Cliente clienteDb = _facade.Query<Cliente>(c => c.Codigo == clienteRequest.Codigo,
                c => c,
                c => c.Usuario).FirstOrDefault();

            clienteDb.Cpf = clienteRequest.Cpf;
            clienteDb.DtNascimento = clienteRequest.DtNascimento;
            clienteDb.Genero = clienteRequest.Genero;
            clienteDb.Nome = clienteRequest.Nome;
            clienteDb.Usuario.Email = clienteRequest.Usuario.Email;

            string msg = _facade.Editar(clienteDb);

            if(msg == "") return RedirectToAction(nameof(Detalhes));
            TempData["Alert"] = msg;
            return RedirectToAction("Registro");

        }

        //GET Conta/_EditarSenhaPartial
        public IActionResult _EditarSenhaPartial(int id) 
        {
            string codigo = _facade.Query<Cliente>(c => c.Codigo == id.ToString(),
                c => c,
                c => c.Usuario).FirstOrDefault().Codigo;

            if (codigo == null)
            {
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }

            AlterarSenhaModel vm = new AlterarSenhaModel 
            {
                Codigo = codigo
            };

            return PartialView("../Conta/PartialViews/_EditarSenhaPartial", vm);
        }

        //POST
        [HttpPost]
        public IActionResult EditarSenha(AlterarSenhaModel senhaModel)
        {

            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            Cliente clienteDb = _facade.Query<Cliente>(c => c.Usuario.Email == email,
                c => c,
                c => c.Usuario).FirstOrDefault();

            _vh = new AlterarSenhaViewHelper
            {
                ViewModel = senhaModel
            };

            Cliente clienteSenhaNova = (Cliente)_vh.Entidades[typeof(Cliente).Name];
            Cliente clienteSenhaVelha = (Cliente)_vh.Entidades[$"{typeof(Cliente).Name}Antigo"];

            string senhaNova = clienteSenhaNova.Usuario.Senha;
            string senhaVelha = clienteSenhaVelha.Usuario.Senha;

            if(GerenciadorLogin.comparaSenha(senhaVelha, clienteDb.Usuario.Senha)) 
            {
                clienteDb.Usuario.Senha = senhaNova;
                string msg = _facade.Editar(clienteDb);
                if (msg == "") return RedirectToAction(nameof(Detalhes));
                TempData["Alert"] = msg;
            }

            return RedirectToAction(nameof(Detalhes));
        }


        //GET Conta/_EditarEnderecoPartial
        public IActionResult _EditarEnderecoPartial(int id)
        {
            DetalhesEnderecoModel vm = (DetalhesEnderecoModel)GetEnderecoVm(id);
            if (vm == null)
            {
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }
            vm.TiposEnderecos = GetTipoEnderecos();
            vm.Edicao = true;

            return PartialView("../Conta/PartialViews/_EditarEnderecoPartial", vm);
        }

        //POST
        [HttpPost]
        public IActionResult EditarEndereco(DetalhesEnderecoModel endereco)
        {
            _vh = new DetalhesEnderecoViewHelper
            {
                ViewModel = endereco
            };

            Endereco endNovo = (Endereco)_vh.Entidades[typeof(Endereco).Name];

            Cliente c = _facade.GetAllInclude(GetClienteComEmail());

            var endDb = c.Enderecos.Where(e => e.Id == endNovo.Id).FirstOrDefault();

            endDb.Cep = endNovo.Cep;
            endDb.Cidade = endNovo.Cidade;
            endDb.Complemento = endNovo.Complemento;
            endDb.ECobranca = endNovo.ECobranca;
            endDb.EEntrega = endNovo.EEntrega;
            endDb.EFavorito = endNovo.EFavorito;
            endDb.EResidencia = endNovo.EResidencia;
            endDb.Logradouro = endNovo.Logradouro;
            endDb.NomeEndereco = endNovo.NomeEndereco;
            endDb.Numero = endNovo.Numero;
            endDb.Observacoes = endNovo.Observacoes;
            endDb.TipoEndereco = _facade.GetEntidade(endNovo.TipoEndereco);

            string msg = _facade.Editar(c);

            if (msg != "")
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(Detalhes));
        }

        //GET Conta/_EditarTelefonePartial
        public IActionResult _EditarTelefonePartial(int id)
        {
            DetalhesTelefoneModel vm = (DetalhesTelefoneModel)GetTelefoneVm(id);
            if(vm == null) 
            {
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }
            vm.TipoTelefones = GetTipoTelefones();
            vm.Edicao = true;

            return PartialView("../Conta/PartialViews/_EditarTelefonePartial", vm);
        }

        //POST
        [HttpPost]
        public IActionResult EditarTelefone(DetalhesTelefoneModel telefone)
        {
            _vh = new DetalhesTelefoneViewHelper
            {
                ViewModel = telefone
            };

            Telefone telNovo = (Telefone)_vh.Entidades[typeof(Telefone).Name];

            Cliente c = _facade.GetAllInclude(GetClienteComEmail());

            var telDb = c.Telefones.Where(t => t.Id == telNovo.Id).FirstOrDefault();

            telDb.Ddd = telNovo.Ddd;
            telDb.EFavorito = telNovo.EFavorito;
            telDb.Numero = telNovo.Numero;
            telDb.TipoTelefone = _facade.GetEntidade(telNovo.TipoTelefone);

            string msg = _facade.Editar(c);

            if (msg != "")
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(Detalhes));
        }

        //GET Conta/_EditarCartaoPartial
        public IActionResult _EditarCartaoPartial(int id)
        {
            DetalhesCartaoModel vm = (DetalhesCartaoModel)GetCartaoVm(id);
            if (vm == null)
            {
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }
            vm.Bandeiras = GetBandeiras();
            vm.Edicao = true;

            return PartialView("../Conta/PartialViews/_EditarCartaoPartial", vm);
        }

        //POST
        [HttpPost]
        public IActionResult EditarCartao(DetalhesCartaoModel cartao)
        {
            _vh = new DetalhesCartaoViewHelper
            {
                ViewModel = cartao
            };

            CartaoCredito carNovo = (CartaoCredito)_vh.Entidades[typeof(CartaoCredito).Name];

            Cliente c = _facade.GetAllInclude(GetClienteComEmail());

            var carDb = c.Cartoes.Where(t => t.Id == carNovo.Id).FirstOrDefault();

            carDb.Bandeira = _facade.GetEntidade(carNovo.Bandeira);
            carDb.Codigo = carNovo.Codigo;
            carDb.Cvv = carNovo.Cvv;
            carDb.EFavorito = carNovo.EFavorito;
            carDb.NomeImpresso = carNovo.NomeImpresso;
            carDb.Vencimento = carNovo.Vencimento;

            string msg = _facade.Editar(c);

            if (msg != "")
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(Detalhes));
        }

        #endregion

        #region Adicionar
        public IActionResult _AdicionarNovoEnderecoPartial() 
        {
            IList<Endereco> enderecos = _facade.Query<Cliente>(
                c => c.Usuario.Email == GetClienteComEmail().Usuario.Email,
                c => c).FirstOrDefault().Enderecos;

            enderecos = enderecos.Where(e => e.Inativo == false).ToList();

            if (enderecos.Count >= 4) 
            {
                ViewData["ErrorMessage"] = "Você já possui o máximo de endereços possível.";
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }

            DetalhesEnderecoModel vm = new DetalhesEnderecoModel
            {
                TiposEnderecos = GetTipoEnderecos()
            };

            return PartialView("../Conta/PartialViews/_AdicionarNovoEnderecoPartial", vm);
        }

        [HttpPost]
        public IActionResult AdicionarNovoEndereco(DetalhesEnderecoModel novoEndereco) 
        {
            _vh = new DetalhesEnderecoViewHelper
            {
                ViewModel = novoEndereco
            };

            Endereco endereco = (Endereco)_vh.Entidades[typeof(Endereco).Name];
            endereco.TipoEndereco = _facade.GetEntidade(endereco.TipoEndereco);

            Cliente clienteDb = _facade.GetAllInclude(GetClienteComEmail());
            clienteDb.Enderecos.Add(endereco);

            string msg = _facade.Editar(clienteDb);

            if (msg == "") return RedirectToAction(nameof(Detalhes));
            TempData["Alert"] = msg;

            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _AdicionarNovoTelefonePartial()
        {
            IList<Telefone> telefones = _facade.Query<Cliente>(
                   c => c.Usuario.Email == GetClienteComEmail().Usuario.Email,
                   c => c).FirstOrDefault().Telefones;

            telefones = telefones.Where(e => e.Inativo == false).ToList();

            if (telefones.Count >= 4)
            {
                ViewData["ErrorMessage"] = "Você já possui o máximo de telefones possível.";
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }

            DetalhesTelefoneModel vm = new DetalhesTelefoneModel
            {
                TipoTelefones = GetTipoTelefones()
            };

            return PartialView("../Conta/PartialViews/_AdicionarNovoTelefonePartial", vm);
        }

        [HttpPost]
        public IActionResult AdicionarNovoTelefone(DetalhesTelefoneModel novoTelefone)
        {
            _vh = new DetalhesTelefoneViewHelper
            {
                ViewModel = novoTelefone
            };

            Telefone telefone = (Telefone)_vh.Entidades[typeof(Telefone).Name];
            telefone.TipoTelefone = _facade.GetEntidade(telefone.TipoTelefone);

            Cliente clienteDb = _facade.GetAllInclude(GetClienteComEmail());
            clienteDb.Telefones.Add(telefone);

            string msg = _facade.Editar(clienteDb);

            if (msg == "") return RedirectToAction(nameof(Detalhes));
            TempData["Alert"] = msg;

            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _AdicionarNovoCartaoPartial()
        {
            IList<CartaoCredito> cartoes = _facade.Query<Cliente>(
                   c => c.Usuario.Email == GetClienteComEmail().Usuario.Email,
                   c => c).FirstOrDefault().Cartoes;

            cartoes = cartoes.Where(e => e.Inativo == false).ToList();

            if (cartoes.Count >= 4)
            {
                ViewData["ErrorMessage"] = "Você já possui o máximo de cartões possível.";
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }

            DetalhesCartaoModel vm = new DetalhesCartaoModel
            {
                Bandeiras = GetBandeiras()
            };

            return PartialView("../Conta/PartialViews/_AdicionarNovoCartaoPartial", vm);
        }

        [HttpPost]
        public IActionResult AdicionarNovoCartao(DetalhesCartaoModel novoCartao)
        {
            _vh = new DetalhesCartaoViewHelper
            {
                ViewModel = novoCartao
            };

            CartaoCredito cartao = (CartaoCredito)_vh.Entidades[typeof(Telefone).Name];
            cartao.Bandeira = _facade.GetEntidade(cartao.Bandeira);

            Cliente clienteDb = _facade.GetAllInclude(GetClienteComEmail());
            clienteDb.Cartoes.Add(cartao);

            string msg = _facade.Editar(clienteDb);

            if (msg == "") return RedirectToAction(nameof(Detalhes));
            TempData["Alert"] = msg;

            return RedirectToAction(nameof(Detalhes));
        }

        #endregion

        #region Remover e Favoritar

        public IActionResult _RemoverEnderecoPartial(int id)
        {
            DetalhesEnderecoModel vm = (DetalhesEnderecoModel)GetEnderecoVm(id);
            if (vm == null)
            {
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }
            ViewData["Acao"] = "Remover";

            return PartialView("../Conta/PartialViews/_RmvFavEnderecoPartial", vm);
        }

        public IActionResult RemoverEndereco(int id)
        {
            Cliente clienteDb = _facade.GetAllInclude(GetClienteComEmail());

            IList<Endereco> enderecos = clienteDb.Enderecos.Where(e => e.Inativo == false).ToList();

            Endereco enderecoRem = enderecos.Where(e => e.Id == id).FirstOrDefault();
            if (enderecoRem.EFavorito) 
                enderecos.Where(e => e.Id != id).FirstOrDefault().EFavorito = true;

            enderecoRem.EFavorito = false;
            enderecoRem.Inativo = true;

            string msg = _facade.Editar(clienteDb);

            if (msg != "")
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _RemoverTelefonePartial(int id)
        {
            DetalhesTelefoneModel vm = (DetalhesTelefoneModel)GetTelefoneVm(id);
            if (vm == null)
            {
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }
            ViewData["Acao"] = "Remover";
            return PartialView("../Conta/PartialViews/_RmvFavTelefonePartial", vm);
        }

        public IActionResult RemoverTelefone(int id)
        {

            Cliente clienteDb = _facade.GetAllInclude(GetClienteComEmail());

            IList<Telefone> telefones = clienteDb.Telefones.Where(t => t.Inativo == false).ToList();

            Telefone telefoneRem = telefones.Where(t => t.Id == id).FirstOrDefault();
            if (telefoneRem.EFavorito)
                telefones.Where(e => e.Id != id).FirstOrDefault().EFavorito = true;

            telefoneRem.EFavorito = false;
            telefoneRem.Inativo = true;

            string msg = _facade.Editar(clienteDb);

            if (msg != "")
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _RemoverCartaoPartial(int id)
        {
            DetalhesCartaoModel vm = (DetalhesCartaoModel)GetCartaoVm(id);
            if (vm == null)
            {
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }
            ViewData["Acao"] = "Remover";

            return PartialView("../Conta/PartialViews/_RmvFavCartaoPartial", vm);
        }

        public IActionResult RemoverCartao(int id)
        {
            Cliente clienteDb = _facade.GetAllInclude(GetClienteComEmail());

            IList<CartaoCredito> cartoes = clienteDb.Cartoes.Where(c => c.Inativo == false).ToList();

            CartaoCredito cartaoRem = cartoes.Where(t => t.Id == id).FirstOrDefault();
            if (cartaoRem.EFavorito)
                cartoes.Where(e => e.Id != id).FirstOrDefault().EFavorito = true;

            cartaoRem.EFavorito = false;
            cartaoRem.Inativo = true;

            string msg = _facade.Editar(clienteDb);

            if (msg != "")
                TempData["Alert"] = msg;
            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _FavoritarEnderecoPartial(int id)
        {
            DetalhesEnderecoModel vm = (DetalhesEnderecoModel)GetEnderecoVm(id);
            if (vm == null)
            {
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }
            ViewData["Acao"] = "Favoritar";

            return PartialView("../Conta/PartialViews/_RmvFavEnderecoPartial", vm);
        }

        public IActionResult FavoritarEndereco(int id)
        {

            Cliente clienteDb = _facade.GetAllInclude(GetClienteComEmail());

            IList<Endereco> enderecos = clienteDb.Enderecos.Where(e => e.Inativo == false).ToList();

            Endereco enderecoFav = enderecos.Where(e => e.Id == id).FirstOrDefault();
            foreach (var endereco in enderecos.Where(e => e.Id != id))
                endereco.EFavorito = false;

            enderecoFav.EFavorito = true;

            string msg = _facade.Editar(clienteDb);

            if (msg != "")
                TempData["Alert"] = msg;
            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _FavoritarTelefonePartial(int id)
        {
            DetalhesTelefoneModel vm = (DetalhesTelefoneModel)GetTelefoneVm(id);
            if (vm == null)
            {
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }
            ViewData["Acao"] = "Favoritar";
            return PartialView("../Conta/PartialViews/_RmvFavTelefonePartial", vm);
        }

        public IActionResult FavoritarTelefone(int id)
        {
            Cliente clienteDb = _facade.GetAllInclude(GetClienteComEmail());

            IList<Telefone> telefones = clienteDb.Telefones.Where(e => e.Inativo == false).ToList();

            Telefone telefoneFav = telefones.Where(e => e.Id == id).FirstOrDefault();
            foreach (var telefone in telefones.Where(e => e.Id != id))
                telefone.EFavorito = false;

            telefoneFav.EFavorito = true;

            string msg = _facade.Editar(clienteDb);

            if (msg != "")
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _FavoritarCartaoPartial(int id)
        {
            DetalhesCartaoModel vm = (DetalhesCartaoModel)GetCartaoVm(id);
            if (vm == null)
            {
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }
            ViewData["Acao"] = "Favoritar";

            return PartialView("../Conta/PartialViews/_RmvFavCartaoPartial", vm);
        }

        public IActionResult FavoritarCartao(int id)
        {
            Cliente clienteDb = _facade.GetAllInclude(GetClienteComEmail());

            IList<CartaoCredito> cartoes = clienteDb.Cartoes.Where(e => e.Inativo == false).ToList();

            CartaoCredito cartaoFav = cartoes.Where(e => e.Id == id).FirstOrDefault();
            foreach (var cartao in cartoes.Where(e => e.Id != id))
                cartao.EFavorito = false;

            cartaoFav.EFavorito = true;

            string msg = _facade.Editar(clienteDb);

            if (msg != "")
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(Detalhes));
        }

        #endregion

        #region Utilidades


        [HttpPost]
        public IActionResult ChecaEmail(string email)
        {
            var clienteDb = _facade.Query<Cliente>(
                c => c.Usuario.Email == email,
                c => c);

            if (clienteDb.Count() > 0) return Json(new { valor = true });
            return Json(new { valor = false });
        }

        private string GeraCodigoCliente()
    {
        Random rnd = new Random();

        int codigo = rnd.Next(0, 1000000);
        bool naoExiste = true;
        do
        {
            var items = _facade.Query<Cliente>(
                c => Convert.ToInt32(c.Codigo) == codigo,
                c => c);

            if (items.Count() == 0) return codigo.ToString("D7");
            codigo = rnd.Next(0, 1000000); ;
        } while (naoExiste);

        return "";
    }

        private IList<BandeiraCartaoCredito> GetBandeiras() 
        {
            return _facade.Listar<BandeiraCartaoCredito>().OrderBy(b => b.Nome).ToList();
        }

        private IList<TipoEndereco> GetTipoEnderecos() 
        {
            return _facade.Listar<TipoEndereco>().OrderBy(b => b.Nome).ToList();
        }

        private IList<TipoTelefone> GetTipoTelefones()
        {
            return _facade.Listar<TipoTelefone>().OrderBy(b => b.Nome).ToList();
        }

        private IViewModel GetEnderecoVm(int id)
        {
            Endereco e = _facade.GetAllInclude(GetClienteComEmail()).Enderecos
                .Where(e => e.Id == id).FirstOrDefault();

            if (e == null)
            {
                return null;
            }

            _vh = new DetalhesEnderecoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Endereco).Name] = e
                }
            };

            DetalhesEnderecoModel vm = (DetalhesEnderecoModel)_vh.ViewModel;

            return vm;
        }

        private IViewModel GetTelefoneVm(int id) 
        {
            Telefone t = _facade.GetAllInclude(GetClienteComEmail()).Telefones
                .Where(t => t.Id == id).FirstOrDefault();

            if (t == null)
            {
                return null;
            }

            _vh = new DetalhesTelefoneViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Telefone).Name] = t
                }
            };

            DetalhesTelefoneModel vm = (DetalhesTelefoneModel)_vh.ViewModel;

            return vm;
        }

        private IViewModel GetCartaoVm(int id) 
        {
            CartaoCredito c = _facade.GetAllInclude(GetClienteComEmail()).Cartoes
                   .Where(c => c.Id == id).FirstOrDefault();

            if (c == null)
            {
                return null;
            }

            _vh = new DetalhesCartaoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(CartaoCredito).Name] = c
                }
            };

            DetalhesCartaoModel vm = (DetalhesCartaoModel)_vh.ViewModel;

            return vm;
        }
        #endregion
    }
}