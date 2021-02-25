using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LES.Models.Entity
{
    public enum TipoEndereco 
    {
        Casa,
        Apartamento,
        Outro
    }

    [Table("ENDERECOS")]
    public class Endereco : EntidadeDominio
    {
        #region Propriedades

        [Required, Column("end_logradouro")]
        public string Logradouro { get; set; }
        
        [Required, Column("end_numero")]
        public string Numero { get; set; }

        [Required, Column("end_cep")]
        public string Cep { get; set; }

        [Required, Column("end_complemento")]
        public string Complemento { get; set; }

        [Column("end_observacoes")]
        public string Observacoes { get; set; }

        [Required, Column("end_tipo")]
        public TipoEndereco TipoEndereco { get; set; }

        [Required, Column("end_e_entrega")]
        public Boolean EEntrega { get; set; }

        [Required, Column("end_e_cobranca")]
        public Boolean ECobranca { get; set; }

        [Required, Column("end_e_residencia")]
        public Boolean EResidencia { get; set; }

        [Required, Column("end_cid_id"), ForeignKey("FK_END_CID")]
        public virtual Cidade Cidade { get; set; }
        #endregion

        #region Construtores da Classe
        public Endereco() { }

        private void DefinirAtributos(String logradouro, String numero, String cep, String complemento, string observacoes, 
            TipoEndereco tipoEndereco, Boolean eEntrega, Boolean eCobranca, Boolean eResidencia, Cidade cidade)
        {
            Logradouro = logradouro;
            Numero = numero;
            Cep = cep;
            Complemento = complemento;
            Cidade = cidade;
            Observacoes = observacoes;
            TipoEndereco = tipoEndereco;
            EEntrega = eEntrega;
            ECobranca = eCobranca;
            EResidencia = eResidencia;
        }

        public Endereco(string logradouro, string numero, string cep, string complemento,string observacoes, 
            TipoEndereco tipoEndereco, Boolean eEntrega, Boolean eCobranca, Boolean eResidencia, Cidade cidade)
        {
            DefinirAtributos(logradouro, numero, cep, complemento, observacoes, tipoEndereco,
                eEntrega, eCobranca, eResidencia, cidade);
        }

        public Endereco(int id, DateTime dtCadastro, string logradouro, string numero, string cep,
            string complemento, string observacoes, TipoEndereco tipoEndereco,
             Boolean eEntrega, Boolean eCobranca, Boolean eResidencia, Cidade cidade) : base(id, dtCadastro)
        {
            DefinirAtributos(logradouro, numero, cep, complemento, observacoes, tipoEndereco,
                eEntrega, eCobranca, eResidencia, cidade);
        }
        #endregion

    }
}
