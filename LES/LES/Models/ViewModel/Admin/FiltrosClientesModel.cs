using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class FiltrosClientesModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool IncluiInativo { get; set; } = false;
        public int PagAtual { get; set; }
    }
}
