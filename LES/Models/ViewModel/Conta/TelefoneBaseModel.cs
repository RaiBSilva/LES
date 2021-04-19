using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class TelefoneBaseModel: IViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Tipo de telefone")]
        public string TipoTelefone { get; set; }

        [Required]
        [Display(Name = "DDD")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Insira os três digitos do DDD.")]
        public string Ddd { get; set; }

        [Required]
        [Display(Name = "Número de telefone")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "Insira um telefone de oito ou nove dígitos.")]
        public string NumeroTelefone { get; set; }

        //Entidades de auxilio, não devem ser captadas
        public IList<TipoTelefone> TipoTelefones { get; set; }

        public TelefoneBaseModel()
        {
            TipoTelefones = new List<TipoTelefone>();
        }

    }
}
