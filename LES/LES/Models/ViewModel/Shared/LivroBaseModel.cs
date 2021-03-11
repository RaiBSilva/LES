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
        public int Codigo { get; set; }
    }
}
