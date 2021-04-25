using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Carrinho
{
    public class ItemListaCartoesPedidoModel
    {
        [Display(Name="Usar?")]
        public bool Ativado { get; set; }
        public int Id { get; set; }
        public double Valor { get; set; }

        //Propriedade de Exibição
        public string Bandeira { get; set; }
        public string UltimosDigitos { get; set; }
        public DateTime DtVencimento { get; set; }

    }
}
