using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.ClienteStrategy
{
    public class ValidarDataNascimentoStrategy : IStrategy
    {
        public string Validar(EntidadeDominio e)
        {
            Cliente cliente = (Cliente)e;

            DateTime dataNascimento = cliente.DtNascimento;
            DateTime dataAtual = DateTime.Now;

            if (dataNascimento >= dataAtual) return "Data de nascimento inválida.";

            return "";
        }
    }
}
