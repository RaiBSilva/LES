using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class RegistroModel
    {
        public InfoBaseModel InfoUsuario { get; set; }
        public SenhaBaseModel Senha { get; set; }
        public TelefoneBaseModel Telefone {get;set;}
        public EnderecoBaseModel Endereco {get;set;}
        public CartaoBaseModel Cartao { get; set; }

        public RegistroModel()
        {
            InfoUsuario = new InfoBaseModel();
            Senha = new SenhaBaseModel();
            Endereco = new EnderecoBaseModel();
            Cartao = new CartaoBaseModel();
        }

    }
}
