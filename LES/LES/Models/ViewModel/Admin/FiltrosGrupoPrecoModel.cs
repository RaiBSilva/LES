using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class FiltrosGrupoPrecoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double MargemMin { get; set; }
        public double MargemMax { get; set; }
        public bool IncluiInativo { get; set; }
    }
}
