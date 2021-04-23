using LES.Models.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Home
{
    public class PaginaIndexModel
    {
        public IList<LivroBaseModel> Livros { get; set; }
    }
}
