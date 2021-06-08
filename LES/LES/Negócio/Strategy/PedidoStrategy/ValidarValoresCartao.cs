using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.PedidoStrategy
{
    public class ValidarValoresCartao : IStrategy
    {
        public string Validar(EntidadeDominio e)
        {
            Pedido p = (Pedido)e;

            double valorTotal = 0;

            foreach (var item in p.LivrosPedidos)
                valorTotal += item.Livro.Valor;

            valorTotal += p.Frete;

            if (p.Cupom != null)
                valorTotal -= p.Cupom.Valor;

            if (valorTotal <= 10)
                return "";

            foreach (var item in p.CartaoPedidos)
                if (item.Valor <= 10)
                    return "Deve ser pago pelo menos 10 reais com cada cartão.\n";

            return "";
        }
    }
}
