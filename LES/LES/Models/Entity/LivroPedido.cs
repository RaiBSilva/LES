using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class LivroPedido
    {
        public int LivroId { get; set; }
        public int PedidoId { get; set; }
        public bool Trocado { get; set; }

        public virtual Livro Livro { get; set; }
        public virtual Pedido Pedido { get; set; }

        public LivroPedido()
        {
            Livro = new Livro();
            Pedido = new Pedido();
        }

    }
}
