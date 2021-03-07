using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class EditarSenhaModel : SenhaBaseModel
    {
        //[Required]
        [Display(Name = "Senha antiga")]
        public string AntigaSenha { get; set; }

    }
}
