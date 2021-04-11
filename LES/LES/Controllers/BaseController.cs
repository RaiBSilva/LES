using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Models.Entity;
using LES.Models.ViewHelpers;
using Microsoft.AspNetCore.Mvc;

namespace LES.Controllers
{
    public class BaseController : Controller
    {
        protected IViewHelper _vh { get; set; }

    }
}