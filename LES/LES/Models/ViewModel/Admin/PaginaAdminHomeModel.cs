using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class PaginaAdminHomeModel : IViewModel
    {
        public string Nome { get; set; }
        public string Categorias { get; set; }
        public DateTime Comeco { get; set; } = new DateTime(2021, 04, 01);
        public DateTime Fim { get; set; } = DateTime.Now;

    }
}
