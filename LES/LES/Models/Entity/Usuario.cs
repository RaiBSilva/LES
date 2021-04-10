using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Usuario : EntidadeDominio
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public UserRole Role { get; set; }

        public virtual Cliente Cliente { get; set; }
        public Usuario()
        {

        }

    }
}
