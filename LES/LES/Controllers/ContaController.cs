using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Mvc;

namespace LES.Views.Conta
{
    public class ContaController : Controller
    {
        //GET /Conta/Login
        public IActionResult Login()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Login(LoginModel usuario) 
        {
            return View();
        }

        //GET /Conta/Registro
        public IActionResult Registro() 
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Registro(RegistroModel usuarioNovo)
        {
            return View();
        }

        //Get /Conta/Editar
        public IActionResult Detalhes() 
        {
            return View();
        }
    }
}