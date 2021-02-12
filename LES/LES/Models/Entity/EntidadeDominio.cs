using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class EntidadeDominio
    {
        public int id { get; set; }
        public DateTime dtCadastro { get; set; }

        public EntidadeDominio() { }

        public EntidadeDominio(int id) 
        {
            this.id = id;
        }

        public EntidadeDominio(int id, DateTime dtCadastro)
        {
            this.id = id;
            this.dtCadastro = dtCadastro;
        }
    }
}
