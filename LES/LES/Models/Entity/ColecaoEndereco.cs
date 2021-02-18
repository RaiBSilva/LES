using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Entity
{
    public class ColecaoEndereco : EntidadeDominio
    {

        public IList<Endereco> EnderecosCobranca { get; set; }
        public IList<Endereco> EnderecosEntrega { get; set; }
        public Endereco EnderecoResidencia { get; set; }

        //Construtores
        public ColecaoEndereco() 
        { }

        public ColecaoEndereco(int id) : base(id)
        { }

        private void DefinirAtributos(IList<Endereco> enderecosCobranca, IList<Endereco> enderecosEntrega, Endereco enderecoResidencia) 
        {
            EnderecosCobranca = enderecosCobranca;
            EnderecosEntrega = enderecosEntrega;
            EnderecoResidencia = enderecoResidencia;
        }

        public ColecaoEndereco(IList<Endereco> enderecosCobranca, IList<Endereco> enderecosEntrega, Endereco enderecoResidencia)
        {
            DefinirAtributos(enderecosCobranca, enderecosEntrega, enderecoResidencia);
        }

        public ColecaoEndereco(int id, DateTime dtCadastro, IList<Endereco> enderecosCobranca,
            IList<Endereco> enderecosEntrega, Endereco enderecoResidencia) : base(id, dtCadastro)
        {
            DefinirAtributos(enderecosCobranca, enderecosEntrega, enderecoResidencia);
        }
    }
}
