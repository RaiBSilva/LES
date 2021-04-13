using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class BandeiraCartaoCredito : MetadadoBase
    {
        public virtual IList<CartaoCredito> Cartoes { get; set; }

        public BandeiraCartaoCredito() : base()
        {
            Cartoes = new List<CartaoCredito>();
        }

    }
}
