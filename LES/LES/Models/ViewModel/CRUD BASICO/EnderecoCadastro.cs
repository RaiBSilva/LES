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
        public EnderecoCadastro() { }

        public int Id { get; set; }

        public DateTime DtCadastro { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        [Display(Name = "Nº")]
        public string Numero { get; set; }

        [Required]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Insira um CEP de sete dígitos.")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required]
        public string Complemento { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        [Required]
        [Display(Name = "Tipo de endereço")]
        public TipoEndereco TipoEndereco { get; set; }
            
        [Display(Name = "É endereço de entrega?")]
        public bool EEntrega { get; set; }

        [Display(Name = "É endereço de cobrança?")]
        public bool ECobranca { get; set; }

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
