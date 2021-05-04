using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using LES.Models.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class TrocaModel : IViewModel
    {
        public int LivroPedidoId { get; set; }
        public AdminLivroModel Livro { get; set; }
        public StatusTroca Status { get; set; }

    }
}
