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
        IFacadeCrud<Livro> _facadeLivro { get; set; }

        public ImagemController(IFacadeCrud<Livro> facadeLivro)
        {
            _facadeLivro = facadeLivro;
        }

        public IActionResult Livro(string codBar)
        {
            byte[] img = _facadeLivro.Query(l => l.CodigoBarras == codBar,
                l => l).FirstOrDefault().Capa;

            return File(img, "image/png");
        }

    }
}