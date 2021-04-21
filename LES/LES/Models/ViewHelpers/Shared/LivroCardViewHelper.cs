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
            LivroCardModel vm = (LivroCardModel)ViewModel;
            Livro book = new Livro();

            book.Titulo = vm.Titulo;
            book.Altura = vm.Altura;
            book.Autor = vm.Autor;
            book.CodigoBarras = vm.CodigoBarras;
            book.Comprimento = vm.Comprimento;
            book.DtLancamento = vm.DtLancamento;
            book.Edicao = vm.Edicao;
            book.Editora.Nome = vm.Editora;
            book.Isbn = vm.Isbn;
            book.Largura = vm.Largura;
            book.Paginas = vm.Paginas;
            book.Sinopse = vm.Sinopse;
            book.Valor = vm.Preco;

            Entidades[typeof(Livro).Name] = book;
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
