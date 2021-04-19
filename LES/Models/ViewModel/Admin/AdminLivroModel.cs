using LES.Models.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class AdminLivroModel : LivroBaseModel
    {
        public int Estoque { get; set; }
        public int Id { get; set; }

        [Display(Name ="Grupo de preços")]
        public AdminGrupoPrecoModel GrupoPreco { get; set; }

    }
}
