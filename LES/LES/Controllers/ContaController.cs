using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using LES.Controllers;
using LES.Controllers.Facade;
using LES.Models.Entity;
using LES.Models.ViewHelpers.Conta;
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

                Cliente clienteDb = _facadeClientes.Query<Cliente>(
                    c => c.Usuario.Email == clienteLogin.Usuario.Email, 
                    c => c,
                    c => c.Usuario).FirstOrDefault();

                string senhaDb = clienteDb.Usuario.Senha;
                byte[] hashBytes = Convert.FromBase64String(senhaDb);
                byte[] salt = new byte[16];

                Array.Copy(hashBytes, 0, salt, 0, 16);

                var pbkdf2 = new Rfc2898DeriveBytes(usuario.Senha, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                bool access = true;

                for (int i = 0; i < 20; i++)
                    if (hashBytes[i + 16] != hash[i])
                        access = false;

                if (access) 
                {
                    int role = (int)clienteDb.Usuario.Role;

                    var userClaims = new List<Claim>()
                    {
                    new Claim(ClaimTypes.Name, clienteDb.Nome),
                    new Claim(ClaimTypes.Email, clienteDb.Usuario.Email),
                    new Claim(ClaimTypes.Role, role.ToString())
                     };

                    var grandmaIdentity = new ClaimsIdentity(userClaims, "UsuarioInfo");

                    var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                    HttpContext.SignInAsync(userPrincipal);

                    return RedirectToAction("Index", "Home");
                }
                return View(new PaginaLoginModel
                {
                    Username = clienteLogin.Usuario.Email,
                    Falhou = true
                });
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
                    Bandeiras = _facadeBandeiras.Listar().OrderBy(b => b.Nome).ToList(),
                    Vencimento = DateTime.Now
                },
                Telefone = new TelefoneBaseModel 
                { 
                    TipoTelefones = _facadeTipoTelefone.Listar().OrderBy(t => t.Nome).ToList() 
                },
                Endereco = new EnderecoBaseModel 
                { 
                    TiposEnderecos = _facadeTipoEndereco.Listar().OrderBy(t => t.Nome).ToList() 
                }
            };

            return View(vm);
        }

        //POST
        [HttpPost]
        public IActionResult Registro(PaginaRegistroModel usuarioNovo)
        {
            if (ModelState.IsValid)
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
                else
                {
                    //handling de quebra de strategies
                    return View();
                }
            }

            return View();
        }

        [Authorize]
        //Get /Conta/Detalhes
        public IActionResult Detalhes() 
        {
            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            return View();
        }

        #endregion

        #region Editar

        //GET Conta/_EditarInfoPessoalPartial
        public IActionResult _EditarInfoPessoalPartial(int id)
        {
            return PartialView("../Conta/PartialViews/_EditarInfoPartial"/*, ClienteDemo.InfoUsuario*/);
        }

        //POST
        [HttpPost]
        public IActionResult EditarInfo(InfoBaseModel info)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        //GET Conta/_EditarSenhaPartial
        public IActionResult _EditarSenhaPartial(int id) 
        {
            return PartialView("../Conta/PartialViews/_EditarSenhaPartial"/*, Senha*/);
        }

        //POST
        [HttpPost]
        public IActionResult EditarSenha(AlterarSenhaModel senhaModel)
        {
            return RedirectToAction(nameof(Detalhes));
        }


        //GET Conta/_EditarEnderecoPartial
        public IActionResult _EditarEnderecoPartial(int id)
        {
            return PartialView("../Conta/PartialViews/_EditarEnderecoPartial"/*, ClienteDemo.Enderecos[0]*/);
        }

        //POST
        [HttpPost]
        public IActionResult EditarEndereco(DetalhesEnderecoModel endereco)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        //GET Conta/_EditarTelefonePartial
        public IActionResult _EditarTelefonePartial(int id)
        {
            return PartialView("../Conta/PartialViews/_EditarTelefonePartial"/*, ClienteDemo.Telefones[0]*/);
        }

        //POST
        [HttpPost]
        public IActionResult EditarTelefone(DetalhesTelefoneModel telefone)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        //GET Conta/_EditarCartaoPartial
        public IActionResult _EditarCartaoPartial(int id)
        {
            return PartialView("../Conta/PartialViews/_EditarCartaoPartial"/*, ClienteDemo.Cartoes[0]*/);
        }

        //POST
        [HttpPost]
        public IActionResult EditarCartao(DetalhesCartaoModel cartao)
        {
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

        [HttpPost]
        public IActionResult ChecaEmail(string email)
        {
            var clienteDb = _facadeClientes.Query<Cliente>(
                c => c.Usuario.Email == email,
                c => c);

            if (clienteDb.Count() > 0) return Json(new { valor = true }) ;
            return Json(new { valor = false });
        }

        private string GeraCodigoCliente()
        {
            Random rnd = new Random();

            int codigo = rnd.Next();
            bool naoExiste = true;
            do
            {
                var items = _facadeClientes.Query<Cliente>(
                    c => Convert.ToInt32(c.Codigo) == codigo,
                    c => c);

                if (items.Count() == 0) return codigo.ToString();
                codigo = rnd.Next();
            } while (naoExiste);

            return "";
        }

    }
}