using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class CarrinhoLivro
    {
        public int CarrinhoId { get; set; }
        public int LivroId { get; set; }
        public int Quantia { get; set; }

        public virtual Carrinho Carrinho { get; set; }
        public virtual Livro Livro { get; set; }

    }
}
