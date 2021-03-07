﻿using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class EnderecoBaseModel
    {
        //[Required]
        public string Logradouro { get; set; }

        //[Required]
        [Display(Name = "Nº")]
        public string Numero { get; set; }

        //[Required]
        //[StringLength(7, MinimumLength = 7, ErrorMessage = "Insira um CEP de sete dígitos.")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        //[Required]
        public string Complemento { get; set; }

        //[Required]
        public string Cidade { get; set; }

        //[Required]
        public string Estado { get; set; }

        //[Required]
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        //[Required]
        [Display(Name = "Tipo de endereço")]
        public TipoEndereco TipoEndereco { get; set; }

    }
}