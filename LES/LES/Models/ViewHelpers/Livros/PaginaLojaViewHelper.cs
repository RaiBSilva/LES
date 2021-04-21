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

            LivroCardViewHelper livCarHelper = new LivroCardViewHelper();

            IList<Livro> livros = new List<Livro>();

            if (Entidades != null) 
            {
                _viewModel = (IViewModel)model;
                return;
            }

            if (Entidades.ContainsKey(typeof(IList<Livro>).Name)) 
            { 
                livros = (IList<Livro>)Entidades[typeof(IList<Livro>).Name];

                foreach (var l in livros)
                {
                    livCarHelper.Entidades = new Dictionary<string, object>
                    {
                        [typeof(Livro).Name] = l
                    };

                    listaCardModel.Livros.Add((LivroCardModel)livCarHelper.ViewModel);
                }
            }

            string pagAtual = nameof(ListaCardLivrosModel.PagAtual),
                pagMax = nameof(ListaCardLivrosModel.PagMax),
                Titulo = nameof(LojaFiltrosModel.Titulo),
                Autor = nameof(LojaFiltrosModel.Autor),
                Isbn = nameof(LojaFiltrosModel.Isbn),
                Editora = nameof(LojaFiltrosModel.Editora),
                PrecoMin = nameof(LojaFiltrosModel.PrecoMin),
                PrecoMax = nameof(LojaFiltrosModel.PrecoMax),
                Categorias = nameof(LojaFiltrosModel.Categorias);


            if (Entidades.ContainsKey(pagAtual))
                listaCardModel.PagAtual = (int)Entidades[pagAtual];
            else
                listaCardModel.PagAtual = 1;

            if (Entidades.ContainsKey(pagMax))
                listaCardModel.PagMax = (int)Entidades[pagMax];

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

            if (Entidades.ContainsKey(Categorias))
                filtrosModel.Categorias = (string)Entidades[Categorias];

            model.Filtros = filtrosModel;
            model.Livros = listaCardModel;

        }
    }
}
