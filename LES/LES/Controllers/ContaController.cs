using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Models.Entity;
using LES.Models.ViewModel.Conta;
using LES.Models.ViewModel.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LES.Views.Conta
{
    public class ContaController : Controller
    {

        DetalhesModel ClienteDemo = new DetalhesModel();
        AlterarSenhaModel Senha = new AlterarSenhaModel();

        public ContaController()
        {
            #region Cliente de Demonstração
            ClienteDemo.InfoUsuario.Codigo = "1";
            ClienteDemo.InfoUsuario.Cpf = "1111111111";
            ClienteDemo.InfoUsuario.DtNascimento = DateTime.Now;
            ClienteDemo.InfoUsuario.Email = "ninguemvailerisso@dacueba.com";
            ClienteDemo.InfoUsuario.Genero = (Genero)1;
            ClienteDemo.InfoUsuario.Nome = "Kevin Man'mar";
            ClienteDemo.InfoUsuario.NotaUsuario = 5;

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
            end.EPreferencial = true;

            ClienteDemo.Enderecos.Add(end);

            DetalhesEnderecoModel end2 = new DetalhesEnderecoModel();
            end2.Id = "1";
            end2.NomeEndereco = "Tortura";
            end2.TipoEndereco = (TipoEndereco)0;
            end2.Logradouro = "Rua Carlos Barattino Vila Nova";
            end2.Numero = "908";
            end2.Complemento = "Vila Mogilar";
            end2.Cep = "08773-600";
            end2.Cidade = "Mogi das Cruzes";
            end2.Estado = "São Paulo";
            end2.Pais = "Brasil";
            end2.Observacoes = "";
            end2.ECobranca = false;
            end2.EEntrega = false;
            end2.EPreferencial = false;

            ClienteDemo.Enderecos.Add(end2);
            ClienteDemo.Enderecos.Add(end2);
            ClienteDemo.Enderecos.Add(end2);

            DetalhesTelefoneModel tel = new DetalhesTelefoneModel();

            tel.Id = "1";
            tel.TipoTelefone = (TipoTelefone)0;
            tel.Ddd = "011";
            tel.NumeroTelefone = "40028922";
            tel.EPreferencial = true;

            ClienteDemo.Telefones.Add(tel);

            DetalhesTelefoneModel tel2 = new DetalhesTelefoneModel();

            tel2.Id = "1";
            tel2.TipoTelefone = (TipoTelefone)0;
            tel2.Ddd = "011";
            tel2.NumeroTelefone = "40028922";
            tel2.EPreferencial = false;

            ClienteDemo.Telefones.Add(tel2);

            DetalhesCartaoModel card = new DetalhesCartaoModel();

            card.Bandeira = (BandeiraCartaoCredito)0;
            card.Codigo = "1234567812345678";
            card.Cvv = "255";
            card.EPreferencial = false;
            card.Id = "1";
            card.Nome = "KEVIN MANMAR";
            card.Vencimento = DateTime.Today;

            ClienteDemo.Cartoes.Add(card);

            DetalhesCartaoModel card2 = new DetalhesCartaoModel();

            card2.Bandeira = (BandeiraCartaoCredito)0;
            card2.Codigo = "1234567812345678";
            card2.Cvv = "255";
            card2.EPreferencial = true;
            card2.Id = "1";
            card2.Nome = "KEVIN MANMAR";
            card2.Vencimento = DateTime.Today;

            //ClienteDemo.Cartoes.Add(card2);

            Senha.Codigo = "1";
            Senha.VelhaSenha = "";
            Senha.Senha = "";

            PedidoModel ped = new PedidoModel();
            ped.Codigo = "11";
            ped.DtPedido = DateTime.Today;
            ped.Status = (StatusPedidos)1;
            PedidoModel ped2 = new PedidoModel();
            ped2.Codigo = "12";
            ped2.DtPedido = DateTime.Today;
            ped2.Status = (StatusPedidos)6;
            PedidoModel ped3 = new PedidoModel();
            ped3.Codigo = "13";
            ped3.DtPedido = DateTime.Today;
            ped3.Status = (StatusPedidos)7;

            var livro = new PedidoLivroModel();

            livro.CodigoBarras = 1;
            livro.Descricao = "The Winds of Winter (Os Ventos do Inverno) é o sexto livro de As Crônicas de Gelo e Fogo, de George R. R. Martin.";
            livro.Preco = 100;
            livro.Titulo = "The Winds of Winter";

            ped.Livros.Add(livro);
            ped.Livros.Add(livro);
            ped.Livros.Add(livro);

            ped2.Livros.Add(livro);
            ped2.Livros.Add(livro);

            ped3.Livros.Add(livro);
            ped3.Livros.Add(livro);
            ped3.Livros.Add(livro);
            ped3.Livros.Add(livro);

            ClienteDemo.Pedidos.Add(ped);
            ClienteDemo.Pedidos.Add(ped2);
            ClienteDemo.Pedidos.Add(ped3);

            #endregion

        }

        #region Login, Registro e Detalhes
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

        #endregion

        #region Editar

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
            return PartialView("../Conta/PartialViews/_RemoverEnderecoPartial", ClienteDemo.Enderecos[0]);
        }

        public IActionResult RemoverEndereco(int id)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _RemoverTelefonePartial(int id)
        {
            return PartialView("../Conta/PartialViews/_RemoverTelefonePartial", ClienteDemo.Telefones[0]);
        }

        public IActionResult RemoverTelefone(int id)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        public IActionResult _RemoverCartaoPartial(int id)
        {
            return PartialView("../Conta/PartialViews/_RemoverCartaoPartial", ClienteDemo.Cartoes[0]);
        }

        public IActionResult RemoverCartao(int id)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        #endregion

        #region Troca

        public IActionResult _RealizarTrocaPartial(int id)
        {
            return PartialView("../Conta/PartialViews/_RealizarTrocaPartial", ClienteDemo.Pedidos[0].Livros[0]);
        }

        public IActionResult RealizarTroca(int id)
        {
            return RedirectToAction(nameof(Detalhes));
        }

        #endregion

    }
}