using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public enum StatusPedidos
    {
        [Display(Name = "Em processamento.")]
        Processamento,
        [Display(Name ="Em trânsito...")]
        EmTransito,
        [Display(Name = "Troca em processamento...")]
        EmTroca,
        [Display(Name = "Troca autorizada!")]
        TrocaAutorizada,
        [Display(Name = "Aprovado!")]
        Aprovado,
        [Display(Name = "Trocado!")]
        Trocado,
        [Display(Name = "Entregue!")]
        Entregue,
        [Display(Name = "Negado.")]
        Negado
    }
}
