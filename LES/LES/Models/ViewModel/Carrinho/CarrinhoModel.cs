using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Carrinho
{
    public class CarrinhoModel
    {
        public IList<CarrinhoLivroModel> Livros { get; set; }
        [Display(Name = "Preço total: ")]
        public double PrecoTotal { get; set; }

    }
}
