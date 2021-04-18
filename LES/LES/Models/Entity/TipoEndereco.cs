using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class TipoEndereco : MetadadoBase
    {
        public virtual IList<Endereco> Enderecos { get; set; }

    }
}
