using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Carrinho : EntidadeDominio
    {
        public DateTime TimeoutDate { get; set; }

        public virtual IList<CarrinhoLivro> CarrinhoLivro { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
