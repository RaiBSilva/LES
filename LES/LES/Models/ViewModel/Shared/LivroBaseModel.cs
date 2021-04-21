using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Shared
{
    public class LivroBaseModel : IViewModel
    {
        [Display(Name ="Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Sinopse { get; set; }

        [Display(Name = "ISBN")]
        public string Isbn { get; set; }

        [Display(Name = "Preço")]
        public double Preco { get; set; }

        [Display(Name = "Edição")]
        public int Edicao { get; set; }

        [Display(Name = "Código de Barras")]
        public string CodigoBarras { get; set; }

        [Display(Name = "Páginas")]
        public int Paginas { get; set; }
        public int Comprimento { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }

        [Display(Name = "Mês de Lançamento")]
        public DateTime DtLancamento { get; set; }

        public LivroBaseModel()
        {
            DtLancamento = DateTime.Now;
        }

    }
}
