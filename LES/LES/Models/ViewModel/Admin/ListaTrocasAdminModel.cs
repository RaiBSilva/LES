using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class ListaTrocasAdminModel : IViewModel
    {
        public IList<AdminTrocaModel> Trocas = new List<AdminTrocaModel>();

        public int PagAtual { get; set; } = 1;

        public int PagMax { get; set; } = 1;

    }
}
