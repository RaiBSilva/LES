using LES.Models.Entity;
using LES.Models.ViewHelpers.Conta;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class PaginaClientesViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
        }

        protected override void ToViewModel()
        {
            PaginaClientesModel vm = new PaginaClientesModel();

            IList<Cliente> clientes = Entidades.ContainsKey(typeof(IList<Cliente>).FullName) ?
                (IList<Cliente>)Entidades[typeof(IList<Cliente>).FullName] : new List<Cliente>();

            int pagAtual = Entidades.ContainsKey(nameof(ListaClientesModel.PagAtual)) ?
                (int)Entidades[nameof(ListaClientesModel.PagAtual)] : 1;

            int pagMax = Entidades.ContainsKey(nameof(ListaClientesModel.PagMax)) ?
                (int)Entidades[nameof(ListaClientesModel.PagMax)] : 1;

            ListaClientesModel lista = new ListaClientesModel
            {
                PagAtual = pagAtual,
                PagMax = pagMax
            };

            AdminClienteViewHelper clienteVh = new AdminClienteViewHelper();
            foreach (var cliente in clientes)
            {
                clienteVh.Entidades = new Dictionary<string, object>
                {
                    [typeof(Cliente).Name] = cliente
                };

                lista.Clientes.Add((AdminClienteModel)clienteVh.ViewModel);
            }

            vm.Clientes = lista;

            string Id = nameof(FiltrosClientesModel.Id),
                Nome = nameof(FiltrosClientesModel.Nome),
                Email = nameof(FiltrosClientesModel.Email);

            vm.Filtros.Id = Entidades.ContainsKey(Id) ? (int)Entidades[Id] : 0;

            vm.Filtros.Nome = Entidades.ContainsKey(Nome) ? (string)Entidades[Nome] : null;

            vm.Filtros.Email = Entidades.ContainsKey(Email) ? (string)Entidades[Email] : null;

            _viewModel = vm;

        }
    }
}
