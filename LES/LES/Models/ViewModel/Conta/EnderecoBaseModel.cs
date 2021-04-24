using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class EnderecoBaseModel : IViewModel
    {
        [Required]
        public string Logradouro { get; set; }

        public string Id { get; set; }

        [Required]
        [Display(Name = "Nº")]
        public string Numero { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Insira um CEP de sete dígitos.")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required]
        public string Complemento { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        [Required]
        [Display(Name = "Tipo de endereço")]
        public string TipoEndereco { get; set; }

        //Entidades de auxilio, não devem ser captadas
        public IList<TipoEndereco> TiposEnderecos { get; set; }

        public EnderecoBaseModel()
        {
            TiposEnderecos = new List<TipoEndereco>();
        }

    }
}
