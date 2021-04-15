using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class PaginaLoginModel : IViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Senha { get; set; }

        public bool Falhou { get; set; }

    }
}
