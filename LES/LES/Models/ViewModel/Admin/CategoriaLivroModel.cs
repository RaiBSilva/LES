﻿using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class CategoriaLivroModel : IViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Inativo { get; set; }


    }
}
