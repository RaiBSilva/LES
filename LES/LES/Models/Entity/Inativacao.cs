using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Inativacao : EntidadeDominio
    {
        public int CategoriaId { get; set; }
        public int LivroId { get; set; }

        public virtual CategoriaInativacao Categoria { get; set; }
        public virtual Livro Livro { get; set; }

    }
}
