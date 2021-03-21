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
        public MotivoInativacaoModel Motivo { get; set; }


    }
}
