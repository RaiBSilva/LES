using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Endereco : EntidadeDominio
    {
        public String logradouro { get; set; }
        public String numero { get; set; }
        public String cep { get; set; }
        public String complemento { get; set; }
        public Estado estado { get; set; }
        public Endereco() { }

        private void definirAtributos(String logradouro, String numero, String cep, String complemento, Estado estado) 
        {
            this.logradouro = logradouro;
            this.numero = numero;
            this.cep = cep;
            this.complemento = complemento;
            this.estado = estado;
        }

        public Endereco(String logradouro, String numero, String cep, String complemento, Estado estado)
        {
            definirAtributos(logradouro, numero, cep, complemento, estado);
        }
        public Endereco(int id, DateTime dtCadastro, String logradouro, String numero, String cep, String complemento, Estado estado)
            : base(id, dtCadastro)
        {
            definirAtributos(logradouro, numero, cep, complemento, estado);
        }



    }
}
