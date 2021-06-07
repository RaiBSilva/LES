using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class EntradaEstoqueModel :IViewModel
    {
        [Display(Name ="Título")]
        public string Titulo { get; set; }
        public string Autor { get; set; }
        [Display(Name = "Código de Barras")]
        public string CodigoBarras { get; set; }
        public string Fornecedor { get; set; }
        public int Quantia { get; set; }
        public double Custo { get; set; }
        public DateTime DtEntrada { get; set; } = DateTime.Now;
    }
}
