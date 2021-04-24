using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Carrinho
{
    public class ListaCartoesPedidoModel
    {
        [Display(Name="Usar?")]
        public bool Ativado { get; set; }
        public string Id { get; set; }
        public double Valor { get; set; }

        //Propriedade de Exibição
        public string Codgio { get; set; }
        public DateTime DtVencimento { get; set; }

    }
}
