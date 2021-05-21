using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LES.Controllers.Facade
{
    public interface IFacadeCrud
    {

        public IList<T> Listar<T>() where T : EntidadeDominio;
        public T GetEntidade<T>(T e) where T : EntidadeDominio;
        public IEnumerable<T> Query<T>(Expression<Func<T, bool>> where, Expression<Func<T, T>> select,
            params Expression<Func<T, object>>[] include) where T : EntidadeDominio;
        public string Cadastrar<T>(T e) where T : EntidadeDominio;
        public string Editar<T>(T e) where T : EntidadeDominio;
        public string Deletar<T>(T e) where T : EntidadeDominio;
        public T GetAllInclude<T>(T e) where T : EntidadeDominio;
        public IList<T> ListAllInclude<T>() where T : EntidadeDominio;

    }
}
