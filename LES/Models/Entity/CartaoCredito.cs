using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class CartaoCredito : EntidadeDominio
    {
        public int BandeiraId { get; set; }
        public int ClienteId { get; set; }
        public string Codigo { get; set; }
        public string Cvv { get; set; }
        public bool EFavorito { get; set; }
        public string NomeImpresso { get; set; }
        public DateTime Vencimento { get; set; }

        public virtual BandeiraCartaoCredito Bandeira { get; set; }
        public virtual Cliente Cliente { get; set; }

        public CartaoCredito() : base()
        {
        }

    }
}
