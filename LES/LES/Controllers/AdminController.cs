using LES.Controllers.Facade;
using LES.Models.Entity;
using LES.Models.ViewHelpers.Admin;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Controllers
{
    [Authorize(Roles = "1,2")]
    public class AdminController : BaseController
    {
        IFacadeCrud<Pedido> _facadePedidos { get; set; }
        IFacadeCrud<Troca> _facadeTrocas { get; set; }

        public AdminController(
            IFacadeCrud<Pedido> facadePedidos,
            IFacadeCrud<Troca> facadeTrocas)
        {
            _facadePedidos = facadePedidos;
            _facadeTrocas = facadeTrocas;
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
            IEnumerable<Pedido> pedidos = _facadePedidos.ListAllInclude()
                .Where(p => p.Status != StatusPedidos.NaoFinalizado && !p.Inativo);

            IEnumerable<Troca> trocas = _facadeTrocas.ListAllInclude();

            _vh = new PaginaPedidosViewHelper 
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Pedido>).FullName] = pedidos.Take(10).ToList(),
                    [nameof(ListaPedidosAdminModel.PagAtual)] = 1,
                    [nameof(ListaPedidosAdminModel.PagMax)] = (pedidos.Count() / 10) + 1,
                    [typeof(IList<Troca>).FullName] = trocas.Take(10).ToList(),
                    [nameof(ListaTrocasAdminModel.PagAtual)] = 1,
                    [nameof(ListaTrocasAdminModel.PagMax)] = (trocas.Count() / 10) + 1
                }
            };

            if (TempData["Alert"] != null) ViewData["Alert"] = TempData["Alert"];

            return View(_vh.ViewModel);
        }

        public IActionResult ConfigLoja() {


            return View();
        }

        #region Pedidos

        [HttpPost]
        public IActionResult _PedidosBusca(string json)
        {
            JObject o = JObject.Parse(json);

            FiltrosPedidosAdminModel filtros = o.ToObject<FiltrosPedidosAdminModel>();

            IEnumerable<Pedido> pedidos = _facadePedidos.ListAllInclude()
                .Where(p => p.Status != StatusPedidos.NaoFinalizado && !p.Inativo);

            if (filtros.Id != null)
                pedidos = pedidos.Where(p => p.Id == filtros.Id);

            if (!String.IsNullOrEmpty(filtros.Nome))
                pedidos = pedidos.Where(p => p.Cliente.Nome.Contains(filtros.Nome));

            if (filtros.DtMin != null)
                pedidos = pedidos.Where(p => p.DtCadastro > filtros.DtMin);

            if (filtros.DtMax != null)
                pedidos = pedidos.Where(p => p.DtCadastro < filtros.DtMax);

            if (filtros.ValorMin > 0)
                pedidos = pedidos.Where(p => p.ValorTotal > filtros.ValorMin);

            if (filtros.ValorMax > 0)
                pedidos = pedidos.Where(p => p.ValorTotal < filtros.ValorMax);

            pedidos = !String.IsNullOrEmpty(filtros.Status) ?
                pedidos.Where(p => p.Status == (StatusPedidos)Convert.ToInt32(filtros.Status)) : pedidos;

            if (filtros.PagAtual > 0)
                pedidos = pedidos.Skip((filtros.PagAtual - 1) * 10);

            _vh = new PaginaPedidosViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Pedido>).FullName] = pedidos.Take(10).ToList(),
                    [nameof(ListaPedidosAdminModel.PagAtual)] = 1,
                    [nameof(ListaPedidosAdminModel.PagMax)] = (pedidos.Count() / 10) + 1
                }
            };

            PaginaPedidosModel vm = (PaginaPedidosModel)_vh.ViewModel;
            vm.Filtros = filtros;

            return PartialView();
        }

        public IActionResult _VisualizarPedidoPartial(int id)
        {
            _vh = new AdminPedidoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Pedido).Name] = _facadePedidos.GetAllInclude(new Pedido { Id = id })
                }
            };
            return PartialView("../Admin/PartialViews/_VisualizarPedidoPartial", _vh.ViewModel);
        }

        [HttpPost]
        public IActionResult StatusPedido(AdminPedidoModel pedido)
        {
            Pedido p = _facadePedidos.GetEntidade(new Pedido { Id = Convert.ToInt32(pedido.Id) });
            p.Status = pedido.Status;

            string msg = _facadePedidos.Editar(p);

            if (msg != null)
                TempData["Alert"] = msg;
            return RedirectToAction(nameof(Pedidos));
        }

        #endregion

        #region Troca    

        [HttpPost]
        public IActionResult _TrocasBusca(string json)
        {
            JObject o = JObject.Parse(json);

            FiltrosPedidosAdminModel filtros = o.ToObject<FiltrosPedidosAdminModel>();

            IEnumerable<Troca> trocas = _facadeTrocas.ListAllInclude();

            trocas = filtros.Id != null ? trocas.Where(t => t.Id == filtros.Id) : trocas;

            trocas = !String.IsNullOrEmpty(filtros.Nome) ? trocas.Where(t => t.Cliente.Nome.Contains(filtros.Nome)) : trocas;

            trocas = filtros.DtMin != null ? trocas.Where(t => t.DtCadastro > filtros.DtMin) : trocas;

            trocas = filtros.DtMax != null ? trocas.Where(t => t.DtCadastro < filtros.DtMax) : trocas;

            trocas = filtros.ValorMin > 0 ? trocas.Where(t => t.LivroPedido.Livro.Valor > filtros.ValorMin) : trocas;

            trocas = filtros.ValorMax > 0 ? trocas.Where(t => t.LivroPedido.Livro.Valor < filtros.ValorMax) : trocas;

            trocas = !String.IsNullOrEmpty(filtros.Status) ?
                trocas.Where(p => p.StatusTroca == (StatusTroca)Convert.ToInt32(filtros.Status)) : trocas;

            trocas = filtros.PagAtual > 0 ? trocas.Skip((filtros.PagAtual - 1) * 10) : trocas;

            _vh = new PaginaPedidosViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Troca>).FullName] = trocas.Take(10).ToList(),
                    [nameof(ListaTrocasAdminModel.PagAtual)] = 1,
                    [nameof(ListaTrocasAdminModel.PagMax)] = (trocas.Count() / 10) + 1
                }
            };

            PaginaPedidosModel vm = (PaginaPedidosModel)_vh.ViewModel;
            vm.Filtros = filtros;

            return PartialView();
        }

        public IActionResult _VisualizarTrocaPartial(int id)
        {
            _vh = new AdminTrocaViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Troca).Name] = _facadeTrocas.GetAllInclude(new Troca { Id = id })
                }
            };
            return PartialView("../Admin/PartialViews/_VisualizarPedidoPartial", _vh.ViewModel);
        }

        [HttpPost]
        public IActionResult StatusTroca(AdminTrocaModel troca)
        {
            Troca t = _facadeTrocas.GetAllInclude(new Troca { Id = troca.Id });
            t.StatusTroca = troca.Status;

            string msg = _facadeTrocas.Editar(t);

            if (msg != null)
                TempData["Alert"] = msg;
            return RedirectToAction(nameof(Pedidos));
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
