using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Editora: MetadadoBase
    {
        public virtual IList<Livro> Livros { get; set; }


    }
}
