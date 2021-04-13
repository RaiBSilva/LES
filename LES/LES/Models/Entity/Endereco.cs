using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LES.Models.Entity
{
    public class Endereco : EntidadeDominio
    {
        #region Propriedades
        public string Cep { get; set; }
        public int CidadeId { get; set; }
        public string Complemento { get; set; }
        public bool ECobranca { get; set; }
        public bool EEntrega { get; set; }
        public bool EFavorito { get; set; }
        public bool EResidencia { get; set; }
        public string Logradouro { get; set; }
        public string NomeEndereco { get; set; }
        public string Numero { get; set; }
        public string Observacoes { get; set; }
        public int TipoEnderecoId { get; set; }

        public virtual Cidade Cidade { get; set; }
        public virtual TipoEndereco TipoEndereco { get; set; }
        #endregion

        public Endereco() : base()
        {
            Cidade = new Cidade();
            TipoEndereco = new TipoEndereco();
        }

    }
}
