 using LES.Controllers;
using LES.Models.Entity;
using LES.Models.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class PedidoModel
    {
        public string Codigo { get; set; }
        public DateTime DtPedido { get; set; }
        public IList<PedidoLivroModel> Livros { get; set; }
        public float PreçoTotal { get; set; }
        public StatusPedidos Status {get;set;}

        public PedidoModel()
        {
            Livros = new List<PedidoLivroModel>();
        }
    }



}
