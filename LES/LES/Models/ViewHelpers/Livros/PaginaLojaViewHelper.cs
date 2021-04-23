using LES.Models.Entity;
using LES.Models.ViewHelpers.Shared;
using LES.Models.ViewModel;
using LES.Models.ViewModel.Livros;
using LES.Models.ViewModel.Shared;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Livros
{
    public class PaginaLojaViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
        }

        protected override void ToViewModel()
        {
            PaginaLojaViewHelper vm = new PaginaLojaViewHelper();
            PaginaLojaModel model = new PaginaLojaModel();
            LojaFiltrosModel filtrosModel = new LojaFiltrosModel();
            ListaCardLivrosModel listaCardModel = new ListaCardLivrosModel();

            if (Entidades == null) 
            {
                _viewModel = model;
                return;
            }

            ListaCardLivrosViewHelper listaCardHelper = new ListaCardLivrosViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(IList<Livro>).Name] = Entidades[typeof(IList<Livro>).Name],
                    [nameof(ListaCardLivrosModel.PagAtual)] = Entidades[nameof(ListaCardLivrosModel.PagAtual)],
                    [nameof(ListaCardLivrosModel.PagMax)] = Entidades[nameof(ListaCardLivrosModel.PagMax)]
                }
            };

            listaCardModel = (ListaCardLivrosModel)listaCardHelper.ViewModel;

            string Titulo = nameof(LojaFiltrosModel.Titulo),
                Autor = nameof(LojaFiltrosModel.Autor),
                Isbn = nameof(LojaFiltrosModel.Isbn),
                Editora = nameof(LojaFiltrosModel.Editora),
                PrecoMin = nameof(LojaFiltrosModel.PrecoMin),
                PrecoMax = nameof(LojaFiltrosModel.PrecoMax),
                DataMin = nameof(LojaFiltrosModel.DataMin),
                DataMax = nameof(LojaFiltrosModel.DataMax),
                Categorias = nameof(LojaFiltrosModel.Categorias);

            if (Entidades.ContainsKey(Titulo))
                filtrosModel.Titulo = (string)Entidades[Titulo];

            if (Entidades.ContainsKey(Autor))
                filtrosModel.Autor = (string)Entidades[Autor];

            if (Entidades.ContainsKey(Isbn))
                filtrosModel.Isbn = (string)Entidades[Isbn];

            if (Entidades.ContainsKey(Editora))
                filtrosModel.Editora = (string)Entidades[Editora];

            if (Entidades.ContainsKey(PrecoMin))
                filtrosModel.PrecoMin = (double)Entidades[PrecoMin];

            if (Entidades.ContainsKey(PrecoMax))
                filtrosModel.PrecoMax = (double)Entidades[PrecoMax];

            if (Entidades.ContainsKey(DataMin))
                filtrosModel.PrecoMax = (double)Entidades[DataMin];

            if (Entidades.ContainsKey(DataMax))
                filtrosModel.PrecoMax = (double)Entidades[DataMax];

            if (Entidades.ContainsKey(Categorias))
                filtrosModel.Categorias = (string)Entidades[Categorias];

            model.Filtros = filtrosModel;
            model.Livros = listaCardModel;

            _viewModel = model;

        }
    }
}
