using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LES.Models.ViewModel
{

    public class NumeroRegEx : RegularExpressionAttribute
    {
        public NumeroRegEx()
            : base("^[0-9]*$")
        {
        }
    }

    public class ClienteCadastro
    {

        public int Id { get; set; }
        [Required]
        [Display(Name ="Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data de nascimento")]
        public DateTime DtNascimento { get; set; }

        [Required]
        [Display(Name = "Gênero")]
        public Genero Genero { get; set; }

        [Display(Name = "e-Mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "A senha deve ter 8 no caracteres no mínimo.")]
        public string Senha { get; set; }

        [Required]
        [Display(Name = "CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Insira um CPF válido.")]
        [NumeroRegEx(ErrorMessage = "Insira somente os valores numéricos.")]
        public string Cpf { get; set; }
        
        [Required]
        [Display(Name = "Tipo de telefone")]
        public TipoTelefone TipoTelefone {get; set;}

        [Required]
        [Display(Name = "DDD")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Insira os três digitos do DDD.")]
        public string Ddd { get; set; }

        [Required]
        [Display(Name = "Número de telefone")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "Insira um telefone de oito ou nove dígitos.")]
        [NumeroRegEx(ErrorMessage = "Insira somente os valores numéricos.")]
        public string Telefone { get; set; }

        public List<EnderecoCadastro> Enderecos { get; set; }

        public ClienteCadastro() { }

        public ClienteCadastro(int id, string nome, DateTime dtNascimento, Genero genero, 
            string email, string senha, string cpf, TipoTelefone tipoTelefone, 
            string ddd, string telefone, List<EnderecoCadastro> enderecos)
        {
            Id = id;
            Nome = nome;
            DtNascimento = dtNascimento;
            Genero = genero;
            Email = email;
            Senha = senha;
            Cpf = cpf;
            TipoTelefone = tipoTelefone;
            Ddd = ddd;
            Telefone = telefone;
            Enderecos = enderecos;
        }

        public ClienteCadastro(DateTime dtNascimento, List<EnderecoCadastro> enderecos)
        {
            DtNascimento = dtNascimento;
            Enderecos = enderecos;
        }
    }
}
