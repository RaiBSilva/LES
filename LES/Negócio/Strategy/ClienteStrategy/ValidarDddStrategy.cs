using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.ClienteStrategy
{
    public class ValidarDddStrategy : IStrategy<EntidadeDominio>
    {
        public string Validar(EntidadeDominio e)
        {
            Cliente cliente = (Cliente)e;

            List<Telefone> listTelefones = (List<Telefone>)cliente.Telefones;

            foreach (Telefone tel in listTelefones)
            {
                if (tel.Ddd.Length != 3) return "O DDD deve ter três dígitos.";
            }

            return "";
        }
    }
}
