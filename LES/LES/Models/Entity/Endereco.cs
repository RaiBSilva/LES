using System;

namespace LES.Models.Entity
{
    public class Endereco : EntidadeDominio
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public Estado Estado { get; set; }
        public Endereco() { }

        private void DefinirAtributos(String logradouro, String numero, String cep, String complemento, Estado estado)
        {
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Cep = cep;
            this.Complemento = complemento;
            this.Estado = estado;
        }

        public Endereco(String logradouro, String numero, String cep, String complemento, Estado estado)
        {
            DefinirAtributos(logradouro, numero, cep, complemento, estado);
        }
        public Endereco(int id, DateTime dtCadastro, String logradouro, String numero, String cep, String complemento, Estado estado)
            : base(id, dtCadastro)
        {
            DefinirAtributos(logradouro, numero, cep, complemento, estado);
        }



    }
}
