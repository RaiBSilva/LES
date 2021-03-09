using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Models.Entity;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Mvc;

namespace LES.Views.Conta
{
    public class ContaController : Controller
    {

        DetalhesModel ClienteDemo = new DetalhesModel();

        public ContaController() 
        {
            ClienteDemo.InfoUsuario = new DetalhesInfoModel();
            ClienteDemo.Enderecos = new List<DetalhesEnderecoModel>();
            ClienteDemo.Telefones = new List<DetalhesTelefoneModel>();
            ClienteDemo.Cartoes = new List<DetalhesCartaoModel>();
        }

        //GET /Conta/Login
        public IActionResult Login()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Login(LoginModel usuario) 
        {
            return View();
        }

        //GET /Conta/Registro
        public IActionResult Registro() 
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Registro(RegistroModel usuarioNovo)
        {
            return View();
        }

        //Get /Conta/Detalhes
        public IActionResult Detalhes() 
        {
            return View(ClienteDemo);
        }

        //GET Conta/EditarInfo
        public IActionResult EditarInfo(int id)
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult EditarInfo(InfoBaseModel info)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        //GET Conta/EditarSenha
        public IActionResult EditarSenha(int id) 
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult EditarSenha(EditarSenhaModel senha)
        {
            return RedirectToAction(nameof(Detalhes));
        }


        //GET Conta/EditarEndereco
        public IActionResult EditarEndereco(int id)
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult EditarEndereco(DetalhesEnderecoModel endereco)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        //GET Conta/EditarEndereco
        public IActionResult EditarTelefone(int id)
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult EditarTelefone(DetalhesTelefoneModel telefone)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        //GET Conta/EditarCartao
        public IActionResult EditarCartao(int id)
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult EditarCartao(DetalhesCartaoModel cartao)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _AdicionarNovoEnderecoPartial(int id) 
        {
            return PartialView("../Conta/PartialViews/_AdicionarNovoEnderecoPartial");
        }

        [HttpPost]
        public IActionResult AdicionarNovoEndereco(AdicionarNovoEnderecoModel novoEndereco) 
        {
            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _AdicionarNovoTelefonePartial(int id)
        {
            return PartialView("../Conta/PartialViews/_AdicionarNovoTelefonePartial");
        }

        [HttpPost]
        public IActionResult AdicionarNovoTelefone(AdicionarNovoTelefoneModel novoTelefone)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _AdicionarNovoCartaoPartial(int id)
        {
            return PartialView("../Conta/PartialViews/_AdicionarNovoCartaoPartial");
        }

        [HttpPost]
        public IActionResult AdicionarNovoCartao(AdicionarNovoTelefoneModel novoTelefone)
        {
            return RedirectToAction(nameof(Detalhes));
        }

    }
}