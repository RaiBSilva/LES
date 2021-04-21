using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LES.Models.Entity;
using LES.Models.ViewHelpers;
using Microsoft.AspNetCore.Mvc;

namespace LES.Controllers
{
    public class BaseController : Controller
    {
        protected IViewHelper _vh { get; set; }

        protected Cliente GetClienteComEmail()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            Cliente cliente = new Cliente
            {
                Usuario = new Usuario
                {
                    Email = email
                }
            };

            return cliente;
        }

    }
}