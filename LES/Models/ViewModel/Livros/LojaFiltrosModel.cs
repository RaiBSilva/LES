using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Livros
{
    public class LojaFiltrosModel
    {
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        public string Autor { get; set; }
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }
        public string Editora { get; set; }
        [Display(Name="Preço mínimo")]
        public float PrecoMin { get; set; }
        [Display(Name = "Preço máximo")]
        public float PrecoMax { get; set; }
        public string Categorias { get; set; }

    }
}
