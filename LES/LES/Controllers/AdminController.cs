using LES.Controllers.Facade;
using LES.Models.Entity;
using LES.Models.ViewHelpers.Admin;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Controllers
{
    [Authorize(Roles = "1,2")]
    public class AdminController : BaseController
    {
        IFacadeCrud _facade { get; set; }

        public AdminController(
            IFacadeCrud facade)
        {
            _facade = facade;
        }

        public IActionResult Home()
        {
            return View(new PaginaAdminHomeModel());
        }

        public IActionResult Clientes()
        {
            return View();
            
        }

        public IActionResult Pedidos()
        {
            IEnumerable<Pedido> pedidos = _facade.ListAllInclude<Pedido>()
                .Where(p => p.Status != StatusPedidos.NaoFinalizado && !p.Inativo).ToList();

            IEnumerable<Troca> trocas = _facade.ListAllInclude<Troca>();

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
        public IActionResult _PedidosBusca(string filtro)
        {
            JObject o = JObject.Parse(filtro);

            FiltrosPedidosAdminModel filtros = o.ToObject<FiltrosPedidosAdminModel>();

            IEnumerable<Pedido> pedidos = _facade.ListAllInclude<Pedido>()
                .Where(p => p.Status != StatusPedidos.NaoFinalizado && !p.Inativo);

            if (filtros.Id != null)
                pedidos = pedidos.Where(p => p.Id == filtros.Id);

            if (!String.IsNullOrEmpty(filtros.Nome))
                pedidos = pedidos.Where(p => p.Cliente.Nome.Contains(filtros.Nome));

            if (filtros.DtMin != null && filtros.DtMin != new DateTime())
                pedidos = pedidos.Where(p => p.DtCadastro > filtros.DtMin);

            if (filtros.DtMax != null && filtros.DtMax != new DateTime())
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

            return PartialView("../Admin/PartialViews/_TabelaPedidosPartial", vm);
        }

        public IActionResult _VisualizarPedidoPartial(int id)
        {
            _vh = new AdminPedidoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Pedido).Name] = _facade.GetAllInclude(new Pedido { Id = id })
                }
            };
            return PartialView("../Admin/PartialViews/_VisualizarPedidoPartial", _vh.ViewModel);
        }

        [HttpPost]
        public IActionResult StatusPedido(AdminPedidoModel pedido)
        {
            Pedido p = _facade.GetAllInclude(new Pedido { Id = Convert.ToInt32(pedido.Id) });
            p.Status = pedido.Status;

            string msg = _facade.Editar(p);

            if (msg != "")
                TempData["Alert"] = msg;
            return RedirectToAction(nameof(Pedidos));
        }

        #endregion

        #region Troca    

        [HttpPost]
        public IActionResult _TrocasBusca(string filtro)
        {
            JObject o = JObject.Parse(filtro);

            FiltrosPedidosAdminModel filtros = o.ToObject<FiltrosPedidosAdminModel>();

            IEnumerable<Troca> trocas = _facade.ListAllInclude<Troca>();

            trocas = filtros.Id != null ? trocas.Where(t => t.Id == filtros.Id) : trocas;

            trocas = !String.IsNullOrEmpty(filtros.Nome) ? 
                trocas.Where(t => t.Cliente.Nome.Contains(filtros.Nome)) : trocas;

            trocas = (filtros.DtMin != null && filtros.DtMin != new DateTime()) ? 
                trocas.Where(t => t.DtCadastro > filtros.DtMin) : trocas;

            trocas = (filtros.DtMax != null && filtros.DtMax != new DateTime()) ? 
                trocas.Where(t => t.DtCadastro < filtros.DtMax ) : trocas;

            trocas = filtros.ValorMin > 0 ? 
                trocas.Where(t => t.LivroPedido.Livro.Valor > filtros.ValorMin) : trocas;

            trocas = filtros.ValorMax > 0 ? 
                trocas.Where(t => t.LivroPedido.Livro.Valor < filtros.ValorMax) : trocas;

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

            return PartialView("../Admin/PartialViews/_TabelaTrocasPartial", vm);
        }

        public IActionResult _VisualizarTrocaPartial(int id)
        {
            _vh = new AdminTrocaViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Troca).Name] = _facade.GetAllInclude(new Troca { Id = id })
                }
            };
            return PartialView("../Admin/PartialViews/_VisualizarTrocaPartial", _vh.ViewModel);
        }

        [HttpPost]
        public IActionResult StatusTroca(AdminTrocaModel troca)
        {
            Troca t = _facade.GetAllInclude(new Troca { Id = troca.Id });
            t.StatusTroca = troca.Status;
            Cliente c = null;
            if (t.StatusTroca == Models.Entity.StatusTroca.Trocada)
            {
                c = _facade.GetAllInclude(t.Cliente);
                addCupom(c, t.LivroPedido);
            }

            string msg = _facade.Editar(t);
            if (c != null)
                msg += _facade.Editar(c);

            if (msg != "")
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
        [HttpPost]
        public IActionResult _VendasJson(string json)
        {
            PaginaAdminHomeModel model;
            JObject o;

            if (json == null)
                model = new PaginaAdminHomeModel();
            else
            {
                o = JObject.Parse(json);
                model = o.ToObject<PaginaAdminHomeModel>();
            }

            IEnumerable<Livro> livros = _facade.ListAllInclude<Livro>();
            IList<string> meses = new List<string>();

            if (!String.IsNullOrEmpty(model.Nome))
                livros = livros.Where(l => l.Titulo.Contains(model.Nome));

            if (!String.IsNullOrEmpty(model.Categorias))
            {
                string[] ctgs = model.Categorias.Split(" ");
                IEnumerable<CategoriaLivro> categoriaLivros = _facade.Query<CategoriaLivro>(c => ctgs.Contains(c.Nome),
                    c => c);

                IEnumerable<LivroCategoriaLivro> livCtl = livros.SelectMany(c => c.LivrosCategoriaLivros);

                IEnumerable<int> ids = livCtl.Where(l => categoriaLivros.Select(c => c.Id).Contains(l.CategoriaLivroId))
                    .Select(l => l.LivroId).Distinct();

                livros = livros.Where(l => ids.Contains(l.Id));
            }

            var listaMeses = MonthsBetween(model.Comeco, model.Fim);
            foreach (var (Month, Year) in listaMeses)
                meses.Add(Month + "/" + Year);

            IEnumerable<JsonData> dados = new List<JsonData>();

            IList<JsonData> listaDatasets = new List<JsonData>();
            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;

            foreach (var livro in livros)
            {
                Random r = new Random();

                string cor = "rgba(" + r.Next(0, 255) + ", " + r.Next(0, 255) + ", " + r.Next(0, 255) + ", 0.5)";

                JsonData dataset = new JsonData
                {
                    label = livro.Titulo,
                    backgroundColor = cor,
                    borderColor = cor,
                    fill = false
                };

                IList<int> data = new List<int>();
                foreach(var (Month, Year) in listaMeses)
                {
                    int contagem = livro.LivroPedidos
                        .Where(l => dateTimeFormat.GetMonthName(l.DtCadastro.Month) == Month && l.DtCadastro.Year == Year)
                        .Count();
                    data.Add(contagem);
                }

                dataset.data = data.ToArray();

                listaDatasets.Add(dataset); 
            }

            string[] labels = meses.ToArray();
            JsonData[] datasets = listaDatasets.ToArray();

            JsonChart chart = new JsonChart
            {
                labels = labels,
                datasets = datasets
            };

            return Json(chart);
        }

        #endregion

        #region Utilidades

        public void addCupom(Cliente c, LivroPedido l)
        {
            Cupom cupom = new Cupom { Cliente = c, Valor = l.Livro.Valor };

            Random rnd = new Random();

            while (true)
            {
                int codigo = rnd.Next(0, 1000000);
                var items = _facade.Query<Cupom>(
                    c => Convert.ToInt32(c.Codigo) == codigo,
                    c => c);

                if (items.Count() == 0) 
                { 
                    cupom.Codigo = codigo.ToString("D7");
                    break;
                }
                codigo = rnd.Next(0, 1000000); ;
            }

            c.Cupons.Add(cupom);
            l.Trocado = true;
        }

        public static IEnumerable<(string Month, int Year)> MonthsBetween(
        DateTime startDate,
        DateTime endDate)
        {
            DateTime iterator;
            DateTime limit;

            if (endDate > startDate)
            {
                iterator = new DateTime(startDate.Year, startDate.Month, 1);
                limit = endDate;
            }
            else
            {
                iterator = new DateTime(endDate.Year, endDate.Month, 1);
                limit = startDate;
            }

            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            while (iterator <= limit)
            {
                yield return (
                    dateTimeFormat.GetMonthName(iterator.Month),
                    iterator.Year
                );

                iterator = iterator.AddMonths(1);
            }
        }

        #endregion

    }
}
