using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class AdminClienteModel : PaginaDetalhesModel
    {
        public bool Inativo { get; set; }

        public AdminClienteModel() :base()
        {
            Inativo = false;
        }

    }
}
