using System;

namespace LES.Models.Entity
{
    public class Endereco : EntidadeDominio
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public Cidade Cidade { get; set; }
        public string Observacoes { get; set; }
        public Endereco() { }

        private void DefinirAtributos(String logradouro, String numero, String cep, String complemento, Cidade cidade,
            string Observacoes)
        {
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Cep = cep;
            this.Complemento = complemento;
            this.Cidade = cidade;
            this.Observacoes = Observacoes;
        }

        public Endereco(string logradouro, string numero, string cep, string complemento, Cidade cidade,
            string observacoes)
        {
            DefinirAtributos(logradouro, numero, cep, complemento, cidade, observacoes);
        }

        public Endereco(int id, DateTime dtCadastro, string logradouro, string numero, string cep,
            string complemento, Cidade cidade, string observacoes)
            : base(id, dtCadastro)
        {
            DefinirAtributos(logradouro, numero, cep, complemento, cidade, observacoes);
        }

    }
}
