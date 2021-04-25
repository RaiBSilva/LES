using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using LES.Controllers.Facade;
using LES.Models.Entity;
using LES.Models.ViewHelpers.Livros;
using LES.Models.ViewHelpers.Shared;
using LES.Models.ViewModel.Livros;
using LES.Models.ViewModel.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json.Linq;

namespace LES.Controllers
{
    public class LivrosController : BaseController
    {
        
        IFacadeCrud<Livro> _facadeLivro { get; set; }
        IFacadeCrud<CategoriaLivro> _facadeCtgLivro { get; set; }

        public LivrosController(IFacadeCrud<Livro> facadeLivro,
            IFacadeCrud<CategoriaLivro> facadeCtgLivro)
        {
            _facadeLivro = facadeLivro;
            _facadeCtgLivro = facadeCtgLivro;
        }

        public IActionResult Loja()
        {
            IList<Livro> livros = _facadeLivro.ListAllInclude().OrderBy(l => l.Titulo).ToList();

            _vh = new PaginaLojaViewHelper 
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Livro>).Name] = livros.Take(8).ToList(),
                    [nameof(ListaCardLivrosModel.PagMax)] = (livros.Count / 10) + 1,
                    [nameof(ListaCardLivrosModel.PagAtual)] = 1
                }
            };

            if (TempData["Alert"] != null)
                ViewData["Alert"] = (string)TempData["Alert"];

            return View(_vh.ViewModel);
        }

        [HttpPost]
        public IActionResult Pesquisa(string filtro) 
        {

            JObject o = JObject.Parse(filtro);

            LojaFiltrosModel filtros = o.ToObject<LojaFiltrosModel>();

            IEnumerable<Livro> livros = _facadeLivro.ListAllInclude()
                .Where(l => l.Inativo == false)
                .OrderBy(l => l.Titulo);

            if (!String.IsNullOrEmpty(filtros.Titulo))
                livros = livros.Where(l => l.Titulo.Contains(filtros.Titulo));

            if (!String.IsNullOrEmpty(filtros.Autor))
                livros = livros.Where(l => l.Autor.Contains(filtros.Autor));

            if (!String.IsNullOrEmpty(filtros.Isbn))
                livros = livros.Where(l => l.Isbn.Contains(filtros.Isbn));

            if (!String.IsNullOrEmpty(filtros.Editora))
                livros = livros.Where(l => l.Editora.Nome.Contains(filtros.Editora));

            if (!String.IsNullOrEmpty(filtros.Categorias)) 
            {
                string[] ctgs = filtros.Categorias.Split(" ");
                IEnumerable<CategoriaLivro> categoriaLivros = _facadeCtgLivro.Query(c => ctgs.Contains(c.Nome),
                    c => c);

                IEnumerable<LivroCategoriaLivro> livCtl = livros.SelectMany(c => c.LivrosCategoriaLivros);

                IEnumerable<int> ids = livCtl.Where(l => categoriaLivros.Select(c => c.Id).Contains(l.CategoriaLivroId))
                    .Select(l => l.LivroId).Distinct();

                livros = livros.Where(l => ids.Contains(l.Id));
            }

            if (filtros.PrecoMin > 0)
                livros = livros.Where(l => l.Valor > filtros.PrecoMin);

            if (filtros.PrecoMax > 0)
                livros = livros.Where(l => l.Valor < filtros.PrecoMax);

            if (!String.IsNullOrEmpty(filtros.DataMin)) 
            {
                DateTime dataMin = Convert.ToDateTime(filtros.DataMin);
                livros = livros.Where(l => l.DtLancamento.Date >= dataMin.Date);
            }

            if (!String.IsNullOrEmpty(filtros.DataMax))
            {
                DateTime dataMax = Convert.ToDateTime(filtros.DataMax);
                livros = livros.Where(l => l.DtLancamento.Date <= dataMax.Date);
            }

            IList<Livro> listaLivro = livros.ToList();

            _vh = new ListaCardLivrosViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Livro>).Name] = listaLivro.Take(8).ToList(),
                    [nameof(ListaCardLivrosModel.PagAtual)] = filtros.PaginaAtual,
                    [nameof(ListaCardLivrosModel.PagMax)] = (listaLivro.Count / 10) + 1
                }
            };

            return PartialView("../Shared/_ListaLivrosCardPartial", _vh.ViewModel);
        }

        public IActionResult Descricao(string codBar)
        {
            Livro livro = _facadeLivro.GetAllInclude(new Livro { CodigoBarras = codBar });

            _vh = new LivroBaseViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Livro).Name] = livro
                }
            };

            return View(_vh.ViewModel);
        }
    }
}