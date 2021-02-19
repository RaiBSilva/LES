using System;

namespace LES.Models.Entity
{
    public enum TipoEndereco 
    {
        Casa,
        Apartamento,
        Outro
    }

    public class Endereco : EntidadeDominio
    {
        #region Propriedades
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public Cidade Cidade { get; set; }
        public string Observacoes { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
        #endregion

        #region Construtores da Classe
        public Endereco() { }

        private void DefinirAtributos(String logradouro, String numero, String cep, String complemento, Cidade cidade,
            string observacoes, TipoEndereco tipoEndereco)
        {
            Logradouro = logradouro;
            Numero = numero;
            Cep = cep;
            Complemento = complemento;
            Cidade = cidade;
            Observacoes = observacoes;
            TipoEndereco = tipoEndereco;
        }

        public Endereco(string logradouro, string numero, string cep, string complemento, Cidade cidade,
            string observacoes, TipoEndereco tipoEndereco)
        {
            DefinirAtributos(logradouro, numero, cep, complemento, cidade, observacoes, tipoEndereco);
        }

        public Endereco(int id, DateTime dtCadastro, string logradouro, string numero, string cep,
            string complemento, Cidade cidade, string observacoes, TipoEndereco tipoEndereco)
            : base(id, dtCadastro)
        {
            DefinirAtributos(logradouro, numero, cep, complemento, cidade, observacoes, tipoEndereco);
        }
        #endregion

    }
}
