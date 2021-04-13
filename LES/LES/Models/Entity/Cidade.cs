using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace LES.Models.Entity
{
    public class Cidade : EntidadeDominio
    {
        public string Nome { get; set; }
        public int EstadoId { get; set; }

        public virtual IList<Endereco> Enderecos { get; set; }
        public virtual Estado Estado { get; set; }

        public Cidade() : base()
        {
            Enderecos = new List<Endereco>();
            Estado = new Estado();
        }

    }
}
