using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Livros
{
    public class LojaFiltrosModel : IViewModel
    {
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        public string Autor { get; set; }
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }
        public string Editora { get; set; }
        [Display(Name="Preço mínimo")]
        public double PrecoMin { get; set; }
        [Display(Name = "Preço máximo")]
        public double PrecoMax { get; set; }
        [Display(Name = "Data mínima")]
        public string DataMin { get; set; }
        [Display(Name = "Data máxima")]
        public string DataMax { get; set; }
        public string Categorias { get; set; }
        public int PaginaAtual { get; set; }

    }
}
