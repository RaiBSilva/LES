using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.LivroStrategy
{
    public class ValidaLivroNull : IStrategy<EntidadeDominio>
    {
        public string Validar(EntidadeDominio e)
        {
            Livro book = (Livro)e;
            StringBuilder sb = new StringBuilder("");

            if (string.IsNullOrEmpty(book.Autor)) sb.Append("O campo Autor é obrigatório.;");

            if (string.IsNullOrEmpty(book.CodigoBarras)) sb.Append("O códifo de barras é obrigatório.;");

            if (book.Editora is null) sb.Append("É necessário informar uma editora.;");

            if (string.IsNullOrEmpty(book.Editora.Nome)) sb.Append("É necessário informar o nome da editora.;");

            if (string.IsNullOrEmpty(book.ISBN)) sb.Append("O ISBN é obrigatório.;");

            if (string.IsNullOrEmpty(book.Sinopse)) sb.Append("A Sinopse é obrigatória.;");

            if (book.Valor <= 0) sb.Append("O valor fornecido é inválido.;");

            if (book.Altura <= 0) sb.Append("É necessário informar a altura.;");

            if (book.Edicao <= 0) sb.Append("A edição é inválida.;");

            if (book.Capa is null) sb.Append("É necessário fornecer uma capa.;");

            if (book.Comprimento <= 0) sb.Append("É necessário informar o comprimento.;");

            if (string.IsNullOrEmpty(book.Titulo)) sb.Append("É necessário informar o título do livro.;");

            if (book.LivrosCategoriaLivros is null) sb.Append("É necessário informar a categoria do livro.;");

            foreach (LivroCategoriaLivro categoria in book.LivrosCategoriaLivros)
            {
                if (string.IsNullOrEmpty(categoria.CategoriaLivro.Nome)) sb.Append("É necessário informar o nome da categoria.;");
            }

            return sb.ToString();
        }
    }
}
