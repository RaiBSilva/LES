using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.AtivacaoStrategy
{
    public class ValidaEstoqueAtivacao : IStrategy
    {
        public string Validar(EntidadeDominio e)
        {
            Ativacao a = (Ativacao)e;
            Livro l = a.Livro;

            if (l.Estoque <= 0)
                return "Esse livro não pode ser ativado pois seu estoque está zerado. Faça uma entrada de estoque e tente novamente.\n";

            return "";
        }
    }
}
