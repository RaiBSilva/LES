using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class CodigoPromocional : EntidadeDominio
    {
        public string Codigo { get; set; }
        public DateTime DtValidade { get; set; }
        public int UsosRestantes { get; set; }
        public double Valor { get; set; }

        public virtual IList<Pedido> Pedido { get; set; } = new List<Pedido>();
    }
}
