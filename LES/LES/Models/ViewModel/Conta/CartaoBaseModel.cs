using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class CartaoBaseModel : IViewModel
    {
        public string Id { get; set; }

        //[Required]
        [Display(Name = "Nome Impresso no Cartão")]
        public string Nome { get; set; }
        //[Required]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        //[Required]
        [Display(Name = "CVV")]
        public string Cvv { get; set; }
        //[Required]
        [Display(Name = "Data de Vencimento")]
        public DateTime Vencimento { get; set; }
        //[Required]
        [Display(Name = "Bandeira do cartão")]
        public BandeiraCartaoCredito Bandeira { get; set; }

        //Entidades de auxilio, não devem ser captadas
        public IList<BandeiraCartaoCredito> Bandeiras { get; set; }

        public CartaoBaseModel()
        {
            Bandeiras = new List<BandeiraCartaoCredito>();
        }
    }
}
