using LES.Models.Entity;
using LES.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers
{
    public abstract class AbstractViewHelper : IViewHelper
    {

        public abstract IDictionary<string, EntidadeDominio> Entidades { get; set; }
        public abstract IViewModel ViewModel { get; set; }

        protected abstract void ToEntidade();

        protected abstract void ToViewModel(); 
    }
}
