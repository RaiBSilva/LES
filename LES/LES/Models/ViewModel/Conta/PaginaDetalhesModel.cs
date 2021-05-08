using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Conta
{
    public class PaginaDetalhesModel : IViewModel
    {
        public DetalhesInfoModel InfoUsuario { get; set; } = new DetalhesInfoModel { NotaUsuario = 0};
        public IList<DetalhesEnderecoModel> Enderecos { get; set; } = new List<DetalhesEnderecoModel>();
        public IList<DetalhesTelefoneModel> Telefones { get; set; } = new List<DetalhesTelefoneModel>();
        public IList<DetalhesCartaoModel> Cartoes { get; set; } = new List<DetalhesCartaoModel>();
        public IList<PedidoModel> Pedidos { get; set; } = new List<PedidoModel>();
        public IList<TrocaModel> Trocas { get; set; } = new List<TrocaModel>();
        public IList<CupomModel> Cupons { get; set; } = new List<CupomModel>();

        public PaginaDetalhesModel()
        {
        }
    }

    public class DetalhesInfoModel : InfoBaseModel, IViewModel
    {
        [Display(Name ="Sua nota de cliente SóRaiva:")]
        public int NotaUsuario { get; set; }
    }

    public class DetalhesEnderecoModel : EnderecoBaseModel, IViewModel
    {

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
