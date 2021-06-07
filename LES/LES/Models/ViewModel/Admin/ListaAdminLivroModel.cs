using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class ListaAdminLivroModel : IViewModel
    {
        public IList<AdminLivroModel> Livros { get; set; } = new List<AdminLivroModel>();

        public int PagAtual { get; set; } = 1;
        public int PagMax { get; set; } = 1;
        public FiltrosAdminLivroModel Filtros { get; set; }


    }
}
