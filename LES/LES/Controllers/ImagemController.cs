using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Controllers.Facade;
using LES.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LES.Controllers
{
    public class ImagemController : Controller
    {
        IFacadeCrud _facade { get; set; }

        public ImagemController(IFacadeCrud facade)
        {
            _facade = facade;
        }

        public IActionResult Livro(string codBar)
        {
            byte[] img = _facade.Query<Livro>(l => l.CodigoBarras == codBar,
                l => l).FirstOrDefault().Capa;

            return File(img, "image/png");
        }

    }
}