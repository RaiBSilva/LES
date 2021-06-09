using LES.Models;
using LES.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Data.DAO
{
    public class DAOLivro<T> : DAO<T>, IGetIncludeAll, IListIncludeAll where T : Livro
    {

        public DAOLivro(AppDbContext contexto) : base(contexto)
        {

        }

        public EntidadeDominio IncludeAll(EntidadeDominio e)
        {
            Livro request = (Livro)e;
            string codBar = request.CodigoBarras;

            Livro response = _contexto.Livros.Select(l => l).Where(l => l.CodigoBarras == codBar)
                .Include(l => l.Ativacoes)
                    .ThenInclude(a => a.Categoria)
                .Include(l => l.Inativacoes)
                    .ThenInclude(i => i.Categoria)
                .Include(l => l.Editora)
                .Include(l => l.GrupoPreco)
                .Include(l => l.LivroPedidos)
                    .ThenInclude(l => l.Pedido)
                .Include(l => l.LivrosCategoriaLivros)
                    .ThenInclude(l => l.CategoriaLivro).FirstOrDefault();

            return response;
        }

        public IList<EntidadeDominio> ListIncludeAll()
        {
            IList<EntidadeDominio> response = _contexto.Livros.Select(l => l)
                .Include(l => l.Ativacoes)
                    .ThenInclude(a => a.Categoria)
                .Include(l => l.Inativacoes)
                    .ThenInclude(i => i.Categoria)
                .Include(l => l.Editora)
                .Include(l => l.GrupoPreco)
                .Include(l => l.LivroPedidos)
                    .ThenInclude(l => l.Pedido)
                .Include(l => l.LivrosCategoriaLivros)
                    .ThenInclude(l => l.CategoriaLivro).Cast<EntidadeDominio>().ToList();

            return response;
        }
    }
}
