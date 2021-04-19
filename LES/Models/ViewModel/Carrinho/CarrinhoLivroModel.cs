using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Carrinho
{
    public class CarrinhoLivroModel
    {
        public string Titulo { get; set; }
        public string CodigoBarras { get; set; }
        public string Autor { get; set; }
        public int Quantia { get; set; }
        public float Preco { get; set; }

    }
}
