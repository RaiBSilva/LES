using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.LivroStrategy
{
    public class ValidaLivroNull : IStrategy
    {
        public string Validar(EntidadeDominio e)
        {
            Livro book = (Livro)e;
            StringBuilder sb = new StringBuilder("");

            if (string.IsNullOrEmpty(book.Autor)) sb.Append("O campo Autor é obrigatório.;\n");

            if (string.IsNullOrEmpty(book.CodigoBarras)) sb.Append("O código de barras é obrigatório.;\n");

            if (book.Capa != null)
                if (book.Capa.Length == 0) sb.Append("Por favor selecionar uma capa válida.");

            if (book.Editora != null)
            {
                if (string.IsNullOrEmpty(book.Editora.Nome)) sb.Append("É necessário informar o nome da editora.;\n");
            }

            if (string.IsNullOrEmpty(book.Isbn)) sb.Append("O ISBN é obrigatório.;\n");

            if (string.IsNullOrEmpty(book.Sinopse)) sb.Append("A Sinopse é obrigatória.;\n");

            if (book.Valor <= 0) sb.Append("O valor fornecido é inválido.;\n");

            if (book.Altura <= 0) sb.Append("É necessário informar a altura.;\n");

            if (book.Edicao <= 0) sb.Append("A edição é inválida.;\n");

            if (book.Comprimento <= 0) sb.Append("É necessário informar o comprimento.;\n");

            if (string.IsNullOrEmpty(book.Titulo)) sb.Append("É necessário informar o título do livro.;\n");

            if (book.LivrosCategoriaLivros is null) sb.Append("É necessário informar a categoria do livro.;\n");

            foreach (LivroCategoriaLivro categoria in book.LivrosCategoriaLivros)
            {
                if (string.IsNullOrEmpty(categoria.CategoriaLivro.Nome)) sb.Append("É necessário informar o nome da categoria.;\n");
            }

            return sb.ToString();
        }
    }
}
