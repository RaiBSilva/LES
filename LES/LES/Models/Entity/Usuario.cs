using LES.Negócio.Strategy;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LES.Models.Entity
{
    public class Usuario : EntidadeDominio
    {
        public string Email { get; set; }
        [NotMapped]
        public Hasher Hasher { get; set; }
        private string _senha;
        public string Senha
        {
            get => _senha; 
            set
            {
                Hasher = new Hasher(value);
                _senha = Convert.ToBase64String(Hasher.ToArray());
            }
        }
        public UserRole Role { get; set; }

        public virtual Cliente Cliente { get; set; }


    }
}
