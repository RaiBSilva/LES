using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LES.Controllers;
using LES.Controllers.Facade;
using LES.Models.Entity;
using LES.Models.ViewHelpers;
using LES.Models.ViewHelpers.Conta;
using LES.Models.ViewModel;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Conta;
using LES.Models.ViewModel.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LES.Views.Conta
{
    public class ContaController : BaseController
    {
        private IFacadeCrud<Cliente> _facade { get; set; }
        private IFacadeCrud<BandeiraCartaoCredito> _facadeBandeiras { get; set; }
        private IFacadeCrud<TipoTelefone> _facadeTipoTelefone { get; set; }
        private IFacadeCrud<TipoEndereco> _facadeTipoEndereco { get; set; }

        public ContaController(IFacadeCrud<Cliente> facade,
            IFacadeCrud<BandeiraCartaoCredito> facadeBandeira,
            IFacadeCrud<TipoTelefone> facadeTipoTelefone,
            IFacadeCrud<TipoEndereco> facadeTipoEndereco)
        {
            _facade = facade;
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
                    ViewModel = (IViewModel)usuario
                };

                Cliente clienteLogin = new Cliente 
                { 
                    Usuario = (Usuario)_vh.Entidades[typeof(Usuario).Name] 
                };

                Cliente clienteDb = _facade.Query<Cliente>(
                    c => c.Usuario.Email == clienteLogin.Usuario.Email, 
                    c => c,
                    c => c.Usuario).FirstOrDefault();

                if (clienteLogin.Usuario.Senha == clienteDb.Usuario.Senha) 
                {
                    int role = (int)clienteLogin.Usuario.Role;

                    var userClaims = new List<Claim>()
                    {
                    new Claim(ClaimTypes.Name, clienteLogin.Nome),
                    new Claim(ClaimTypes.Email, clienteLogin.Usuario.Email),
                    new Claim(ClaimTypes.Role, role.ToString())
                     };

                    var grandmaIdentity = new ClaimsIdentity(userClaims, "UsuarioInfo");

                    var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                    HttpContext.SignInAsync(userPrincipal);

                    return RedirectToAction("Index", "Home");
                    }

                return RedirectToAction("Index","Home");
            }
            return View();
        }

        //GET /Conta/Registro
        public IActionResult Registro() 
        {

            PaginaRegistroModel vm = new PaginaRegistroModel()
            {
                Cartao = new CartaoBaseModel { Bandeiras = _facadeBandeiras.Listar() },
                Telefone = new TelefoneBaseModel { TipoTelefones = _facadeTipoTelefone.Listar() },
                Endereco = new EnderecoBaseModel { TiposEnderecos = _facadeTipoEndereco.Listar() }
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

                string msg = _facade.Cadastrar(cliente);

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

    }
}