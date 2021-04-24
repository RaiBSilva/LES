using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.ClienteStrategy
{
    public class ValidarCepStrategy : IStrategy
    {
        
        public string Validar(EntidadeDominio e)
        {
            Cliente cliente = (Cliente)e;

            List<Endereco> listEnderecos = (List<Endereco>)cliente.Enderecos;

            foreach (Endereco end in listEnderecos)
            {
                if (end.Cep.Length != 8) return "O CEP deve possuir exatos oito dígitos.";
            }

            return "";
        }
    }
}
