using LES.Models.Entity;
using LES.Models.ViewHelpers.Shared;
using LES.Models.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class AdminLivroViewHelper : AbstractViewHelper, IViewHelper
    {
protected override void ToEntidade()
        {
            throw new NotImplementedException();
        }

        protected override void ToViewModel()
        {
            Livro livro = (Livro)Entidades[typeof(Livro).Name];

            AdminLivroModel vm = new AdminLivroModel
            {
                Altura = livro.Altura,
                Autor = livro.Autor,
                CodigoBarras = livro.CodigoBarras,
                Comprimento = livro.Comprimento,
                DtLancamento = livro.DtLancamento,
                Edicao = livro.Edicao,
                Editora = livro.Editora.Nome,
                Isbn = livro.Isbn,
                Largura = livro.Largura,
                Paginas = livro.Paginas,
                Preco = livro.Valor,
                Sinopse = livro.Sinopse,
                Titulo = livro.Titulo,
                Estoque = livro.Estoque,
                Id = livro.Id
            };

            _viewModel = vm;
        }
    }
}
