using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Troca : EntidadeDominio
    {
        public int ClienteId { get; set; }
        public int LivroPedidoId { get; set; }
        public StatusTroca StatusTroca { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual LivroPedido LivroPedido { get; set; }
    }
}
