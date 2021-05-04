﻿using LES.Models.Entity;
using LES.Models.ViewHelpers.Conta;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class AdminPedidoViewHelper : AbstractViewHelper, IViewHelper
    {
protected override void ToEntidade()
        {
            throw new NotImplementedException();
        }

        protected override void ToViewModel()
        {

            Pedido p = (Pedido)Entidades[typeof(Pedido).Name];
            Cliente cliente = p.Cliente;

            PedidoViewHelper baseVh = new PedidoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Pedido).Name] = p
                }
            };

            AdminPedidoModel vm = (AdminPedidoModel)baseVh.ViewModel;

            PaginaDetalhesViewHelper clienteVh = new PaginaDetalhesViewHelper 
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Cliente).Name] = cliente
                }
            };

            vm.Cliente = (PaginaDetalhesModel)clienteVh.ViewModel;

            _viewModel = vm;

        }
    }
}
