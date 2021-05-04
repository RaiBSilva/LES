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

            AdminLivroModel vm = new AdminLivroModel();

            LivroBaseViewHelper baseVh = new LivroBaseViewHelper 
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Livro).Name] = livro
                }
            };

            vm = (AdminLivroModel)baseVh.ViewModel;

            vm.Estoque = livro.Estoque;
            vm.Id = livro.Id;

            _viewModel = vm;
        }
    }
}
