using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LES.Models.Entity
{
    public class EntidadeDominio
    {
        public int Id { get; set; }
        public DateTime DtCadastro { get; set; } = DateTime.Now;
        public bool Inativo { get; set; }

    }
}
