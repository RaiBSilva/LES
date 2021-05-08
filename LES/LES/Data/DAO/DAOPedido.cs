using LES.Models;
using LES.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Data.DAO
{
    public class DAOPedido<T> : DAO<T>, IGetIncludeAll, IListIncludeAll where T : Pedido
    {
        public DAOPedido(AppDbContext contexto) : base(contexto)
        {
        }

        public EntidadeDominio IncludeAll(EntidadeDominio e)
        {
            Pedido request = (Pedido)e;

            return _contexto.Pedidos.Where(p => p.Id == request.Id)
                .Include(p => p.CartaoPedidos)
                    .ThenInclude(c => c.Cartao)
                    .ThenInclude(c => c.Bandeira)
                .Include(p => p.Cliente)
                .Include(p => p.Endereco)
                    .ThenInclude(e => e.Cidade)
                    .ThenInclude(c => c.Estado)
                    .ThenInclude(e => e.Pais)
                .Include(p => p.LivrosPedidos)
                    .ThenInclude(l => l.Livro)
                    .ThenInclude(l => l.Editora)
                .FirstOrDefault();
        }

        public IList<EntidadeDominio> ListIncludeAll()
        {
            return _contexto.Pedidos.Select(p => p)
                .Include(p => p.CartaoPedidos)
                    .ThenInclude(c => c.Cartao)
                    .ThenInclude(c => c.Bandeira)
                .Include(p => p.Cliente)
                    .ThenInclude(c => c.Carrinho)
                    .ThenInclude(c => c.CarrinhoLivro)
                    .ThenInclude(c => c.Livro)
                .Include(p => p.Cliente)
                    .ThenInclude(c => c.Cartoes)
                    .ThenInclude(c => c.Bandeira)
                .Include(p => p.Cliente)
                    .ThenInclude(c => c.Enderecos)
                    .ThenInclude(e => e.Cidade)
                    .ThenInclude(c => c.Estado)
                    .ThenInclude(e => e.Pais)
                .Include(p => p.Endereco)
                    .ThenInclude(e => e.Cidade)
                    .ThenInclude(c => c.Estado)
                    .ThenInclude(e => e.Pais)
                .Include(p => p.LivrosPedidos)
                    .ThenInclude(l => l.Livro)
                    .ThenInclude(l => l.Editora)
                .Cast<EntidadeDominio>()
                .ToList();
        }
    }
}
