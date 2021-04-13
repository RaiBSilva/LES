using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class CategoriaInativacao : MetadadoBase
    {
        public virtual IList<Inativacao> Inativacoes { get; set; }

        public CategoriaInativacao():base()
        {
            Inativacoes = new List<Inativacao>();
        }
    }
}
