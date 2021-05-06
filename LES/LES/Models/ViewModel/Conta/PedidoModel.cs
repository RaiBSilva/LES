 using LES.Controllers;
using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class PedidoModel : IViewModel
    {
        public string Id { get; set; }
        public DateTime DtPedido { get; set; }
        public IDictionary<int, AdminLivroModel> Livros { get; set; } = new Dictionary<int, AdminLivroModel>();
        public double PreçoTotal { get; set; }
        [Display(Name = "Status do Pedido")]
        public StatusPedidos Status {get;set;}
        public CupomModel Cupom { get; set; }
        public IDictionary<CartaoBaseModel, double> Cartoes { get; set; } = new Dictionary<CartaoBaseModel, double>();
    }



}
