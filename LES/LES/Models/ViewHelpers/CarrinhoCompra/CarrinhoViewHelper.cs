using System;
using LES.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Models.ViewModel.Carrinho;
using LES.Models.ViewModel;

namespace LES.Models.ViewHelpers.CarrinhoCompra
{
    public class CarrinhoViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
            throw new NotImplementedException();
        }

        protected override void ToViewModel()
        {
            Carrinho c = (Carrinho)Entidades[typeof(Carrinho).Name];

            CarrinhoModel vm = new CarrinhoModel
            {
                Livros = new List<CarrinhoLivroModel>()
            };

            CarrinhoLivroModel livro;
            vm.PrecoTotal = 0;

            foreach (var item in c.CarrinhoLivro)
            {
                livro = new CarrinhoLivroModel
                {
                    Autor = item.Livro.Autor,
                    CodigoBarras = item.Livro.CodigoBarras,
                    Preco = Math.Round(item.Livro.Valor, 2),
                    Quantia = item.Quantia,
                    Titulo = item.Livro.Titulo,
                };
                vm.Livros.Add(livro);
                vm.PrecoTotal += livro.Preco;
            }

            _viewModel = (IViewModel)vm;
        }
    }
}
