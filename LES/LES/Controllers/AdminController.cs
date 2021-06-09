using LES.Controllers.Facade;
using LES.Data.DAO;
using LES.Models.Entity;
using LES.Models.ViewHelpers.Admin;
using LES.Models.ViewModel.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
            IEnumerable<Cliente> clientes = _facade.ListAllInclude<Cliente>()
            .Where(c => !c.Inativo);

            _vh = new PaginaClientesViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Cliente>).FullName] = clientes.Take(10).ToList(),
                    [nameof(ListaClientesModel.PagAtual)] = 1,
                    [nameof(ListaClientesModel.PagMax)] = (clientes.Count() / 10) + 1
                }
            };

            if (TempData["Alert"] != null) ViewData["Alert"] = TempData["Alert"];

            return View(_vh.ViewModel);
        }

        public IActionResult Pedidos()
        {
            IEnumerable<Pedido> pedidos = _facade.ListAllInclude<Pedido>()
                .Where(p => p.Status != StatusPedidos.NaoFinalizado && !p.Inativo);

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
            IList<Livro> livros = _facade.ListAllInclude<Livro>().Where(l => !l.Inativo).ToList();
            IList<CategoriaLivro> categorias = _facade.Listar<CategoriaLivro>().Where(c => !c.Inativo).ToList();
            IList<GrupoPreco> grupos = _facade.Listar<GrupoPreco>().Where(c => !c.Inativo).ToList();
            IList<CodigoPromocional> codigos = _facade.Listar<CodigoPromocional>().Where(c => !c.Inativo).ToList();

            _vh = new PaginaConfigLojaViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Livro>).FullName] = livros,
                    [typeof(IList<CategoriaLivro>).FullName] = categorias,
                    [typeof(IList<GrupoPreco>).FullName] = grupos,
                    [typeof(IList<CodigoPromocional>).FullName] = codigos
                }
            };
            if (TempData["Alert"] != null) ViewData["Alert"] = TempData["Alert"];

            return View(_vh.ViewModel);
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


        [HttpPost]

        public IActionResult _ClientesBusca(string filtro)
        {
            JObject o = JObject.Parse(filtro);

            FiltrosClientesModel filtros = o.ToObject<FiltrosClientesModel>();

            IEnumerable<Cliente> clientes = _facade.ListAllInclude<Cliente>();

            if (!filtros.IncluiInativo)
                clientes = clientes.Where(c => !c.Inativo);

            if (filtros.Id != null && filtros.Id != 0)
                clientes = clientes.Where(c => c.Id == filtros.Id);

            if (!String.IsNullOrEmpty(filtros.Nome))
                clientes = clientes.Where(c => c.Nome.Contains(filtros.Nome));

            if (!String.IsNullOrEmpty(filtros.Email))
                clientes = clientes.Where(c => c.Usuario.Email.Contains(filtros.Email));

            if (filtros.PagAtual > 0)
                clientes = clientes.Skip((filtros.PagAtual - 1) * 10);

            _vh = new PaginaClientesViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Cliente>).FullName] = clientes.Take(10).ToList(),
                    [nameof(ListaClientesModel.PagAtual)] = 1,
                    [nameof(ListaClientesModel.PagMax)] = (clientes.Count() / 10) + 1
                }
            };

            PaginaClientesModel vm = (PaginaClientesModel)_vh.ViewModel;
            vm.Filtros = filtros;

            return PartialView("../Admin/PartialViews/_TabelaClientesPartial", vm);
        }

        public IActionResult _InativarReativarClientePartial(string id) {
            Cliente clienteDb = _facade.Query<Cliente>(c => c.Codigo == id,
                c => c,
                c => c.Usuario).FirstOrDefault();

            _vh = new AdminClienteViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Cliente).Name] = clienteDb
                }
            };

            return PartialView("../Admin/PartialViews/_InativarReativarClientePartial", _vh.ViewModel);
        }

        public IActionResult InativarReativarCliente(string id)
        {
            Cliente clienteDb = _facade.Query<Cliente>(c => c.Codigo == id,
                c => c,
                c => c.Usuario).FirstOrDefault();
            clienteDb.Inativo = !clienteDb.Inativo;
            string msg = _facade.Editar(clienteDb);

            if (!String.IsNullOrEmpty(msg))
                TempData["Alert"] = msg;
            return RedirectToAction(nameof(Clientes));
        }

        public IActionResult _VisualizarClientePartial(string id)
        {
            Cliente clienteDb = _facade.Query<Cliente>(c => c.Codigo == id,
                c => c,
                c => c.Usuario).FirstOrDefault();
            clienteDb = _facade.GetAllInclude(clienteDb);

            _vh = new AdminClienteViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Cliente).Name] = clienteDb
                }
            };

            return PartialView("../Admin/PartialViews/_VisualizarClientePartial", _vh.ViewModel);
        }

        #endregion

        #region Config Loja

        #region Livros

        public IActionResult _AdicionarLivroPartial()
        {
            ViewBag.Operacao = "add";

            AdminLivroModel vm = new AdminLivroModel { 
                DtLancamento = DateTime.Now, 
                SelectGrupoPrecos = _facade.Listar<GrupoPreco>(),
                SelectCategorias = _facade.Listar<CategoriaLivro>()
            };

            foreach(var item in vm.SelectGrupoPrecos)
            {
                item.Nome += $" (Margem de {item.MargemLucro}%)";
            }

            return PartialView("../Admin/PartialViews/_ConfigLivroPartial", vm);
        }

        [HttpPost]
        public IActionResult AdicionarLivro(AdminLivroModel livro)
        {
            _vh = new AdminLivroViewHelper { ViewModel = livro };

            Livro livroNovo = (Livro)_vh.Entidades[typeof(Livro).Name];
            Editora editora = _facade.Query<Editora>(e => e.Nome == livroNovo.Editora.Nome,
                e => e).FirstOrDefault();
            if(editora != null)
            {
                livroNovo.Editora = editora;
            }
            GrupoPreco grp = _facade.GetEntidade(new GrupoPreco { Id = livroNovo.GrupoPrecoId });

            livroNovo.CodigoBarras = GeraCodigoLivro();
            if(livroNovo.Capa == null)
            {
                livroNovo.Capa = new byte[0];
            }

            livroNovo.Inativo = true;

            string msg = _facade.Cadastrar(livroNovo);

            if (!String.IsNullOrEmpty(msg))
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _EntradaEstoqueLivroPartial(string cod)
        {
            Livro l = _facade.GetAllInclude(new Livro { CodigoBarras = cod });

            _vh = new EntradaEstoqueViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Livro).Name] = l
                }
            };

            return PartialView("../Admin/PartialViews/_EntradaEstoqueLivroPartial", _vh.ViewModel);
        }

        public IActionResult EntradaEstoque(EntradaEstoqueModel entrada)
        {
            Livro l = _facade.GetAllInclude(new Livro { CodigoBarras = entrada.CodigoBarras });

            #region
            if (entrada.Quantia == 0)
            {
                TempData["Alert"] = "Quantia numa entrada de estoque não pode ser 0.";
                RedirectToAction(nameof(ConfigLoja));
            }
            if (String.IsNullOrEmpty(entrada.Fornecedor))
            {
                TempData["Alert"] = "Fornecedor não pode ser vazio";
                RedirectToAction(nameof(ConfigLoja));
            }
            if(entrada.Custo <= 0)
            {
                TempData["Alert"] = "Custo deve ser um valor válido.";
                RedirectToAction(nameof(ConfigLoja));
            }
            #endregion

            if(l.MaiorCusto < entrada.Custo)
            {
                l.MaiorCusto = entrada.Custo;
                l.Valor = entrada.Custo + entrada.Custo * (l.GrupoPreco.MargemLucro / 100);
            }

            l.Estoque += entrada.Quantia;
            string msg = _facade.Editar(l);

            if (!string.IsNullOrEmpty(msg))
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _VisualizarLivroPartial(string cod)
        {
            Livro l = _facade.GetAllInclude(new Livro { CodigoBarras = cod});

            _vh = new AdminLivroViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Livro).Name] = l
                }
            };

            return PartialView("../Admin/PartialViews/_VisualizarLivroPartial", _vh.ViewModel);
        }

        public IActionResult _EditarLivroPartial(string cod)
        {
            ViewBag.Operacao = "edit";

            Livro l = _facade.GetAllInclude(new Livro { CodigoBarras = cod });

            _vh = new AdminLivroViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Livro).Name] = l
                }
            };

            AdminLivroModel vm = (AdminLivroModel)_vh.ViewModel;

            vm.SelectCategorias = _facade.Listar<CategoriaLivro>();
            vm.SelectGrupoPrecos = _facade.Listar<GrupoPreco>();

            foreach (var item in vm.SelectGrupoPrecos)
            {
                item.Nome += $" (Margem de {item.MargemLucro}%)";
            }

            return PartialView("../Admin/PartialViews/_ConfigLivroPartial", vm);
        }

        [HttpPost]
        public IActionResult EditarLivro(AdminLivroModel livro)
        {
            _vh = new AdminLivroViewHelper { ViewModel = livro };

            Livro ln = (Livro)_vh.Entidades[typeof(Livro).Name];
            Livro l = _facade.GetAllInclude(ln);
            Editora editora = _facade.Query<Editora>(e => e.Nome == ln.Editora.Nome,
                e => e).FirstOrDefault();
            if (editora == null)
            {
                ln.Editora = editora;
            }

            l.Altura = ln.Altura;
            l.Autor = ln.Autor;
            l.Comprimento = ln.Comprimento;
            l.DtLancamento = ln.DtLancamento;
            l.Edicao = ln.Edicao;
            l.Editora = ln.Editora;
            l.GrupoPrecoId = ln.GrupoPrecoId;
            l.Isbn = ln.Isbn;
            l.Largura = ln.Largura;
            l.Paginas = ln.Paginas;
            l.Peso = ln.Peso;
            l.Sinopse = ln.Sinopse;
            l.Titulo = ln.Titulo;
            l.Valor = ln.Valor;
            GrupoPreco grp = _facade.GetEntidade(new GrupoPreco { Id = ln.GrupoPrecoId });
            if (l.Valor < l.MaiorCusto + (l.MaiorCusto * (grp.MargemLucro/100)) &&
                !HttpContext.User.IsInRole("2"))
            {
                var valMin = l.MaiorCusto + l.MaiorCusto * (grp.MargemLucro / 100);
                TempData["Alert"] = "Você tentou inserir um valor inferior a margem de lucro desse livro. A margem de lucro" +
                    $" do grupo de preço {grp.Nome} é {grp.MargemLucro}%, logo o preço mínimo deste livro é {valMin}. Tente novamente.";
                return RedirectToAction(nameof(ConfigLoja));
            }

            string msg = _facade.Editar(l);

            if (!String.IsNullOrEmpty(msg))
                TempData["Alert"] = msg;
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _InativarReativarLivroPartial(string cod)
        {

            Livro l = _facade.GetAllInclude(new Livro { CodigoBarras = cod });

            InativarLivroModel model = new InativarLivroModel
            {
                CodigoBarras = l.CodigoBarras,
                Inativo = !l.Inativo,
                CategoriasAtivacao = _facade.Listar<CategoriaAtivacao>(),
                CategoriasInativacao = _facade.Listar<CategoriaInativacao>()
            };

            return PartialView("../Admin/PartialViews/_InativarReativarLivroPartial", model);
        }

        [HttpPost]
        public IActionResult InativarReativarLivro(InativarLivroModel model)
        {
            Livro l = _facade.GetAllInclude(new Livro { CodigoBarras = model.CodigoBarras});
            string msg;

            if (l.Inativo)
            {
                l.Inativo = !l.Inativo;
                Ativacao a = new Ativacao { CategoriaId = model.Motivo, Livro = l};
                msg = _facade.Cadastrar(a);
            }
            else
            {
                l.Inativo = !l.Inativo;
                Inativacao i = new Inativacao { CategoriaId = model.Motivo, Livro = l };
                msg = _facade.Cadastrar(i);
            }

            if (!String.IsNullOrEmpty(msg))
                TempData["Alert"] = msg;
            return RedirectToAction(nameof(ConfigLoja));
        }

        [HttpPost]
        public IActionResult _LivrosBusca(string json) 
        {
            JObject o = JObject.Parse(json);

            FiltrosAdminLivroModel f = o.ToObject<FiltrosAdminLivroModel>();

            IEnumerable<Livro> livros = _facade.ListAllInclude<Livro>();

            livros = f.Id != 0 ? livros.Where(t => t.Id == f.Id) : livros;

            if (!String.IsNullOrEmpty(f.TituloAutor))
            {
                livros = livros.Where(l => l.Titulo
                .Contains(f.TituloAutor))
                .Concat(livros
                    .Where(l => l.Autor.Contains(f.TituloAutor))
                .Distinct());
            }

            if (!String.IsNullOrEmpty(f.Categorias))
            {
                string[] ctgs = f.Categorias.Split(" ");
                IEnumerable<CategoriaLivro> categoriaLivros = _facade.Query<CategoriaLivro>(c => ctgs.Contains(c.Nome),
                    c => c);

                IEnumerable<LivroCategoriaLivro> livCtl = livros.SelectMany(c => c.LivrosCategoriaLivros);

                IEnumerable<int> ids = livCtl.Where(l => categoriaLivros.Select(c => c.Id).Contains(l.CategoriaLivroId))
                    .Select(l => l.LivroId).Distinct();

                livros = livros.Where(l => ids.Contains(l.Id));
            }

            livros = f.ValorMin > 0 ?
                livros.Where(l => l.Valor > f.ValorMin) : livros;

            livros = f.ValorMax > 0 ?
                livros.Where(l => l.Valor < f.ValorMax) : livros;

            livros = f.IncluiInativos ?
                livros : livros.Where(l => !l.Inativo);

            livros = f.PagAtual > 0 ? livros.Skip((f.PagAtual - 1) * 10) : livros;

            _vh = new ListaAdminLivroViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Livro>).FullName] = livros.Take(10).ToList(),
                    [nameof(ListaAdminLivroModel.PagAtual)] = 1,
                    [nameof(ListaAdminLivroModel.PagMax)] = (livros.Count() / 10) + 1
                }
            };

            ListaAdminLivroModel vm = (ListaAdminLivroModel)_vh.ViewModel;
            vm.Filtros = f;

            return PartialView("../Admin/PartialViews/_TabelaLivrosConfigPartial", vm);
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
            _vh = new CategoriaLivroViewHelper
            {
                ViewModel = categoria
            };

            CategoriaLivro ctgNova = (CategoriaLivro)_vh.Entidades[typeof(CategoriaLivro).Name];
            string msg = _facade.Cadastrar(ctgNova);

            if (!String.IsNullOrEmpty(msg))
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _EditarCategoriaPartial(int id)
        {
            ViewBag.Operacao = "edit";

            CategoriaLivro ctg = _facade.GetEntidade(new CategoriaLivro { Id = id });
            _vh = new CategoriaLivroViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(CategoriaLivro).Name] = ctg
                }
            };

            return PartialView("../Admin/PartialViews/_ConfigCategoriaPartial", _vh.ViewModel);
        }

        [HttpPost]
        public IActionResult EditarCategoria(CategoriaLivroModel categoria)
        {
            _vh = new CategoriaLivroViewHelper
            {
                ViewModel = categoria
            };

            CategoriaLivro ctgNova = (CategoriaLivro)_vh.Entidades[typeof(CategoriaLivro).Name];
            CategoriaLivro ctgDb = _facade.GetEntidade(ctgNova);

            ctgDb.Nome = ctgNova.Nome;

            string msg = _facade.Editar(ctgDb);

            if (!String.IsNullOrEmpty(msg))
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _InativarReativarCategoriaPartial(int id)
        {
            CategoriaLivro ctg = _facade.GetEntidade(new CategoriaLivro { Id = id });
            _vh = new CategoriaLivroViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(CategoriaLivro).Name] = ctg
                }
            };
            return PartialView("../Admin/PartialViews/_InativarReativarCategoriaPartial", _vh.ViewModel);
        }

        [HttpPost]
        public IActionResult InativarReativarCategoria(int id)
        {
            CategoriaLivro ctgDb = _facade.GetEntidade(new CategoriaLivro { Id = id });

            ctgDb.Inativo = !ctgDb.Inativo; 

            string msg = _facade.Editar(ctgDb);

            if (!String.IsNullOrEmpty(msg))
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(ConfigLoja));
        }

        [HttpPost]
        public IActionResult _CategoriasBusca(string json)
        {
            JObject o = JObject.Parse(json);

            FiltrosCategoriasModel f = o.ToObject<FiltrosCategoriasModel>();

            IEnumerable<CategoriaLivro> ctgs = _facade.Listar<CategoriaLivro>();

            ctgs = f.Id != 0 ? ctgs.Where(t => t.Id == f.Id) : ctgs;

            ctgs = !string.IsNullOrEmpty(f.Nome) ?
                ctgs.Where(c => c.Nome.Contains(f.Nome)) : ctgs;

            ctgs = f.IncluiInativados ?
                ctgs : ctgs.Where(l => !l.Inativo);

            ctgs = f.PagAtual > 0 ? ctgs.Skip((f.PagAtual - 1) * 10) : ctgs;

            _vh = new ListaCategoriaLivroViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Livro>).FullName] = ctgs.Take(10).ToList(),
                    [nameof(ListaCategoriaLivroModel.PagAtual)] = 1,
                    [nameof(ListaCategoriaLivroModel.PagMax)] = (ctgs.Count() / 10) + 1
                }
            };

            ListaCategoriaLivroModel vm = (ListaCategoriaLivroModel)_vh.ViewModel;
            vm.Filtros = f;

            return PartialView("../Admin/PartialViews/_TabelaCategoriasConfigPartial", vm);
        }

        #endregion

        #region GrupoPreco

        public IActionResult _AdicionarGrupoPrecoPartial()
        {
            ViewBag.Operacao = "add";
            return PartialView("../Admin/PartialViews/_ConfigGrupoPrecoPartial");
        }

        [HttpPost]
        public IActionResult AdicionarGrupoPreco(GrupoPrecoModel grp)
        {
            _vh = new GrupoPrecoViewHelper
            {
                ViewModel = grp
            };

            GrupoPreco grpNovo = (GrupoPreco)_vh.Entidades[typeof(GrupoPreco).Name];
            string msg = _facade.Cadastrar(grpNovo);

            if (!String.IsNullOrEmpty(msg))
                TempData["Alert"] = msg;
            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _EditarGrupoPrecoPartial(int id)
        {
            GrupoPreco grp = _facade.GetEntidade(new GrupoPreco { Id = id });
            _vh = new GrupoPrecoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(GrupoPreco).Name] = grp
                }
            };

            ViewBag.Operacao = "edit";

            return PartialView("../Admin/PartialViews/_ConfigGrupoPrecoPartial", _vh.ViewModel);
        }

        [HttpPost]
        public IActionResult EditarGrupoPreco(GrupoPrecoModel grp)
        {
            _vh = new GrupoPrecoViewHelper
            {
                ViewModel = grp
            };

            GrupoPreco grpNovo = (GrupoPreco)_vh.Entidades[typeof(GrupoPreco).Name];
            GrupoPreco grpDb = _facade.GetAllInclude(grpNovo);

            //Calcula novos preços baseados na margem de lucro
            foreach(var livro in grpDb.Livros)
            {
                if (livro.MaiorCusto.HasValue)
                {
                    double custo = livro.MaiorCusto ?? 0;
                    livro.Valor = custo * grpDb.MargemLucro;
                }
                else
                {
                    livro.Inativo = true;
                }
            }

            string msg = _facade.Editar(grpDb);

            if (!String.IsNullOrEmpty(msg))
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _InativarReativarGrupoPrecoPartial(int id)
        {
            GrupoPreco grp = _facade.GetEntidade(new GrupoPreco { Id = id });

            _vh = new GrupoPrecoViewHelper {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(GrupoPreco).Name] = grp
                }
            };

            return PartialView("../Admin/PartialViews/_InativarReativarGrupoPrecoPartial", _vh.ViewModel);
        }

        [HttpPost]
        public IActionResult InativarReativarGrupoPreco(int id)
        {
            GrupoPreco grpDb = _facade.GetAllInclude(new GrupoPreco { Id = id });

            if (!grpDb.Inativo)
                foreach (var livro in grpDb.Livros)
                {
                    livro.Inativo = true;
                    _facade.Cadastrar(new Inativacao { LivroId = livro.Id, CategoriaId = 2 });
                }

            grpDb.Inativo = !grpDb.Inativo;
            string msg = _facade.Editar(grpDb);

            return RedirectToAction(nameof(ConfigLoja));
        }

        [HttpPost]
        public IActionResult _GrupoPrecosBusca(string json)
        {
            JObject o = JObject.Parse(json);

            FiltrosGrupoPrecoModel f = o.ToObject<FiltrosGrupoPrecoModel>();

            IEnumerable<GrupoPreco> grps = _facade.Listar<GrupoPreco>();

            grps = f.Id != 0 ? grps.Where(t => t.Id == f.Id) : grps;

            grps = !string.IsNullOrEmpty(f.Nome) ?
                grps.Where(c => c.Nome.Contains(f.Nome)) : grps;

            grps = f.IncluiInativo ?
                grps : grps.Where(l => !l.Inativo);

            grps = f.MargemMin > 0 ?
                grps.Where(g => g.MargemLucro >= f.MargemMin) : grps;

            grps = f.MargemMax > 0 ?
                grps.Where(g => g.MargemLucro <= f.MargemMax) : grps;

            grps = f.PagAtual > 0 ? grps.Skip((f.PagAtual - 1) * 10) : grps;

            _vh = new ListaGrupoPrecoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<GrupoPreco>).FullName] = grps.Take(10).ToList(),
                    [nameof(ListaGrupoPrecoModel.PagAtual)] = 1,
                    [nameof(ListaGrupoPrecoModel.PagMax)] = (grps.Count() / 10) + 1
                }
            };

            ListaGrupoPrecoModel vm = (ListaGrupoPrecoModel)_vh.ViewModel;
            vm.Filtros = f;

            return PartialView("../Admin/PartialViews/_TabelaGrupoPrecosConfigPartial", vm);
        }

        #endregion

        #region CodigosPromocionais

        public IActionResult _AdicionarCodigoPromoPartial()
        {
            ViewBag.Operacao = "add";
            return PartialView("../Admin/PartialViews/_ConfigCodigoPromoPartial");
        }

        [HttpPost]
        public IActionResult AdicionarCodigoPromo(CodigoPromocional cod)
        {
            if (_facade.Query<CodigoPromocional>(c => c.Codigo == cod.Codigo, c => c).Count() > 0)
            {
                TempData["Alert"] = "Um código promocional com o código " + cod.Codigo + " já existe. Favor usar outro.";
                return RedirectToAction(nameof(ConfigLoja));
            }
            string msg = _facade.Cadastrar(cod);

            if (!String.IsNullOrEmpty(msg))
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _EditarCodigoPromoPartial(string cod)
        {
            ViewBag.Operacao = "edit";

            CodigoPromocional codigoPromo = _facade.Query<CodigoPromocional>(c => c.Codigo == cod, c => c).FirstOrDefault();

            return PartialView("../Admin/PartialViews/_ConfigCodigoPromoPartial", codigoPromo);
        }

        [HttpPost]
        public IActionResult EditarCodigoPromo(CodigoPromocional cod)
        {
            CodigoPromocional codDb = _facade.GetEntidade(cod);

            codDb.Valor = codDb.Valor;
            codDb.UsosRestantes = cod.UsosRestantes;

            string msg = _facade.Editar(codDb);

            if (!String.IsNullOrEmpty(msg))
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(ConfigLoja));
        }

        public IActionResult _InativarReativarCodigoPromoPartial(string cod)
        {
            CodigoPromocional codigoPromo = _facade.Query<CodigoPromocional>(c => c.Codigo == cod, c => c).FirstOrDefault();

            return PartialView("../Admin/PartialViews/_InativarReativarCodigoPartial", codigoPromo);
        }

        [HttpPost]
        public IActionResult InativarReativarCodigoPromo(string cod)
        {
            CodigoPromocional codigoPromo = _facade.Query<CodigoPromocional>(c => c.Codigo == cod, c => c).FirstOrDefault();

            codigoPromo.Inativo = !codigoPromo.Inativo;

            string msg = _facade.Editar(codigoPromo);

            if (!String.IsNullOrEmpty(msg))
                TempData["Alert"] = msg;

            return RedirectToAction(nameof(ConfigLoja));
        }

        [HttpPost]
        public IActionResult _CodigoPromoBusca(string json)
        {
            JObject o = JObject.Parse(json);

            FiltrosCodigoPromoModel f = o.ToObject<FiltrosCodigoPromoModel>();

            IEnumerable<CodigoPromocional> cdgs = _facade.Listar<CodigoPromocional>();

            cdgs = f.Id != 0 ? cdgs.Where(t => t.Id == f.Id) : cdgs;

            cdgs = !string.IsNullOrEmpty(f.Codigo) ?
                cdgs.Where(c => c.Codigo.Contains(f.Codigo)) : cdgs;

            cdgs = f.ValorMin > 0 ?
                cdgs.Where(c => c.Valor >= f.ValorMin) : cdgs;

            cdgs = f.ValorMax > 0 ?
                cdgs.Where(c => c.Valor <= f.ValorMax) : cdgs;

            cdgs = f.IncluiInativos ?
                cdgs : cdgs.Where(l => !l.Inativo);

            cdgs = f.PagAtual > 0 ? cdgs.Skip((f.PagAtual - 1) * 10) : cdgs;

            _vh = new ListaCodigosPromoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<CodigoPromocional>).FullName] = cdgs.Take(10).ToList(),
                    [nameof(ListaCodigosPromoModel.PagAtual)] = 1,
                    [nameof(ListaCodigosPromoModel.PagMax)] = (cdgs.Count() / 10) + 1
                }
            };

            ListaCodigosPromoModel vm = (ListaCodigosPromoModel)_vh.ViewModel;
            vm.Filtros = f;

            return PartialView("../Admin/PartialViews/_TabelaCodigosPromoConfigPartial", vm);
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
                        .Where(l => (dateTimeFormat.GetMonthName(l.DtCadastro.Month) == Month && l.DtCadastro.Year == Year)&&(l.Pedido.Status != StatusPedidos.NaoFinalizado))
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

        private string GeraCodigoLivro()
        {
            Random rnd = new Random();

            string chars = "0123456789";

            var codigo = new char[12];
            for(int i = 0; i < codigo.Length; i++)
                codigo[i] = chars[rnd.Next(chars.Length)];

            do
            {
                var items = _facade.Query<Livro>(
                    l => l.CodigoBarras == new string(codigo),
                    l => l);

                if (items.Count() == 0) return new string(codigo);
                for (int i = 0; i < codigo.Length; i++)
                    codigo[i] = chars[rnd.Next(chars.Length)];
            } while (true);
        }

        #endregion

    }
}
