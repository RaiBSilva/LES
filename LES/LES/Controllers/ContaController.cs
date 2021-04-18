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
        private IFacadeCrud<Cliente> _facadeClientes { get; set; }
        private IFacadeCrud<BandeiraCartaoCredito> _facadeBandeiras { get; set; }
        private IFacadeCrud<TipoTelefone> _facadeTipoTelefone { get; set; }
        private IFacadeCrud<TipoEndereco> _facadeTipoEndereco { get; set; }

        public ContaController(IFacadeCrud<Cliente> facadeClientes,
            IFacadeCrud<BandeiraCartaoCredito> facadeBandeira,
            IFacadeCrud<TipoTelefone> facadeTipoTelefone,
            IFacadeCrud<TipoEndereco> facadeTipoEndereco)
        {
            _facadeClientes = facadeClientes;
            _facadeBandeiras = facadeBandeira;
            _facadeTipoTelefone = facadeTipoTelefone;
            _facadeTipoEndereco = facadeTipoEndereco;
        }

        #region Login, Registro e Detalhes
        //GET /Conta/Login
        public IActionResult Login()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Login(PaginaLoginModel usuario)
        {
            if (ModelState.IsValid) 
            { 
            
                _vh = new PaginaLoginViewHelper
                {
                    ViewModel = usuario
                };

                Cliente clienteLogin = new Cliente
                {
                    Usuario = (Usuario)_vh.Entidades[typeof(Usuario).Name]
                };

                Cliente clienteDb = _facadeClientes.Query(
                    c => c.Usuario.Email == clienteLogin.Usuario.Email, 
                    c => c,
                    c => c.Usuario).FirstOrDefault();

                if (clienteDb != null) {  
                    if (GerenciadorLogin.comparaSenha(usuario.Senha, clienteDb.Usuario.Senha)) 
                    {
                        HttpContext.SignInAsync(GerenciadorLogin.FazerLogin(clienteDb));
                        return RedirectToAction("Index", "Home");
                    }
                    return View(new PaginaLoginModel
                    {
                        Username = clienteLogin.Usuario.Email,
                        Falhou = true
                    });
                }
            }
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
            cliente.Cartoes[0].Bandeira = _facadeBandeiras.GetEntidade(cliente.Cartoes[0].Bandeira);
            cliente.Enderecos[0].TipoEndereco = _facadeTipoEndereco.GetEntidade(cliente.Enderecos[0].TipoEndereco);
            cliente.Telefones[0].TipoTelefone = _facadeTipoTelefone.GetEntidade(cliente.Telefones[0].TipoTelefone);
            cliente.Codigo = GeraCodigoCliente();

            string msg = _facadeClientes.Cadastrar(cliente);

            if (msg == "")  return RedirectToAction("Login");
            TempData["Alert"] = msg;
            return RedirectToAction("Registro");
        }

        [Authorize]
        //Get /Conta/Detalhes
        public IActionResult Detalhes() 
        {
            Cliente cliente = GetClienteComEmail();

            var clienteDb = _facadeClientes.GetAllInclude(cliente);                

            IDictionary<string, EntidadeDominio> e = new Dictionary<string, EntidadeDominio>
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

        #endregion

        #region Editar

        //GET Conta/_EditarInfoPessoalPartial
        public IActionResult _EditarInfoPessoalPartial(int id)
        {
            Cliente cliente = _facadeClientes.Query(c => c.Codigo == id.ToString(),
                c => c,
                c => c.Usuario).FirstOrDefault();

            if(cliente == null)
            {
                return  PartialView("../Conta/PartialViews/_ErroPartial"); 
            }

            IDictionary<string, EntidadeDominio> entidades = new Dictionary<string, EntidadeDominio>
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

            Cliente clienteDb = _facadeClientes.Query<Cliente>(c => c.Codigo == clienteRequest.Codigo,
                c => c,
                c => c.Usuario).FirstOrDefault();

            clienteDb.Cpf = clienteRequest.Cpf;
            clienteDb.DtNascimento = clienteRequest.DtNascimento;
            clienteDb.Genero = clienteRequest.Genero;
            clienteDb.Nome = clienteRequest.Nome;
            clienteDb.Usuario.Email = clienteRequest.Usuario.Email;

            string msg = _facadeClientes.Editar(clienteDb);

            if(msg == "") return RedirectToAction(nameof(Detalhes));
            TempData["Alert"] = msg;
            return RedirectToAction("Registro");

        }

        //GET Conta/_EditarSenhaPartial
        public IActionResult _EditarSenhaPartial(int id) 
        {
            string codigo = _facadeClientes.Query(c => c.Codigo == id.ToString(),
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

            Cliente clienteDb = _facadeClientes.Query<Cliente>(c => c.Usuario.Email == email,
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
                string msg = _facadeClientes.Editar(clienteDb);
                if (msg == "") return RedirectToAction(nameof(Detalhes));
                TempData["Alert"] = msg;
            }

            return RedirectToAction(nameof(Detalhes));
        }


        //GET Conta/_EditarEnderecoPartial
        public IActionResult _EditarEnderecoPartial(int id)
        {
            Endereco e = _facadeClientes.GetAllInclude( GetClienteComEmail()).Enderecos
                .Where(e => e.Id == id).FirstOrDefault();

            if (e == null)
            {
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }

            _vh = new DetalhesEnderecoViewHelper
            {
                Entidades = new Dictionary<string, EntidadeDominio>
                {
                    [typeof(Endereco).Name] = e
                }
            };

            DetalhesEnderecoModel vm = (DetalhesEnderecoModel)_vh.ViewModel;
            vm.TiposEnderecos = GetTipoEnderecos();

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

            Cliente c = _facadeClientes.GetAllInclude(GetClienteComEmail());

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
            endDb.TipoEndereco = _facadeTipoEndereco.GetEntidade(endNovo.TipoEndereco);

            string msg = _facadeClientes.Editar(c);

            if (msg != null)
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(Detalhes));
        }

        //GET Conta/_EditarTelefonePartial
        public IActionResult _EditarTelefonePartial(int id)
        {

            Telefone t = _facadeClientes.GetAllInclude(GetClienteComEmail()).Telefones
                .Where(t => t.Id == id).FirstOrDefault();

            if (t == null)
            {
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }

            _vh = new DetalhesTelefoneViewHelper
            {
                Entidades = new Dictionary<string, EntidadeDominio>
                {
                    [typeof(Telefone).Name] = t
                }
            };

            DetalhesTelefoneModel vm = (DetalhesTelefoneModel)_vh.ViewModel;
            vm.TipoTelefones = GetTipoTelefones();

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

            Cliente c = _facadeClientes.GetAllInclude(GetClienteComEmail());

            var telDb = c.Telefones.Where(t => t.Id == telNovo.Id).FirstOrDefault();

            telDb.Ddd = telNovo.Ddd;
            telDb.EFavorito = telNovo.EFavorito;
            telDb.Numero = telNovo.Numero;
            telDb.TipoTelefone = _facadeTipoTelefone.GetEntidade(telNovo.TipoTelefone);

            string msg = _facadeClientes.Editar(c);

            if (msg != null)
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(Detalhes));
        }

        //GET Conta/_EditarCartaoPartial
        public IActionResult _EditarCartaoPartial(int id)
        {
            CartaoCredito c = _facadeClientes.GetAllInclude(GetClienteComEmail()).Cartoes
                   .Where(c => c.Id == id).FirstOrDefault();

            if (c == null)
            {
                return PartialView("../Conta/PartialViews/_ErroPartial");
            }

            _vh = new DetalhesCartaoViewHelper
            {
                Entidades = new Dictionary<string, EntidadeDominio>
                {
                    [typeof(CartaoCredito).Name] = c
                }
            };

            DetalhesCartaoModel vm = (DetalhesCartaoModel)_vh.ViewModel;
            vm.Bandeiras = GetBandeiras();

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

            Cliente c = _facadeClientes.GetAllInclude(GetClienteComEmail());

            var carDb = c.Cartoes.Where(t => t.Id == carNovo.Id).FirstOrDefault();

            carDb.Bandeira = _facadeBandeiras.GetEntidade(carNovo.Bandeira);
            carDb.Codigo = carNovo.Codigo;
            carDb.Cvv = carNovo.Cvv;
            carDb.EFavorito = carNovo.EFavorito;
            carDb.NomeImpresso = carNovo.NomeImpresso;
            carDb.Vencimento = carNovo.Vencimento;

            string msg = _facadeClientes.Editar(c);

            if (msg != null)
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(Detalhes));
        }

        #endregion

        #region Adicionar
        public IActionResult _AdicionarNovoEnderecoPartial(int id) 
        {
            return PartialView("../Conta/PartialViews/_AdicionarNovoEnderecoPartial");
        }

        [HttpPost]
        public IActionResult AdicionarNovoEndereco(DetalhesEnderecoModel novoEndereco) 
        {
            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _AdicionarNovoTelefonePartial(int id)
        {
            return PartialView("../Conta/PartialViews/_AdicionarNovoTelefonePartial");
        }

        [HttpPost]
        public IActionResult AdicionarNovoTelefone(DetalhesTelefoneModel novoTelefone)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _AdicionarNovoCartaoPartial(int id)
        {
            return PartialView("../Conta/PartialViews/_AdicionarNovoCartaoPartial");
        }

        [HttpPost]
        public IActionResult AdicionarNovoCartao(DetalhesCartaoModel novoCartao)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        #endregion

        #region Remover

        public IActionResult _RemoverEnderecoPartial(int id)
        {
            return PartialView("../Conta/PartialViews/_RemoverEnderecoPartial"/*, ClienteDemo.Enderecos[0]*/);
        }

        public IActionResult RemoverEndereco(int id)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _RemoverTelefonePartial(int id)
        {
            return PartialView("../Conta/PartialViews/_RemoverTelefonePartial" /*ClienteDemo.Telefones[0]*/);
        }

        public IActionResult RemoverTelefone(int id)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _RemoverCartaoPartial(int id)
        {
            return PartialView("../Conta/PartialViews/_RemoverCartaoPartial" /*ClienteDemo.Cartoes[0]*/);
        }

        public IActionResult RemoverCartao(int id)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        #endregion

        #region Troca

        public IActionResult _RealizarTrocaPartial(int id)
        {
            return PartialView("../Conta/PartialViews/_RealizarTrocaPartial"/*, ClienteDemo.Pedidos[0].Livros[0]*/);
        }

        public IActionResult RealizarTroca(int id)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        #endregion

        #region Utilidades


        [HttpPost]
        public IActionResult ChecaEmail(string email)
        {
            var clienteDb = _facadeClientes.Query<Cliente>(
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
            var items = _facadeClientes.Query(
                c => Convert.ToInt32(c.Codigo) == codigo,
                c => c);

            if (items.Count() == 0) return codigo.ToString("D6");
            codigo = rnd.Next(0, 1000000); ;
        } while (naoExiste);

        return "";
    }

        private Cliente GetClienteComEmail()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            Cliente cliente = new Cliente
            {
                Usuario = new Usuario
                {
                    Email = email
                }
            };

            return cliente;
        }

        private IList<BandeiraCartaoCredito> GetBandeiras() 
        {
            return _facadeBandeiras.Listar().OrderBy(b => b.Nome).ToList();
        }

        private IList<TipoEndereco> GetTipoEnderecos() 
        {
            return _facadeTipoEndereco.Listar().OrderBy(b => b.Nome).ToList();
        }

        private IList<TipoTelefone> GetTipoTelefones()
        {
            return _facadeTipoTelefone.Listar().OrderBy(b => b.Nome).ToList();
        }
        #endregion
    }
}