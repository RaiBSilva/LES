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

        public IList<T> Listar();
        public T GetEntidade(T e);
        public IEnumerable<TType> Query<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select,
            params Expression<Func<TType, object>>[] include) where TType : class;
        public string Cadastrar(T e);
        public string Editar(T e);
        public string Deletar(T e);
        public T GetAllInclude(T e);
        public IList<T> ListAllInclude();

    }
}
