using LES.Data.DAO;
using LES.Models;
using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LES.Controllers.Facade
{
    public class FacadeCrud<T> : IFacadeCrud<T> where T : EntidadeDominio
    {

        private IDAO<T> _dao;

        public FacadeCrud(IDAO<T> dao)
        {
            _dao = dao;
            DefinirStrategies();
        }

        private Dictionary<String, ICollection<Func<EntidadeDominio, string>>> _strategies;

        private void DefinirStrategies()
        {
            _strategies = new Dictionary<String, ICollection<Func<EntidadeDominio, string>>>
            {
                [typeof(Cliente).Name] = new List<Func<EntidadeDominio, string>>()
            };
        }
        private string ExecutarRegras(T e)
        {
            string nmClasse = e.GetType().Name;

            StringBuilder sb = new StringBuilder();

            var regras = _strategies[nmClasse];
            if (regras != null) 
            {
                foreach (var strat in regras)
                {
                    sb.Append(strat(e));
                }  
            }

            return sb.ToString();

        }

        public string Cadastrar(T e)
        {
            String msg = ExecutarRegras(e);

            if (msg == "")
            {
                return _dao.Add(e);
            }

            return msg;
        }

        public string Deletar(T e)
        {
            return _dao.Delete(e.Id);
        }

        public string Editar(T e)
        {
            String msg = ExecutarRegras(e);

            if (msg == "")
            {
                return _dao.Edit(e);
            }

            return msg;
        }

        public T GetEntidade(T e)
        {
            return _dao.Get(e.Id);
        }

        public IEnumerable<T> Listar(T e)
        {
            return _dao.List();
        }

        public IEnumerable<TType> Query<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select,
            params Expression<Func<TType, object>>[] include) where TType : class
        { 
            return _dao.Get<TType>(where, select, include);
        }
    }
}
