using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.PedidoStrategy
{
    public class ValidarValorTotal : IStrategy
    {
        public string Validar(EntidadeDominio e)
        {
            Pedido p = (Pedido)e;

            double valorTotal = 0;

            foreach (var item in p.LivrosPedidos)
                valorTotal += item.Livro.Valor;

            if (p.Cupom != null)
                valorTotal -= p.Cupom.Valor;

            double valorCartoes = 0;

            foreach (var item in p.CartaoPedidos)
                valorCartoes += item.Valor;

            if (valorCartoes != valorTotal)
                return "A soma dos valores nos cartões não condiz com a soma total do pedido.";

            return "";
        }
    }
}
