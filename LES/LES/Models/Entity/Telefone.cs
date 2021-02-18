using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Telefone : EntidadeDominio
    {

        public string Tipo { get; set; }

        public string Ddd { get; set; }

        public string Numero { get; set; }

        public Telefone() 
        { }

        public Telefone(int id) : base(id) 
        { }

        public void DefinirAtributos(string tipo, string ddd, string numero) 
        {
            Tipo = tipo;
            Ddd = ddd;
            Numero = numero;
        }

        public Telefone(string tipo, string ddd, string numero)
        {
            DefinirAtributos(tipo, ddd, numero);
        }

        public Telefone(int id, DateTime dtCadastro, string tipo, string ddd, string numero) : base(id, dtCadastro)
        {
            DefinirAtributos(tipo, ddd, numero);
        }
    }
}
