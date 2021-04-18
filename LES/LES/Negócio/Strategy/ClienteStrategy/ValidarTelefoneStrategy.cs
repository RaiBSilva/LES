using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.ClienteStrategy
{
    public class ValidarTelefoneStrategy : IStrategy<EntidadeDominio>
    {
        public string Validar(EntidadeDominio e)
        {
            Cliente cliente = (Cliente)e;

            List<Telefone> listTelefones = (List<Telefone>)cliente.Telefones;

            foreach (Telefone tel in listTelefones)
            {
                if (tel.Numero.Length != 8 && tel.Numero.Length != 9) return "Numero de telefone/celular inválido.";
            }

            return "";
        }
    }
}
