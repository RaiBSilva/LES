using LES.Models.ViewModel.Carrinho;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Views.Carrinho
{
    public class CarrinhoController : Controller
    {

        CarrinhoModel Model = new CarrinhoModel();

        public CarrinhoController()
        {
            Model.Livros = new List<CarrinhoLivroModel>();

            CarrinhoLivroModel livro = new CarrinhoLivroModel();

            livro.Titulo = "Winds of Winter";
            livro.Autor = "George R. R. Maritn";
            livro.Preco = 100;
            livro.Quantia = 3;

            Model.Livros.Add(livro);

        }

        public IActionResult Carrinho()
        {
            return View();
        }

        public IActionResult _CarrinhoPartial() 
        {
            return PartialView("_CarrinhoPartial", Model);
        }
    }
}
