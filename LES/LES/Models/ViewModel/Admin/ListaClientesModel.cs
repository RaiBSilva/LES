using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class ListaClientesModel
    {
        public IList<AdminClienteModel> Clientes { get; set; } = new List<AdminClienteModel>();

        public int PagAtual { get; set; } = 1;

        public int PagMax { get; set; } = 1;

    }
}
