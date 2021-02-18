using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class Enderecos : EntidadeDominio
    {

        public IList<Endereco> EnderecosCobranca { get; set; }
        public IList<Endereco> EnderecosEntrega { get; set; }
        public Endereco EnderecoResidencia { get; set; }

        //Construtores
        public Enderecos() 
        { }

        public Enderecos(int id) : base(id)
        { }

        private void DefinirAtributos(IList<Endereco> enderecosCobranca, IList<Endereco> enderecosEntrega, Endereco enderecoResidencia) 
        {
            EnderecosCobranca = enderecosCobranca;
            EnderecosEntrega = enderecosEntrega;
            EnderecoResidencia = enderecoResidencia;
        }

        public Enderecos(IList<Endereco> enderecosCobranca, IList<Endereco> enderecosEntrega, Endereco enderecoResidencia)
        {
            DefinirAtributos(enderecosCobranca, enderecosEntrega, enderecoResidencia);
        }

        public Enderecos(int id, DateTime dtCadastro, IList<Endereco> enderecosCobranca,
            IList<Endereco> enderecosEntrega, Endereco enderecoResidencia) : base(id, dtCadastro)
        {
            DefinirAtributos(enderecosCobranca, enderecosEntrega, enderecoResidencia);
        }
    }
}
