using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LES.Controllers.Facade
{
    public interface IFacadeCrud<T> where T: EntidadeDominio
    {

        public IEnumerable<T> Listar(T e);
        public T GetEntidade(T e);
        public IEnumerable<TType> Query<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select,
            params Expression<Func<TType, object>>[] include) where TType : class;
        public String Cadastrar(T e);
        public String Editar(T e);
        public String Deletar(T e);


    }
}
