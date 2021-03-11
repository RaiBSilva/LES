using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Views.Carrinho
{
    public class CarrinhoController : Controller
    {
        public IActionResult Carrinho()
        {
            return View();
        }
    }
}
