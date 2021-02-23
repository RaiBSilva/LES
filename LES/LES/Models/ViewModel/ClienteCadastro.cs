using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LES.Models.ViewModel
{
    public class ClienteCadastro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public Genero Genero { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public TipoTelefone TipoTelefone {get; set;}
        public string Ddd { get; set; }
        public string Telefone { get; set; }
        public IList<EnderecoCadastro> Enderecos { get; set; }

        public ClienteCadastro() { }

        public ClienteCadastro(int id, string nome, DateTime dtNascimento, Genero genero, 
            string email, string senha, string cpf, TipoTelefone tipoTelefone, 
            string ddd, string telefone, IList<EnderecoCadastro> enderecos)
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
    }
}
