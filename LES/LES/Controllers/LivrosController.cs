using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Models.ViewModel.Livros;
using LES.Models.ViewModel.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LES.Controllers
{
    public class LivrosController : Controller
    {

        public PaginaLojaModel LojaModel { get; set; }

        public IActionResult Loja()
        {
            LojaModel = new PaginaLojaModel();
            LojaModel.Livros = new List<LivroCardModel>();

            var livro = new LivroCardModel();

            livro.CodigoBarras = "1";
            livro.Sinopse = "The Winds of Winter (Os Ventos do Inverno) é o sexto livro de As Crônicas de Gelo e Fogo, de George R. R. Martin.";
            livro.Preco = 100;
            livro.Titulo = "The Winds of Winter";

            LojaModel.Livros.Add(livro);
            LojaModel.Livros.Add(livro);
            LojaModel.Livros.Add(livro);
            LojaModel.Livros.Add(livro);
            LojaModel.Livros.Add(livro);

            return View(LojaModel);
        }

        public IActionResult Descricao(int id)
        {
            return View();
        }
    }
}