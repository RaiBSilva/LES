using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.ClienteStrategy
{
    public class ValidarCvvCartaoStrategy : IStrategy<EntidadeDominio>
    {
        public string Validar(EntidadeDominio e)
        {
            Cliente cliente = (Cliente)e;

            List<CartaoCredito> listCartoes = (List<CartaoCredito>)cliente.Cartoes;

            int numCvvChars = 0;

            Dictionary<string, int> relacaoBandeiras = new Dictionary<string, int>();
            relacaoBandeiras.Add("American Express", 4);

            foreach (CartaoCredito card in listCartoes)
            {
                if (!relacaoBandeiras.TryGetValue(card.Bandeira.Nome, out numCvvChars))
                {
                    numCvvChars = 3;
                }

                if (card.Cvv.Length != numCvvChars) return "O tamanho do Cvv é inválido.";
            }

            return "";
        }
    }
}
