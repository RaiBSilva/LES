using LES.Models;
using LES.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LES.Data.DAO
{
    public class DAO<T> : IDAO<T> where T : EntidadeDominio
    {

        private AppDbContext _contexto;
        private DbSet<T> _entidade;

        public DAO(AppDbContext contexto)
        {
            _contexto = contexto;
            _entidade = _contexto.Set<T>();
        }

        public string Add(T e)
        {
            try
            {
                _entidade.Add(e);
            }
            catch(DbUpdateException ex)
            {
                return ex.Message;
            }
            return "";
        }

        public string Delete(int id)
        {

            var e = _entidade.Find(id);
            try
            {
                _entidade.Remove(e);
            }
            catch (DbUpdateException ex)
            {
                return ex.Message;
            }
            return "";

        }

        public string Edit(T e)
        {
            try
            {
                _contexto.Entry(e).State = EntityState.Modified;
            }
            catch (DbUpdateException ex)
            {
                return ex.Message;
            }
            return "";
        }

        public T Get(int id)
        {
            return _entidade.Find(id);
        }

        public IList<TType> Get<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select,
            params Expression<Func<TType, object>>[] include) where TType : class
        {
            IQueryable<TType> query = _entidade.Where(where).Select(select);

            if (include != null) query = ApplyIncludesOnQuery<TType>(query, include);

            return query.ToList();
        }

        private IQueryable<TType> ApplyIncludesOnQuery<TType>(IQueryable<TType> query, 
            params Expression<Func<TType, object>>[] includeProperties) where TType : class
        {
            // Return Applied Includes query
            return (includeProperties.Aggregate(query, (current, include) => current.Include(include)));
        }

        public IList<T> List()
        {
            return _entidade.ToList();
        }

        public void Save()
        {
            _contexto.SaveChanges();
        }
    }
}
