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
        private AppDbContext _contexto;

        public FacadeCrud(IDAO<T> dao, AppDbContext context)
        {
            _dao = dao;
            _contexto = context;
            DefinirStrategies();
            DefinirDAOs();
        }

        private Dictionary<string, ICollection<Func<EntidadeDominio, string>>> _strategiesValidacao;
        private Dictionary<string, IDAOComplex> _daosComplexos;

        private void DefinirStrategies()
        {
            _strategiesValidacao = new Dictionary<String, ICollection<Func<EntidadeDominio, string>>>
            {
                [typeof(Cliente).Name] = new List<Func<EntidadeDominio, string>>()
            };
        }
        private void DefinirDAOs()
        {
            _daosComplexos = new Dictionary<string, IDAOComplex>
            {
                [typeof(Cliente).Name] = new DAOCliente<Cliente>(_contexto)
            };
        }

        private string ExecutarRegras(T e)
        {
            string nmClasse = e.GetType().Name;

            StringBuilder sb = new StringBuilder();

            var regras = _strategiesValidacao[nmClasse];
            sb.Append("");
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
            string msg = ExecutarRegras(e);

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
            string msg = ExecutarRegras(e);

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

        public IList<T> Listar()
        {
            return _dao.List();
        }

        public IEnumerable<TType> Query<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select,
            params Expression<Func<TType, object>>[] include) where TType : class
        { 
            return _dao.Get(where, select, include);
        }
        public T GetAllInclude(T e)
        {
            string nmClasse = typeof(T).Name;

            if (_daosComplexos.ContainsKey(nmClasse)) return (T)_daosComplexos[nmClasse].IncludeAll(e);
            return null;

        }
    }
}
