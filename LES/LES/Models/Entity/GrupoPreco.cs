using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class GrupoPreco : MetadadoBase
    {
        public double MargemLucro { get; set; }

        public virtual IList<Livro> Livros { get; set; }

        public GrupoPreco() : base()
        {
            Livros = new List<Livro>();
        }
    }
}
