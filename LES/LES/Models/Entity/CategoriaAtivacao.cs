using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class CategoriaAtivacao : MetadadoBase
    {
        public virtual IList<Ativacao> Ativacoes { get; set; }
    }
}
