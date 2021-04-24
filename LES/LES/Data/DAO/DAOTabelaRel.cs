using LES.Models;
using LES.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Data.DAO
{
    public class DAOTabelaRel<T> : IDAOTabelaRel<T> where T : MuitosPMuitos
    {
        AppDbContext _contexto;
        DbSet<T> _entidade;

        public DAOTabelaRel(AppDbContext contexto)
        {
            _contexto = contexto;
            _entidade = _contexto.Set<T>();
        }

        public string Remove(T e)
        {
            try { 
                _entidade.Remove(e);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
    }
}
