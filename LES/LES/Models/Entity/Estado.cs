using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LES.Models.Entity
{
    public class Estado : EntidadeDominio
    {
        public string Nome { get; set; }
        public int PaisId { get; set; }

        public virtual IList<Cidade> Cidades { get; set; }
        public virtual Pais Pais { get; set; }


    }
}
