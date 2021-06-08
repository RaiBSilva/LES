using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class ListaCodigosPromoModel : IViewModel
    {

        public IList<CodigoPromocional> Codigos { get; set; } = new List<CodigoPromocional>();

        public int PagAtual { get; set; } = 1;
        public int PagMax { get; set; } = 1;
        public FiltrosCodigoPromoModel Filtros { get; set; } = new FiltrosCodigoPromoModel();

    }
}
