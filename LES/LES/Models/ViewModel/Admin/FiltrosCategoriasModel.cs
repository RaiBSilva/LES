using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class FiltrosCategoriasModel : IViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool IncluiInativados { get; set; }
        public int PagAtual { get; set; }
    }
}
