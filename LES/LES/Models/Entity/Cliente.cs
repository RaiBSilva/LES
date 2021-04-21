using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LES.Models.Entity
{

    public enum Genero { 
        Masculino,
        Feminino,
        Outro
    }

    public class Cliente : EntidadeDominio
    {
        #region Propriedades
        public int? CarrinhoId { get; set; }
        public string Codigo { get; set; }
        public string Cpf { get; set; }
        public virtual DateTime DtNascimento { get; set; }
        public Genero Genero { get; set; }
        public string Nome { get; set; }
        public int Nota { get; set; }
        public int UsuarioId { get; set; }

        public virtual Carrinho Carrinho { get; set; } = new Carrinho();
        public virtual IList<CartaoCredito> Cartoes { get; set; } = new List<CartaoCredito>();
        public virtual IList<Endereco> Enderecos { get; set; } = new List<Endereco>();
        public virtual IList<Pedido> Pedidos { get; set; } = new List<Pedido>();
        public virtual IList<Telefone> Telefones { get; set; } = new List<Telefone>();
        public virtual IList<Cupom> Cupons { get; set; } = new List<Cupom>();
        public virtual Usuario Usuario { get; set; } = new Usuario();
        #endregion

    }


}
