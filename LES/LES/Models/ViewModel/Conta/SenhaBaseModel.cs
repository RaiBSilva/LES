using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class SenhaBaseModel : IViewModel
    {
        [Required]
        public string Senha { get; set; }
    }
}
