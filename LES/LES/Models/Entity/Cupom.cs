using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Cupom : EntidadeDominio
    {

        public int ClienteId { get; set; }
        public string Codigo { get; set; }
        public double Valor { get; set; }

        public Cliente Cliente { get; set; }
        public Pedido Pedido { get; set; }

    }
}
