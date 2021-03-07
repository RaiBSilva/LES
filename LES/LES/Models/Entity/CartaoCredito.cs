using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public enum BandeiraCartaoCredito
    {
        VISA,
        Mastercard,
        Elo,
        Hipercard,
        [Display(Name = "Diners Club")]
        DinersClub,
        [Display(Name = "American Express")]
        AmericanExpress,
    }

    public class CartaoCredito
    {

        public string Codigo { get; set; }
        public string Cvv { get; set; }
        public DateTime Vencimento { get; set; }
        public BandeiraCartaoCredito Bandeira { get; set; }

    }
}
