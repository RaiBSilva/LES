using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Controllers
{
    public class AdminController : Controller
    {
        public AdminClienteModel ClienteDemo = new AdminClienteModel();
        public AlterarSenhaModel Senha = new AlterarSenhaModel();
        public PedidosPaginaModel PedidosDemo = new PedidosPaginaModel();
        public ClientesPaginaModel ClientesDemo = new ClientesPaginaModel();

        public AdminController()
        {
            #region Cliente de Demonstração
            ClienteDemo.InfoUsuario.Codigo = "1";
            ClienteDemo.InfoUsuario.Cpf = "1111111111";
            ClienteDemo.InfoUsuario.DtNascimento = DateTime.Now;
            ClienteDemo.InfoUsuario.Email = "ninguemvailerisso@dacueba.com";
            ClienteDemo.InfoUsuario.Genero = (Genero)1;
            ClienteDemo.InfoUsuario.Nome = "Kevin Man'mar";
            ClienteDemo.InfoUsuario.NotaUsuario = 5;
            ClienteDemo.Inativo = false;

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

            AdminPedidoModel aped = new AdminPedidoModel();
            aped.Codigo = "11";
            aped.DtPedido = DateTime.Today;
            aped.Status = (StatusPedidos)1;
            AdminPedidoModel aped2 = new AdminPedidoModel();
            aped2.Codigo = "12";
            aped2.DtPedido = DateTime.Today;
            aped2.Status = (StatusPedidos)6;
            AdminPedidoModel aped3 = new AdminPedidoModel();
            aped3.Codigo = "13";
            aped3.DtPedido = DateTime.Today;
            aped3.Status = (StatusPedidos)0;

            aped.Livros.Add(livro);
            aped.Livros.Add(livro);
            aped.Livros.Add(livro);

            aped2.Livros.Add(livro);
            aped2.Livros.Add(livro);

            aped3.Livros.Add(livro);
            aped3.Livros.Add(livro);
            aped3.Livros.Add(livro);
            aped3.Livros.Add(livro);

            PedidosDemo.Pedidos.Add(aped);
            PedidosDemo.Pedidos.Add((aped2));
            PedidosDemo.Pedidos.Add((aped3));

            PedidosDemo.Pedidos[0].Cliente = ClienteDemo;
            PedidosDemo.Pedidos[1].Cliente = ClienteDemo;
            PedidosDemo.Pedidos[2].Cliente = ClienteDemo;

            ClientesDemo.Clientes.Add((AdminClienteModel)ClienteDemo);
            ClientesDemo.Clientes.Add((AdminClienteModel)ClienteDemo);
            ClientesDemo.Clientes.Add((AdminClienteModel)ClienteDemo);

            ClientesDemo.Clientes[0].Inativo = true;

            #endregion
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Clientes()
        {
            return View(ClientesDemo);
            
        }

        public IActionResult Cliente(int id) {

            return View("DetalhesCliente", ClienteDemo);
        }

        public IActionResult Pedidos()
        {
            return View(PedidosDemo);
        }

        public IActionResult ConfigLoja() {
            return View();
        }

        #region Pedidos
        public IActionResult _AprovarPedidoPartial(int id) 
        {
            return PartialView("../Admin/PartialViews/_AprovarPedidoPartial", PedidosDemo.Pedidos[0]);
        }

        public IActionResult AdicionarPedido(int id)
        {
            return RedirectToAction(nameof(Pedidos));
        }

        public IActionResult _NegarPedidoPartial(int id)
        {
            return PartialView("../Admin/PartialViews/_NegarPedidoPartial", PedidosDemo.Pedidos[0]);
        }

        public IActionResult NegarPedido(int id)
        {
            return RedirectToAction(nameof(Pedidos));
        }

        public IActionResult _CancelarPedidoPartial(int id)
        {
            return PartialView("../Admin/PartialViews/_CancelarPedidoPartial", PedidosDemo.Pedidos[0]);
        }

        public IActionResult CancelarPedido(int id)
        {
            return RedirectToAction(nameof(Pedidos));
        }

        public IActionResult _VisualizarPedidoPartial(int id)
        {
            return PartialView("../Admin/PartialViews/_VisualizarPedidoPartial", PedidosDemo.Pedidos[0]);
        }

        #endregion

        #region Clientes

        public IActionResult _InativarReativarClientePartial(int id) {
            return PartialView("../Admin/PartialViews/_InativarReativarClientePartial", ClienteDemo);
        }

        public IActionResult InativarReativarCliente(int id)
        {
            return RedirectToAction(nameof(Pedidos));
        }

        #endregion

    }
}
