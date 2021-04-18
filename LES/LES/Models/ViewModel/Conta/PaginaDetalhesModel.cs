using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class PaginaDetalhesModel : IViewModel
    {
        public DetalhesInfoModel InfoUsuario { get; set; }
        public IList<DetalhesEnderecoModel> Enderecos { get;set; }
        public IList<DetalhesTelefoneModel> Telefones { get; set; }
        public IList<DetalhesCartaoModel> Cartoes { get; set; }
        public IList<PedidoModel> Pedidos { get; set; }
        public IList<CupomModel> Cupons { get; set; }

        public PaginaDetalhesModel()
        {
            InfoUsuario = new DetalhesInfoModel();
            InfoUsuario.NotaUsuario = 0;
            Enderecos = new List<DetalhesEnderecoModel>();
            Telefones = new List<DetalhesTelefoneModel>();
            Cartoes = new List<DetalhesCartaoModel>();
            Pedidos = new List<PedidoModel>();
            Cupons = new List<CupomModel>();
        }
    }

    public class DetalhesInfoModel : InfoBaseModel, IViewModel
    {
        [Display(Name ="Sua nota de cliente SóRaiva:")]
        public int NotaUsuario { get; set; }
    }

    public class DetalhesEnderecoModel : EnderecoBaseModel, IViewModel
    {
        [Display(Name = "Nome do endereço (ex: casa, trabalho, etc...)")]
        public string NomeEndereco { get; set; }

        [Display(Name = "É endereço de entrega?")]
        public bool EEntrega { get; set; }

        [Display(Name = "É endereço de cobrança?")]
        public bool ECobranca { get; set; }

        [Display(Name = "É o preferencial?")]
        public bool EPreferencial { get; set; }
        public bool Edicao { get; set; }

    }

    public class DetalhesTelefoneModel : TelefoneBaseModel, IViewModel
    { 
        [Display(Name = "É preferencial?")]
        public bool EPreferencial { get; set; }
        public bool Edicao { get; set; }
    }

    public class DetalhesCartaoModel : CartaoBaseModel, IViewModel
    {
        [Display(Name = "É preferencial?")]
        public bool EPreferencial { get; set; }
        public bool Edicao { get; set; }
    }
}
