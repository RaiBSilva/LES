using LES.Models.Entity;
using LES.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers
{
    public abstract class AbstractViewHelper : IViewHelper
    {

        //Atributo responsável por guardar as entidades que vêm do db, ou que vão para o db
        protected IDictionary<string, EntidadeDominio> _entidades { get; set; }
        public virtual IDictionary<string, EntidadeDominio> Entidades
        {
            get => _entidades;
            set
            {
                _entidades = value;
                ToViewModel();
            }
        }

        //Atributo responsável por guardar as entidades que vêm do request, ou vão para uma página razor
        protected IViewModel _viewModel { get; set; }
        public virtual IViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                ToEntidade();
            }
        }

        public AbstractViewHelper()
        {
            _entidades = new Dictionary<string, EntidadeDominio>();
        }

        protected abstract void ToEntidade();

        protected abstract void ToViewModel(); 
    }
}
