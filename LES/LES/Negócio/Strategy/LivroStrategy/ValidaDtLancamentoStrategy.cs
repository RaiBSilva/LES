using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.LivroStrategy
{
    public class ValidaDtLancamentoStrategy : IStrategy<EntidadeDominio>
    {
        public string Validar(EntidadeDominio e)
        {
            Livro book = (Livro)e;

            DateTime dataLancamento = book.DtLancamento;
            DateTime dataAtual = DateTime.Now;

            if (dataLancamento >= dataAtual) return "Data de lançamento inválida.";

            return "";
        }
    }
}
