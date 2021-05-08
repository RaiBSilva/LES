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

            bool invalido = false;

            foreach(var cartao in cliente.Cartoes) { 
                DateTime dataVencimento = cartao.DtCadastro;
                DateTime dataAtual = DateTime.Now;

                if (dataAtual >= dataVencimento) invalido = true;
            }

            if (invalido) return "Data do cartão é inválida.";

            return "";
        }
    }
}
