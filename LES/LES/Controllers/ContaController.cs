﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Controllers.Facade;
using LES.Models.Entity;
using LES.Models.ViewHelpers;
using LES.Models.ViewHelpers.Conta;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Conta;
using LES.Models.ViewModel.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LES.Views.Conta
{
    public class ContaController : Controller
    {
        private IFacadeCrud<Cliente> _facade { get; set; }
        private IViewHelper _vh { get; set; }

        public ContaController(IFacadeCrud<Cliente> facade)
        {
            _facade = facade;
        }

        #region Login, Registro e Detalhes
        //GET /Conta/Login
        public IActionResult Login()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Login(PaginaLoginModel usuario) { 
        {
            _vh = new PaginaLoginViewHelper
            {
                ViewModel = usuario,
            };

            
            Cliente cliente = _vh;


            return View();
        }

        //GET /Conta/Registro
        public IActionResult Registro() 
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Registro(PaginaRegistroModel usuarioNovo)
        {
            return View();
        }

        //Get /Conta/Detalhes
        public IActionResult Detalhes() 
        {
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
        public IActionResult EditarSenha(AlterarSenhaModel senha)
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