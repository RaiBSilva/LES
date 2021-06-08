using LES.Models;
using LES.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Data.DAO
{
    public class DAOGrupoPreco<T> : DAO<T>, IGetIncludeAll where T : GrupoPreco
    {
        public DAOGrupoPreco(AppDbContext contexto) : base(contexto)
        {
        }

        public EntidadeDominio IncludeAll(EntidadeDominio e)
        {
            return _entidade.Where(g => g.Id == e.Id).Select(g => g)
                .Include(g => g.Livros)
                .FirstOrDefault();
        }
    }
}
