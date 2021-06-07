using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Carrinho : EntidadeDominio
    {
        public DateTime TimeoutDate { get; set; } = DateTime.Now.AddDays(7);

        public String JobKeyStr { get; set; }

        public virtual IList<CarrinhoLivro> CarrinhoLivro { get; set; }
        public virtual Cliente Cliente { get; set; }

        public double PrecoTotal()
        {
            double soma = 0;
            if (CarrinhoLivro != null)
                foreach(var item in CarrinhoLivro) 
                    soma += item.Livro.Valor * item.Quantia;
            return soma;
        }
    }
}
