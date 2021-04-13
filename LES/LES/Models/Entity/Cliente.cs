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
        public string Codigo { get; set; }
        public string Cpf { get; set; }
        public virtual DateTime DtNascimento { get; set; }
        public Genero Genero { get; set; }
        public string Nome { get; set; }
        public int Nota { get; set; }
        public int UsuarioId { get; set; }

        public virtual IList<Endereco> Enderecos { get; set; }
        public virtual IList<Pedido> Pedidos { get; set; }
        public virtual IList<Telefone> Telefones { get; set; }
        public virtual IList<Cupom> Cupons { get; set; }
        public virtual Usuario Usuario { get; set; }
        #endregion

        public Cliente() : base()
        {
            Enderecos = new List<Endereco>();
            Pedidos = new List<Pedido>();
            Telefones = new List<Telefone>();
            Cupons = new List<Cupom>();
            Usuario = new Usuario();
        }

    }


}
