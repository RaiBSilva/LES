using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LES.Data.DAO
{
    public interface IDAO<T> where T : EntidadeDominio
    {

        public IList<T> List();
        public T Get(int id);
        public IList<TType> Get<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select) where TType : class;
        public String Add(T e);
        public String Edit(T e);
        public String Delete(int id);
        public void Save();

    }
}
