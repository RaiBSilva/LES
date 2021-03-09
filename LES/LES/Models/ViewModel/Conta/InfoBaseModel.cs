using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class InfoBaseModel
    {
        //[Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        public string Codigo { get; set; }

        //[Required]
        [Display(Name = "Data de nascimento")]
        public DateTime DtNascimento { get; set; }

        //[Required]
        [Display(Name = "Gênero")]
        public Genero Genero { get; set; }

        [Display(Name = "e-Mail")]
        public string Email { get; set; }

        //[Required]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "A senha deve ter 8 no caracteres no mínimo.")]
        public string Senha { get; set; }

        //[Required]
        [Display(Name = "CPF")]
        //[StringLength(11, MinimumLength = 11, ErrorMessage = "Insira um CPF válido.")]
        //[NumeroRegEx(ErrorMessage = "Insira somente os valores numéricos.")]
        public string Cpf { get; set; }
    }
}
