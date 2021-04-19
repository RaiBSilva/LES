using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using LES.Models.ViewModel.Livros;
using LES.Models.ViewModel.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LES.Controllers
{
    public class LivrosController : BaseController
    {

        public PaginaLojaModel LojaModel { get; set; }

        public IActionResult Loja()
        {
            return View();
        }

        public IActionResult Pesquisa(string titulo, string autor, string isbn, string editora, 
            double precoMin, double precoMax, string Categorias, int? pagina) 
        {
            return PartialView("ListaLivrosCardPartial");
        }

        public IActionResult Descricao(int id)
        {
            return View();
        }
    }
}