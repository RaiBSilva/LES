using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.ClienteStrategy
{
    public class ValidarNumeroCartaoStrategy : IStrategy<EntidadeDominio>
    {
        public string Validar(EntidadeDominio e)
        {
            Cliente cliente = (Cliente)e;

            List<CartaoCredito> listCartoes = (List<CartaoCredito>)cliente.Cartoes;

            int numeroChars = 0;

            Dictionary<string, int> relacaoBandeiras = new Dictionary<string, int>();
            relacaoBandeiras.Add("American Express", 15);

            foreach (CartaoCredito card in listCartoes)
            {
                if (!relacaoBandeiras.TryGetValue(card.Bandeira.Nome, out numeroChars))
                {
                    numeroChars = 16;
                }

                if (card.Codigo.Length != numeroChars) return "Numero do cartão de tamanho inválido.";
            }

            return "";
        }
    }
}
