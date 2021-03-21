using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class EntradaEstoqueModel
    {
        [Display(Name ="Título")]
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string CodigoBarras { get; set; }
        public string Fornecedor { get; set; }
        public int Quantia { get; set; }
        public double Custo { get; set; }
        public DateTime DtEntrada { get; set; }

        public EntradaEstoqueModel()
        {
            DtEntrada = DateTime.Now;
        }
    }
}
