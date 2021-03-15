using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Shared
{
    public class LivroBaseModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public int CodigoBarras { get; set; }
        public int Paginas { get; set; }
        public int Comprimento { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }

    }
}
