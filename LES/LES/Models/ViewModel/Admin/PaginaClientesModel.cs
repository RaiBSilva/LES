using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class PaginaClientesModel
    {
        public IList<AdminClienteModel> Clientes { get; set; }

        public PaginaClientesModel()
        {
            Clientes = new List<AdminClienteModel>();
        }
    }
}
