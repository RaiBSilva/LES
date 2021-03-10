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
        AlterarSenhaModel Senha = new AlterarSenhaModel();

        public ContaController()
        {
            ClienteDemo.InfoUsuario.Codigo = "1";
            ClienteDemo.InfoUsuario.Cpf = "1111111111";
            ClienteDemo.InfoUsuario.DtNascimento = DateTime.Now;
            ClienteDemo.InfoUsuario.Email = "ninguemvailerisso@dacueba.com";
            ClienteDemo.InfoUsuario.Genero = (Genero)1;
            ClienteDemo.InfoUsuario.Nome = "Kevin Man'mar";
            ClienteDemo.InfoUsuario.NotaUsuario = 0;

            DetalhesEnderecoModel end = new DetalhesEnderecoModel();
            end.Id = "1";
            end.NomeEndereco = "Tortura";
            end.TipoEndereco = (TipoEndereco)0;
            end.Logradouro = "Rua Carlos Barattino Vila Nova";
            end.Numero = "908";
            end.Complemento = "Vila Mogilar";
            end.Cep = "08773-600";
            end.Cidade = "Mogi das Cruzes";
            end.Estado = "São Paulo";
            end.Pais = "Brasil";
            end.Observacoes = "Bora cumpade";
            end.ECobranca = true;
            end.EEntrega = true;
            end.EPreferencial = false;

            ClienteDemo.Enderecos.Add(end);

            end.ECobranca = false;
            end.EEntrega = false;
            end.EPreferencial = true;

            ClienteDemo.Enderecos.Add(end);
            ClienteDemo.Enderecos.Add(end);
            ClienteDemo.Enderecos.Add(end);

            DetalhesTelefoneModel tel = new DetalhesTelefoneModel();

            tel.Id = "1";
            tel.TipoTelefone = (TipoTelefone)0;
            tel.Ddd = "011";
            tel.NumeroTelefone = "40028922";
            tel.EPreferencial = true;

            ClienteDemo.Telefones.Add(tel);

            tel.EPreferencial = false;

            ClienteDemo.Telefones.Add(tel);

            DetalhesCartaoModel card = new DetalhesCartaoModel();

            card.Bandeira = (BandeiraCartaoCredito)0;
            card.Codigo = "1234567812345678";
            card.Cvv = "255";
            card.EPreferencial = true;
            card.Id = "1";
            card.Nome = "KEVIN MANMAR";
            card.Vencimento = DateTime.Today;

            ClienteDemo.Cartoes.Add(card);
            ClienteDemo.Cartoes.Add(card);

            Senha.Codigo = "1";
            Senha.VelhaSenha = "";
            Senha.Senha = "";

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

        //GET Conta/_EditarInfoPessoalPartial
        public IActionResult _EditarInfoPessoalPartial(int id)
        {
            return PartialView("../Conta/PartialViews/_EditarInfoPartial", ClienteDemo.InfoUsuario);
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
            return PartialView("../Conta/PartialViews/_EditarSenhaPartial", Senha);
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
            return PartialView("../Conta/PartialViews/_EditarEnderecoPartial", ClienteDemo.Enderecos[0]);
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
            return PartialView("../Conta/PartialViews/_EditarTelefonePartial", ClienteDemo.Telefones[0]);
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
            return PartialView("../Conta/PartialViews/_EditarCartaoPartial", ClienteDemo.Cartoes[0]);
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