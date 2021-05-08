using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public enum StatusPedidos
    {
        [Display(Name = "Não finalizado.")]
        NaoFinalizado = -1,
        [Display(Name = "Em processamento.")]
        Processamento,
        [Display(Name ="Em trânsito...")]
        EmTransito,
        [Display(Name = "Aprovado!")]
        Aprovado,
        [Display(Name = "Entregue!")]
        Entregue,
        [Display(Name = "Negado.")]
        Negado
    }

    public enum StatusTroca
    {
        [Display(Name = "Em processamento...")]
        Processamento,
        [Display(Name = "Em trânsito...")]
        EmTransito,
        [Display(Name = "Autorizada.")]
        Autorizada,
        [Display(Name = "Concluída.")]
        Trocada,
        [Display(Name = "Cancelada.")]
        Cancelada,
        [Display(Name = "Negada.")]
        Negada
    }
}
