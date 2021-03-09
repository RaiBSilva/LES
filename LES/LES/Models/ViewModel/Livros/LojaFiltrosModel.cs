using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Livros
{
    public class LojaFiltrosModel
    {

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Isbn { get; set; }
        public string Editora { get; set; }
        public float PrecoMin { get; set; }
        public float PrecoMax { get; set; }
        public Categorias Categoria { get; set; }

    }
}
