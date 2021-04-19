using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Pais : EntidadeDominio
    {
        public string Nome { get; set; }

        public virtual IList<Estado> Estados { get; set; }
    }
}
