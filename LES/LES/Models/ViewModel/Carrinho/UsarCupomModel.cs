using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Carrinho
{
    public class UsarCupomModel : IViewModel
    {
        public IList<CupomModel> Cupons { get; set; } = new List<CupomModel>();
    }
}
