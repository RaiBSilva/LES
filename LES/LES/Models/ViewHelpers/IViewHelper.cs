﻿using LES.Models.Entity;
using LES.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers
{
    public interface IViewHelper
    {
        public IDictionary<string, EntidadeDominio> Entidades { get; set; }
        public ViewModel.IViewHelper ViewModel { get; set; }

    }
}
