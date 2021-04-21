using LES.Models.Entity;
using LES.Models.ViewModel;
using LES.Models.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Shared
{
    public class LivroCardViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
            throw new NotImplementedException();
        }

        protected override void ToViewModel()
        {
            Livro l = (Livro)Entidades[$"{typeof(Livro).Name}"];

            LivroCardModel vm = new LivroCardModel
            {
                Altura = l.Altura,
                Autor = l.Autor,
                CodigoBarras = l.CodigoBarras,
                Comprimento = l.Comprimento,
                DtLancamento = l.DtLancamento,
                Edicao = l.Edicao,
                Editora = l.Editora.Nome,
                Isbn = l.Isbn,
                Largura = l.Largura,
                Paginas = l.Paginas,
                Preco = l.Valor,
                Sinopse = l.Sinopse,
                Titulo = l.Titulo
            };

            _viewModel = vm;
        }
    }
}
