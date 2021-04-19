using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class AdminGrupoPrecoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Margem de lucro")]
        public double MargemLucro { get; set; }
        public bool Inativo { get; set; }
    }
}
