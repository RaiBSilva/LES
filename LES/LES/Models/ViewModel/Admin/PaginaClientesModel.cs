using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class PaginaClientesModel : IViewModel
    {
        public FiltrosClientesModel Filtros { get; set; } = new FiltrosClientesModel();

        public ListaClientesModel Clientes { get; set; } = new ListaClientesModel();

    }
}
