using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace LES.Models.ViewModel
{
    public class EnderecoCadastro
    {

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        [StringLength(7)]
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Observacoes { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
        public Boolean EEntrega { get; set; }
        public Boolean ECobranca { get; set; }

        public EnderecoCadastro(string logradouro, string numero, 
            string cep, string complemento, string cidade, 
            string estado, string pais, string observacoes, 
            TipoEndereco tipoEndereco, bool eEntrega, bool eCobranca)
        {
            Logradouro = logradouro;
            Numero = numero;
            Cep = cep;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Observacoes = observacoes;
            TipoEndereco = tipoEndereco;
            EEntrega = eEntrega;
            ECobranca = eCobranca;
        }
    }
}
