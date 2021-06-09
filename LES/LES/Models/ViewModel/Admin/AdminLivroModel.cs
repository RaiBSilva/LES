using LES.Models.Entity;
using LES.Models.ViewModel.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class AdminLivroModel : LivroBaseModel, IViewModel
    {
        public int Estoque { get; set; }
        public int Id { get; set; }
        public bool Inativo { get; set; }
        public GrupoPrecoModel GrupoPreco { get; set; } = new GrupoPrecoModel();

        [Display(Name ="Grupo de preços")]
        public int GrupoPrecoId { get; set; }
        [Display(Name ="Categorias")]
        public int[] CategoriasIds { get; set; }
        public IFormFile Capa { get; set; }

        public IList<GrupoPreco> SelectGrupoPrecos { get; set; }
        public IList<CategoriaLivro> SelectCategorias { get; set; } 

    }
}
