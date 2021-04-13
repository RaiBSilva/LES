using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Telefone : EntidadeDominio
    {
        public int ClienteId { get; set; }
        public string Ddd { get; set; }
        public bool EFavorito { get; set; }
        public string Numero { get; set; }
        public int TipoTelefoneId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual TipoTelefone TipoTelefone { get; set; }

        public Telefone() 
        {
            Cliente = new Cliente();
            TipoTelefone = new TipoTelefone();
        }
    }
}
