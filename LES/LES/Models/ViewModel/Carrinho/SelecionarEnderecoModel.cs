using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Carrinho
{
    public class SelecionarEnderecoModel : DetalhesEnderecoModel, IViewModel
    {
        public int EnderecoId { get; set; } 

        public IList<DetalhesEnderecoModel> Enderecos { get; set; } = new List<DetalhesEnderecoModel>();

    }
}
