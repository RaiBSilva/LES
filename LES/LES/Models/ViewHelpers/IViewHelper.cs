using LES.Models.Entity;
using LES.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers
{
    public interface IViewHelper
    {
        public IDictionary<string, object> Entidades { get; set; }
        public IViewModel ViewModel { get; set; }

    }
}
