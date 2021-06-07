using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class CategoriaLivroViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
            CategoriaLivroModel vm = (CategoriaLivroModel)ViewModel;

            CategoriaLivro ctg = new CategoriaLivro
            {
                Nome = vm.Nome,
                Id = vm.Id
            };

            _entidades = new Dictionary<string, object> 
            {
                [typeof(CategoriaLivro).Name] = ctg
            };
        }

        protected override void ToViewModel()
        {
            CategoriaLivro categoria = (CategoriaLivro)Entidades[typeof(CategoriaLivro).Name];

            CategoriaLivroModel vm = new CategoriaLivroModel
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Inativo = categoria.Inativo
            };

            _viewModel = vm;
        }
    }
}
