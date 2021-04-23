using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Shared
{
    public class ListaCardLivrosModel : IViewModel
    {
        public IList<LivroBaseModel> Livros { get; set; } = new List<LivroBaseModel>();

        public int PagAtual { get; set; }

        public int PagMax { get; set; }


    }
}
