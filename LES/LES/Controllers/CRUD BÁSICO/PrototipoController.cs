using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LES.Views.Protótipo
{
    public class PrototipoController : Controller
    {
        public IActionResult Loja()
        {
            return View();
        }
    }
}