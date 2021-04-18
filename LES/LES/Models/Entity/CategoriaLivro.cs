using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class CategoriaLivro : MetadadoBase
    {
        public virtual IList<LivroCategoriaLivro> LivrosCategoriaLivros { get; set; }

    }
}
