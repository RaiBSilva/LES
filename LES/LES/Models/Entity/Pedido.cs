using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Pedido : EntidadeDominio
    {
        public int ClienteId { get; set; }
        public int? CupomId { get; set; }
        public int EnderecoId { get; set; }
        public StatusPedidos Status { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Cupom Cupom { get; set; }
        public virtual IList<CartaoPedido> CartaoPedidos { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual IList<LivroPedido> LivrosPedidos { get; set; }

    }
}
