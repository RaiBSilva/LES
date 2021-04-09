using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class LivroCategoriaLivro
    {
        public int CategoriaLivroId { get; set; }
        public int LivroId { get; set; }

        public virtual CategoriaLivro CategoriaLivro { get; set; }
        public virtual Livro Livro { get; set; }

    }
}
