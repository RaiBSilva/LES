using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Controllers
{
    public class AdministradorController : Controller
    {
        public IActionResult ListagemClientes()
        {
            return View();
        }
    }
}
