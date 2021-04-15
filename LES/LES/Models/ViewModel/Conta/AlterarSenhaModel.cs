using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class AlterarSenhaModel : SenhaBaseModel
    {
        public string Codigo { get; set; }
        [Display(Name ="Senha antiga")]

        [Required]
        public string VelhaSenha { get; set; }

    }
}
