using LES.Negócio.Strategy;
using System;

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
