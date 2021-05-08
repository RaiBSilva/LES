using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class FiltrosPedidosAdminModel
    {

        public int? Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtMin { get; set; }
        public DateTime DtMax { get; set; }
        public double ValorMin { get; set; }
        public double ValorMax { get; set; }
        public string Status { get; set; }
        public int PagAtual { get; set; }

    }
}
