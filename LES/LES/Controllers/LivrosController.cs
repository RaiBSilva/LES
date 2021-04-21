using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using LES.Controllers.Facade;
using LES.Models.Entity;
using LES.Models.ViewHelpers.Livros;
using LES.Models.ViewModel.Livros;
using LES.Models.ViewModel.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LES.Controllers
{
    public class LivrosController : BaseController
    {
        
        IFacadeCrud<Livro> _facadeLivro { get; set; }

        public LivrosController(IFacadeCrud<Livro> facadeLivro)
        {
            _facadeLivro = facadeLivro;
        }

        public IActionResult Loja()
        {
            IList<Livro> livros = _facadeLivro.Query(l => l.Inativo == false,
                l => l).OrderBy(l => l.Titulo).ToList();

            _vh = new PaginaLojaViewHelper 
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Livro>).Name] = livros.Take(10),
                    [nameof(ListaCardLivrosModel.PagMax)] = (livros.Count / 10) + 1,
                    [nameof(ListaCardLivrosModel.PagAtual)] = 1
                }
            };

            return View(_vh.ViewModel);
        }

        [HttpPost]
        public IActionResult Pesquisa(int pagina, string titulo="", string autor = "", string isbn = "", string editora = "", 
            string categorias = "", double precoMin = 0, double precoMax = 0) 
        {
            IList<Livro> livros = _facadeLivro.ListAllInclude()
                .Where(l => l.Inativo == false)
                .OrderBy(l => l.Titulo)
                .ToList();

            if (!String.IsNullOrEmpty(titulo))
                livros = livros.Where(l => l.Titulo.Contains(titulo)).ToList();

            if (!String.IsNullOrEmpty(autor))
                livros = livros.Where(l => l.Autor.Contains(autor)).ToList();

            if (!String.IsNullOrEmpty(isbn))
                livros = livros.Where(l => l.Isbn.Contains(isbn)).ToList();

            if (!String.IsNullOrEmpty(editora))
                livros = livros.Where(l => l.Editora.Nome.Contains(editora)).ToList();


            return PartialView("ListaLivrosCardPartial");
        }

        public IActionResult Descricao(int codBar)
        {
            return View();
        }
    }
}