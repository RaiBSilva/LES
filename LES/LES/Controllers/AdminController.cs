using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Controllers
{
    public class AdminController : BaseController
    {
        public AdminClienteModel ClienteDemo = new AdminClienteModel();
        public AlterarSenhaModel Senha = new AlterarSenhaModel();
        public PaginaPedidosModel PedidosDemo = new PaginaPedidosModel();
        public PaginaClientesModel ClientesDemo = new PaginaClientesModel();
        public AdminLivroModel LivroDemo = new AdminLivroModel();
        public CategoriaLivroModel Categoria = new CategoriaLivroModel();
        public AdminGrupoPrecoModel GrupoPreco = new AdminGrupoPrecoModel
        {
            Id = 1,
            Nome = "Grupo Preço",
            MargemLucro = 0.50,
            Inativo = false
        };
        public MotivoInativacaoModel Motivo = new MotivoInativacaoModel
        {
            Id = 1,
            Nome = "Motivo"
        };

        /*
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

            DetalhesEnderecoModel end = new DetalhesEnderecoModel
            {
                Id = "1",
                NomeEndereco = "Tortura",
                TipoEndereco = (TipoEndereco)0,
                Logradouro = "Rua Carlos Barattino Vila Nova",
                Numero = "908",
                Complemento = "Vila Mogilar",
                Cep = "08773-600",
                Cidade = "Mogi das Cruzes",
                Estado = "São Paulo",
                Pais = "Brasil",
                Observacoes = "Bora cumpade",
                ECobranca = true,
                EEntrega = true,
                EPreferencial = true
            };

            ClienteDemo.Enderecos.Add(end);

            DetalhesEnderecoModel end2 = new DetalhesEnderecoModel
            {
                Id = "1",
                NomeEndereco = "Tortura",
                TipoEndereco = (TipoEndereco)0,
                Logradouro = "Rua Carlos Barattino Vila Nova",
                Numero = "908",
                Complemento = "Vila Mogilar",
                Cep = "08773-600",
                Cidade = "Mogi das Cruzes",
                Estado = "São Paulo",
                Pais = "Brasil",
                Observacoes = "",
                ECobranca = false,
                EEntrega = false,
                EPreferencial = false
            };

            ClienteDemo.Enderecos.Add(end2);
            ClienteDemo.Enderecos.Add(end2);
            ClienteDemo.Enderecos.Add(end2);

            DetalhesTelefoneModel tel = new DetalhesTelefoneModel
            {
                Id = "1",
                TipoTelefone = (TipoTelefone)0,
                Ddd = "011",
                NumeroTelefone = "40028922",
                EPreferencial = true
            };

            ClienteDemo.Telefones.Add(tel);

            DetalhesTelefoneModel tel2 = new DetalhesTelefoneModel
            {
                Id = "1",
                TipoTelefone = (TipoTelefone)0,
                Ddd = "011",
                NumeroTelefone = "40028922",
                EPreferencial = false
            };

            ClienteDemo.Telefones.Add(tel2);

            DetalhesCartaoModel card = new DetalhesCartaoModel
            {
                Bandeira = (BandeiraCartaoCredito)0,
                Codigo = "1234567812345678",
                Cvv = "255",
                EPreferencial = false,
                Id = "1",
                Nome = "KEVIN MANMAR",
                Vencimento = DateTime.Today
            };

            DetalhesCartaoModel card2 = new DetalhesCartaoModel
            {
                Bandeira = (BandeiraCartaoCredito)0,
                Codigo = "1234567812345678",
                Cvv = "255",
                EPreferencial = true,
                Id = "1",
                Nome = "KEVIN MANMAR",
                Vencimento = DateTime.Today
            };

            ClienteDemo.Cartoes.Add(card);
            ClienteDemo.Cartoes.Add(card2);
            #endregion

            Senha.Codigo = "1";
            Senha.VelhaSenha = "";
            Senha.Senha = "";

            PedidoModel ped = new PedidoModel
            {
                Codigo = "11",
                DtPedido = DateTime.Today,
                Status = (StatusPedidos)1
            };
            PedidoModel ped2 = new PedidoModel
            {
                Codigo = "12",
                DtPedido = DateTime.Today,
                Status = (StatusPedidos)6
            };
            PedidoModel ped3 = new PedidoModel
            {
                Codigo = "13",
                DtPedido = DateTime.Today,
                Status = (StatusPedidos)7
            };

            #region Livro de Demonstração
            LivroDemo.Sinopse = "The Winds of Winter (Os Ventos do Inverno) é o sexto livro de As Crônicas de Gelo e Fogo, de George R. R. Martin.";
            LivroDemo.Preco = 100;
            LivroDemo.Titulo = "The Winds of Winter";
            LivroDemo.Autor = "George R. R. Martin";
            LivroDemo.Altura = 10;
            LivroDemo.CodigoBarras = "1";
            LivroDemo.Comprimento = 20;
            LivroDemo.DtLancamento = DateTime.Today;
            LivroDemo.Edicao = 1;
            LivroDemo.Editora = "Aquela lá";
            LivroDemo.Estoque = 32;
            LivroDemo.Id = 1;
            LivroDemo.Isbn = "9783868200355";
            LivroDemo.Largura = 30;
            LivroDemo.Paginas = 20000;
            #endregion

            ped.Livros.Add(LivroDemo);

            ped2.Livros.Add(LivroDemo);

            ped3.Livros.Add(LivroDemo);

            ClienteDemo.Pedidos.Add(ped);

            AdminPedidoModel aped = new AdminPedidoModel
            {
                Codigo = "11",
                DtPedido = DateTime.Today,
                Status = (StatusPedidos)1
            };
            AdminPedidoModel aped2 = new AdminPedidoModel
            {
                Codigo = "12",
                DtPedido = DateTime.Today,
                Status = (StatusPedidos)6
            };
            AdminPedidoModel aped3 = new AdminPedidoModel
            {
                Codigo = "13",
                DtPedido = DateTime.Today,
                Status = (StatusPedidos)0
            };

            aped.Livros.Add(LivroDemo);

            aped2.Livros.Add(LivroDemo);

            aped3.Livros.Add(LivroDemo);

            PedidosDemo.Pedidos.Add(aped);
            PedidosDemo.Pedidos.Add(aped2);
            PedidosDemo.Pedidos.Add(aped3);

            PedidosDemo.Pedidos[0].Cliente = ClienteDemo;
            PedidosDemo.Pedidos[1].Cliente = ClienteDemo;
            PedidosDemo.Pedidos[2].Cliente = ClienteDemo;

            ClientesDemo.Clientes.Add((AdminClienteModel)ClienteDemo);
            ClientesDemo.Clientes.Add((AdminClienteModel)ClienteDemo);
            ClientesDemo.Clientes.Add((AdminClienteModel)ClienteDemo);

            ClientesDemo.Clientes[0].Inativo = false;

            Categoria = new AdminCategoriaModel
            {
                Id = 1,
                Nome = "Categoria",
                Inativo = false
            };


            LivroDemo.GrupoPreco = GrupoPreco;
        }
        */

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Clientes()
        {
            return View(ClientesDemo);
            
        }

        public IActionResult Pedidos()
        {
            return View(PedidosDemo);
        }

        public IActionResult ConfigLoja() {

            PaginaConfigLojaModel model = new PaginaConfigLojaModel
            {
                Livros = new List<AdminLivroModel> { LivroDemo, LivroDemo},
                Categorias = new List<CategoriaLivroModel> { Categoria, Categoria},
                GrupoPrecos = new List<AdminGrupoPrecoModel> { GrupoPreco, GrupoPreco}
            };

            return View(model);
        }

        #region Pedidos
        public IActionResult _AprovarPedidoPartial(int id) 
        {
            ViewBag.Operacao = "Aprovar";
            return PartialView("../Admin/PartialViews/_ProcessarPedidoPartial", PedidosDemo.Pedidos[0]);
        }

        public IActionResult AprovarPedido(int id)
        {
            return RedirectToAction(nameof(Pedidos));
        }

        public IActionResult _NegarPedidoPartial(int id)
        {
            ViewBag.Operacao = "Negar";
            return PartialView("../Admin/PartialViews/_ProcessarPedidoPartial", PedidosDemo.Pedidos[0]);
        }

        public IActionResult NegarPedido(int id)
        {
            return RedirectToAction(nameof(Pedidos));
        }

        public IActionResult _CancelarPedidoPartial(int id)
        {
            ViewBag.Operacao = "Cancelar";
            return PartialView("../Admin/PartialViews/_ProcessarPedidoPartial", PedidosDemo.Pedidos[0]);
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

        public IActionResult _VisualizarClientePartial(int id)
        {

            return PartialView("../Admin/PartialViews/_VisualizarClientePartial", ClienteDemo);
        }

        #endregion

        #region Config Loja

        #region Livros

        public IActionResult _AdicionarLivroPartial()
        {
            ViewBag.Operacao = "add";

            ConfigLojaLivroModel model = new ConfigLojaLivroModel();

            model.Categorias.Add(Categoria);
            model.GrupoPrecos.Add(GrupoPreco);

            return PartialView("../Admin/PartialViews/_ConfigLivroPartial", model);
        }

        [HttpPost]
        public IActionResult AdicionarLivro(ConfigLojaLivroModel configLoja)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _EntradaEstoqueLivroPartial(int id)
        {
            EntradaEstoqueModel estoque = new EntradaEstoqueModel
            {
                Autor = LivroDemo.Autor,
                CodigoBarras = "1",
                Titulo = LivroDemo.Titulo
            };
            return PartialView("../Admin/PartialViews/_EntradaEstoqueLivroPartial", estoque);
        }

        public IActionResult EntradaEstoque(EntradaEstoqueModel entrada)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _VisualizarLivroPartial(int id)
        {
            return PartialView("../Admin/PartialViews/_VisualizarLivroPartial", LivroDemo);
        }

        public IActionResult _EditarLivroPartial(int id)
        {
            ViewBag.Operacao = "edit";

            ConfigLojaLivroModel model = new ConfigLojaLivroModel();

            model.Livro = LivroDemo;

            model.Categorias.Add(Categoria);
            model.GrupoPrecos.Add(GrupoPreco);

            return PartialView("../Admin/PartialViews/_ConfigLivroPartial", model);
        }

        [HttpPost]
        public IActionResult EditarLivro(ConfigLojaLivroModel configLoja)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _InativarReativarLivroPartial(int id)
        {
            InativarLivroModel model = new InativarLivroModel
            {
                CodigoBarras = id.ToString(),
                Inativo = false
            };
            ViewBag.Motivos = new List<MotivoInativacaoModel>();
            ViewBag.Motivos.Add(Motivo);
            return PartialView("../Admin/PartialViews/_InativarReativarLivroPartial", model);
        }

        [HttpPost]
        public IActionResult InativarReativarLivro(InativarLivroModel model)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        #endregion

        #region Categorias

        public IActionResult _AdicionarCategoriaPartial()
        {
            ViewBag.Operacao = "add";
            return PartialView("../Admin/PartialViews/_ConfigCategoriaPartial");
        }

        [HttpPost]
        public IActionResult AdicionarCategoria(CategoriaLivroModel categoria)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _EditarCategoriaPartial(int id)
        {
            ViewBag.Operacao = "edit";
            return PartialView("../Admin/PartialViews/_ConfigCategoriaPartial", Categoria);
        }

        [HttpPost]
        public IActionResult EditarCategoria(CategoriaLivroModel categoria)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _InativarReativarCategoriaPartial(int id)
        {
            return PartialView("../Admin/PartialViews/_InativarReativarCategoriaPartial", Categoria);
        }

        [HttpPost]
        public IActionResult InativarReativarCategoria(CategoriaLivroModel categoria)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        #endregion

        #region GrupoPreco

        public IActionResult _AdicionarGrupoPrecoPartial()
        {
            ViewBag.Operacao = "add";
            return PartialView("../Admin/PartialViews/_ConfigGrupoPrecoPartial");
        }

        [HttpPost]
        public IActionResult AdicionarGrupoPreco(AdminGrupoPrecoModel categoria)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _EditarGrupoPrecoPartial(int id)
        {
            ViewBag.Operacao = "edit";
            return PartialView("../Admin/PartialViews/_ConfigGrupoPrecoPartial", GrupoPreco);
        }

        [HttpPost]
        public IActionResult EditarGrupoPreco(AdminGrupoPrecoModel grupoPreco)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _InativarReativarGrupoPrecoPartial(int id)
        {
            return PartialView("../Admin/PartialViews/_InativarReativarGrupoPrecoPartial", GrupoPreco);
        }

        [HttpPost]
        public IActionResult InativarReativarGrupoPreco(AdminGrupoPrecoModel grupoPreco)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        #endregion

        #endregion

        #region Jsons

        public IActionResult _MaisVendidosMesJson() {

            string[] labels = new string[] { "Janeiro", "Fevereiro", "Março" };
            JsonData[] datasets = {
                new JsonData{ label ="Livro1", 
                            data = new int[]{100, 200, 150 }, 
                            backgroundColor = "rgba(94, 140, 95, 0.5)",
                            fill= true},
                new JsonData{ label ="Livro2", data = new int[]{50, 20, 100 }, backgroundColor = "rgba(140, 94, 95, 0.5)"},
                new JsonData{ label ="Livro3", data = new int[]{123, 52, 231 }, backgroundColor = "rgba(95, 94, 140, 0.5)"},
            };
            JsonChart chart = new JsonChart
            {
                labels = labels,
                datasets = datasets
            };

            return Json(chart);

        }

        public IActionResult _VendasMesJson()
        {

            string[] labels = new string[] { "Janeiro", "Fevereiro", "Março" };
            JsonData[] datasets = {
                new JsonData{
                    label ="Livro1", 
                    data = new int[]{100, 200, 150 }, 
                    backgroundColor = "rgba(94, 140, 95, 0.5)",
                    fill = false},
                new JsonData{ 
                    label ="Livro2", 
                    data = new int[]{50, 20, 100 }, 
                    backgroundColor = "rgba(140, 94, 95, 0.5)",
                    fill = false},
                new JsonData{ 
                    label ="Livro3", 
                    data = new int[]{123, 52, 231 }, 
                    backgroundColor = "rgba(95, 94, 140, 0.5)",
                    fill = false},
            };
            JsonChart chart = new JsonChart
            {
                labels = labels,
                datasets = datasets
            };

            return Json(chart);
        }

        #endregion

    }
}
