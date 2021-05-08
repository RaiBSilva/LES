using LES.Models;
using LES.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Data.DAO
{
    public class DAOTroca<T> : DAO<T>, IGetIncludeAll, IListIncludeAll where T : Troca
    {
        public DAOTroca(AppDbContext contexto) : base(contexto) { }

        public EntidadeDominio IncludeAll(EntidadeDominio e)
        {
            return _contexto.Trocas.Where(t => t.Id == e.Id)
                .Include(t => t.Cliente)
                    .ThenInclude(c => c.Usuario)
                .Include(t => t.LivroPedido)
                    .ThenInclude(t => t.Livro)
                    .ThenInclude(l => l.Editora)
                .Include(t => t.LivroPedido)
                    .ThenInclude(t => t.Pedido)
                .FirstOrDefault();
        }

        public IList<EntidadeDominio> ListIncludeAll()
        {
            return _contexto.Trocas.Select(t => t)
                .Include(t => t.Cliente)
                    .ThenInclude(c => c.Usuario)
                .Include(t => t.LivroPedido)
                    .ThenInclude(t => t.Livro)
                    .ThenInclude(l => l.Editora)
                .Include(t => t.LivroPedido)
                    .ThenInclude(t => t.Pedido)
                .Cast<EntidadeDominio>()
                .ToList();
        }
    }
}
