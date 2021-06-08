using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class FiltrosCodigoPromoModel : IViewModel
    {

        public int Id { get; set; }
        public string Codigo { get; set; }
        public double ValorMin { get; set; }
        public double ValorMax { get; set; }
        public bool IncluiInativos { get; set; }
        public int PagAtual { get; set; }
    }
}
