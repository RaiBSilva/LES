using LES.Models.Entity;
using LES.Models.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.LivroViewHelpers
{
    public class LivroBaseViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
            LivroBaseModel vm = (LivroBaseModel)ViewModel;
            Livro book = new Livro();

            book.Titulo = vm.Titulo;
            book.Altura = vm.Altura;
            book.Autor = vm.Autor;
            book.CodigoBarras = vm.CodigoBarras;
            book.Comprimento = vm.Comprimento;
            book.DtLancamento = vm.DtLancamento;
            book.Edicao = vm.Edicao;
            book.Editora.Nome = vm.Editora;
            book.ISBN = vm.Isbn;
            book.Largura = vm.Largura;
            book.NumPag = vm.Paginas;
            book.Sinopse = vm.Sinopse;
            book.Valor = vm.Preco;

            Entidades[typeof(Livro).Name] = book;
        }

        protected override void ToViewModel()
        {
            Livro book = (Livro)Entidades[typeof(Livro).Name];
            LivroBaseModel vm = new LivroBaseModel();

            vm.Altura = book.Altura;
            vm.Autor = book.Autor;
            vm.CodigoBarras = book.CodigoBarras;
            vm.Comprimento = book.Comprimento;
            vm.DtLancamento = book.DtLancamento;
            vm.Edicao = book.Edicao;
            vm.Editora = book.Editora.Nome;
            vm.Isbn = book.ISBN;
            vm.Largura = book.Largura;
            vm.Paginas = book.NumPag;
            vm.Preco = (float)book.Valor;
            vm.Sinopse = book.Sinopse;
            vm.Titulo = book.Titulo;

            _viewModel = vm;
        }
    }
}
