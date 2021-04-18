using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Livro : EntidadeDominio
    {
        public int Altura { get; set; }
        public string Autor { get; set; }
        public string CodigoBarras { get; set; }
        public int Comprimento { get; set; }
        public int EditoraId { get; set; }
        public int Estoque { get; set; }
        public int GrupoPrecoId { get; set; }
        public string ISBN { get; set; }
        public int Largura { get; set; }
        public int NumPag { get; set; }
        public double Peso { get; set; }
        public string Sinopse { get; set; }
        public double Valor { get; set; }

        public virtual IList<Ativacao> Ativacoes { get; set; }
        public virtual IList<LivroCategoriaLivro> LivrosCategoriaLivros { get; set; }
        public virtual IList<LivroPedido> LivroPedidos { get; set; }
        public virtual Editora Editora { get; set; }
        public virtual GrupoPreco GrupoPreco { get; set; }
        public virtual IList<Inativacao> Inativacoes { get; set; }

    }

}
