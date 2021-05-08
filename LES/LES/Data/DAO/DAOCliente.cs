using LES.Models;
using LES.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LES.Data.DAO
{
    public class DAOCliente<T> : DAO<T>,  IGetIncludeAll where T : Cliente
    {
        public DAOCliente(AppDbContext contexto) : base(contexto)
        {
        }

        public EntidadeDominio IncludeAll(EntidadeDominio e)
        {
            Cliente request = (Cliente)e;
            string email = request.Usuario.Email;

            Cliente response = _contexto.Clientes.Select(c => c).Where(c => c.Usuario.Email == email)
                .Include(c => c.Carrinho)
                    .ThenInclude(c => c.CarrinhoLivro)
                    .ThenInclude(c => c.Livro)
                .Include(c => c.Cartoes).ThenInclude(c => c.Bandeira)
                .Include(c => c.Enderecos)
                    .ThenInclude(e => e.Cidade)
                    .ThenInclude(c => c.Estado)
                    .ThenInclude(e => e.Pais)
                .Include(c => c.Enderecos)
                    .ThenInclude(e => e.TipoEndereco)
                .Include(c => c.Telefones).ThenInclude(t => t.TipoTelefone)
                .Include(c => c.Usuario)
                .Include(c => c.Cupons)
                .Include(c => c.Pedidos)
                    .ThenInclude(p => p.CartaoPedidos)
                .Include(c => c.Pedidos)
                    .ThenInclude(p => p.LivrosPedidos)
                    .ThenInclude(l => l.Livro)
                    .ThenInclude(l => l.Editora)
                .Include(c => c.Trocas)
                    .ThenInclude(t => t.LivroPedido)
                    .ThenInclude(l => l.Livro)
                .FirstOrDefault();

            return response;
        }

    }
}
