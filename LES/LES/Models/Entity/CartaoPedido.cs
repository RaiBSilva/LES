using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class CartaoPedido : MuitosPMuitos
    {
        public int CartaoId { get; set; }
        public int PedidoId { get; set; }
        public double Valor { get; set; }

        public virtual CartaoCredito Cartao { get; set; }
        public virtual Pedido Pedido { get; set; }


    }
}
