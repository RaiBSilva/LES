using LES.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models
{
    interface IDominio
    {

        public IViewModel ToViewModel();

    }
}
