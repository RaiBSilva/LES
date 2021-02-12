using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Cidade : EntidadeDominio
    {
        public String cidade { get; set; }
        public Estado estado { get; set; }

        public Cidade() { }

        private void definirAtributos(String cidade, Estado estado) 
        {
            this.cidade = cidade;
            this.estado = estado;
        }

        public Cidade(String cidade, Estado estado)
        {
            definirAtributos(cidade, estado);
        }

        public Cidade(int id, DateTime dtCadastro, String cidade, Estado estado) : base(id, dtCadastro) 
        {
            definirAtributos(cidade, estado);
        }


    }
}
