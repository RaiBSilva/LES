using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.ClienteStrategy
{
    public class VerificaValidadeCartaoStrategy : IStrategy
    {
        public string Validar(EntidadeDominio e)
        {
            Cliente cliente = (Cliente)e;

            DateTime dataVencimento = cliente.Cartoes.FirstOrDefault().DtCadastro;
            DateTime dataAtual = DateTime.Now;

            if (dataAtual >= dataVencimento) return "Data do cartão é inválida.";

            return "";
        }
    }
}
