using LES.Negocio.Strategy;
using LES.Negócio.Strategy;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Usuario : EntidadeDominio
    {
        public string Email { get; set; }
        private Hasher _hasher { get; set; }
        private string _senha;
        public string Senha
        {
            get => _senha; 
            set
            {
                _hasher = new Hasher(value);
                _senha = Convert.ToBase64String(_hasher.ToArray());
            }
        }
        public UserRole Role { get; set; }

        public virtual Cliente Cliente { get; set; }
        public Usuario()
        {
        }

    }
}
