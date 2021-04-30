using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
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
            Cliente cliente = (Cliente)Entidades[typeof(Cliente).Name];

            AdminPedidoModel vm = new AdminPedidoModel
            {
                Id = p.Id.ToString(),
                DtPedido = p.DtCadastro,
                Status = p.Status
            };



        }
    }
}
