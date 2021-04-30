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
        public AdminController()
        {

        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Clientes()
        {
            return View();
            
        }

        public IActionResult Pedidos()
        {
            return View();
        }

        public IActionResult ConfigLoja() {


            return View();
        }

        #region Pedidos
        public IActionResult _AprovarPedidoPartial(int id) 
        {
            ViewBag.Operacao = "Aprovar";
            return PartialView("../Admin/PartialViews/_ProcessarPedidoPartial");
        }

        public IActionResult AprovarPedido(int id)
        {
            return RedirectToAction(nameof(Pedidos));
        }

        public IActionResult _NegarPedidoPartial(int id)
        {
            ViewBag.Operacao = "Negar";
            return PartialView("../Admin/PartialViews/_ProcessarPedidoPartial");
        }

        public IActionResult NegarPedido(int id)
        {
            return RedirectToAction(nameof(Pedidos));
        }

        public IActionResult _CancelarPedidoPartial(int id)
        {
            ViewBag.Operacao = "Cancelar";
            return PartialView("../Admin/PartialViews/_ProcessarPedidoPartial");
        }

        public IActionResult CancelarPedido(int id)
        {
            return RedirectToAction(nameof(Pedidos));
        }

        public IActionResult _VisualizarPedidoPartial(int id)
        {
            return PartialView("../Admin/PartialViews/_VisualizarPedidoPartial");
        }

        #endregion

        #region Clientes

        public IActionResult _InativarReativarClientePartial(int id) {
            return PartialView("../Admin/PartialViews/_InativarReativarClientePartial");
        }

        public IActionResult InativarReativarCliente(int id)
        {
            return RedirectToAction(nameof(Pedidos));
        }

        public IActionResult _VisualizarClientePartial(int id)
        {

            return PartialView("../Admin/PartialViews/_VisualizarClientePartial");
        }

        #endregion

        #region Config Loja

        #region Livros

        public IActionResult _AdicionarLivroPartial()
        {
            ViewBag.Operacao = "add";

            return PartialView("../Admin/PartialViews/_ConfigLivroPartial");
        }

        [HttpPost]
        public IActionResult AdicionarLivro(ConfigLojaLivroModel configLoja)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _EntradaEstoqueLivroPartial(int id)
        {
            return PartialView("../Admin/PartialViews/_EntradaEstoqueLivroPartial");
        }

        public IActionResult EntradaEstoque(EntradaEstoqueModel entrada)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _VisualizarLivroPartial(int id)
        {
            return PartialView("../Admin/PartialViews/_VisualizarLivroPartial");
        }

        public IActionResult _EditarLivroPartial(int id)
        {
            ViewBag.Operacao = "edit";

            return PartialView("../Admin/PartialViews/_ConfigLivroPartial");
        }

        [HttpPost]
        public IActionResult EditarLivro(ConfigLojaLivroModel configLoja)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _InativarReativarLivroPartial(int id)
        {

            return PartialView("../Admin/PartialViews/_InativarReativarLivroPartial");
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
            return PartialView("../Admin/PartialViews/_ConfigCategoriaPartial");
        }

        [HttpPost]
        public IActionResult EditarCategoria(CategoriaLivroModel categoria)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _InativarReativarCategoriaPartial(int id)
        {
            return PartialView("../Admin/PartialViews/_InativarReativarCategoriaPartial");
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
            return PartialView("../Admin/PartialViews/_ConfigGrupoPrecoPartial");
        }

        [HttpPost]
        public IActionResult EditarGrupoPreco(AdminGrupoPrecoModel grupoPreco)
        {
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _InativarReativarGrupoPrecoPartial(int id)
        {
            return PartialView("../Admin/PartialViews/_InativarReativarGrupoPrecoPartial");
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
