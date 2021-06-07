using LES.Models.Entity;
using LES.Models.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class InativarLivroModel
    {

        public string CodigoBarras { get; set; }
        public bool Inativo { get; set; }
        public int Motivo { get; set; }

        public IList<CategoriaInativacao> CategoriasInativacao { get; set; }
        public IList<CategoriaAtivacao> CategoriasAtivacao { get; set; }


    }
}
