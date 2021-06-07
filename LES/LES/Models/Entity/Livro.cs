using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Livro : EntidadeDominio
    {
        public string Titulo { get; set; }
        public int Altura { get; set; }
        public string Autor { get; set; }
        public byte[] Capa { get; set; }
        public string CodigoBarras { get; set; }
        public int Comprimento { get; set; }
        public DateTime DtLancamento { get; set; }
        public int Edicao { get; set; }
        public int EditoraId { get; set; }
        public int Estoque { get; set; }
        public int EstoqueBloqueado { get; set; }
        public int GrupoPrecoId { get; set; }
        public string Isbn { get; set; }
        public int Largura { get; set; }
        public double? MaiorCusto { get; set; }
        public int Paginas { get; set; }
        public double Peso { get; set; }
        public string Sinopse { get; set; }
        public double Valor { get; set; }

        public virtual IList<Ativacao> Ativacoes { get; set; } = new List<Ativacao>();
        public virtual IList<CarrinhoLivro> CarrinhoLivro { get; set; } = new List<CarrinhoLivro>();
        public virtual IList<LivroCategoriaLivro> LivrosCategoriaLivros { get; set; } = new List<LivroCategoriaLivro>();
        public virtual IList<LivroPedido> LivroPedidos { get; set; } = new List<LivroPedido>();
        public virtual Editora Editora { get; set; }
        public virtual GrupoPreco GrupoPreco { get; set; }
        public virtual IList<Inativacao> Inativacoes { get; set; } = new List<Inativacao>();

    }

}
