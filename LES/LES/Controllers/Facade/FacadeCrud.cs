using LES.Data.DAO;
using LES.Models;
using LES.Models.Entity;
using LES.Negocio.Strategy;
using LES.Negócio.Strategy.ClienteStrategy;
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

        private Dictionary<string, ICollection<IStrategy>> _strategiesValidacao;
        private Dictionary<string, IGetIncludeAll> _daosGetIncludeAll;
        private Dictionary<string, IListIncludeAll> _daosListIncludeAll;

        private void DefinirStrategies()
        {
            _strategiesValidacao = new Dictionary<String, ICollection<IStrategy>>
            {
                [typeof(Cliente).Name] = new List<IStrategy>
                {
                    new ValidarClienteNullStrategy(),
                    new ValidarCepStrategy(),
                    new ValidarDataNascimentoStrategy(),
                    new ValidarCvvCartaoStrategy(),
                    new ValidarDataNascimentoStrategy(),
                    new ValidarDddStrategy(),
                    new ValidarNumeroCartaoStrategy(),
                    new ValidarTelefoneStrategy()
                },
                [typeof(Carrinho).Name] = new List<IStrategy>(),
                [typeof(Livro).Name] = new List<IStrategy>()
            };
        }
        private void DefinirDAOs()
        {
            _daosGetIncludeAll = new Dictionary<string, IGetIncludeAll>
            {
                [typeof(Cliente).Name] = new DAOCliente<Cliente>(_contexto),
                [typeof(Carrinho).Name] = new DAOCarrinho<Carrinho>(_contexto),
                [typeof(Livro).Name] = new DAOLivro<Livro>(_contexto)
            };

            _daosListIncludeAll = new Dictionary<string, IListIncludeAll>
            {
                [typeof(Livro).Name] = new DAOLivro<Livro>(_contexto)
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
                    sb.Append(strat.Validar(e));
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

            if (_daosGetIncludeAll.ContainsKey(nmClasse)) return (T)_daosGetIncludeAll[nmClasse].IncludeAll(e);
            return null;

        }

        public IList<T> ListAllInclude()
        {
            string nmClasse = typeof(T).Name;

            if (_daosListIncludeAll.ContainsKey(nmClasse)) return _daosListIncludeAll[nmClasse].ListIncludeAll().Cast<T>().ToList();
            return null;
        }
    }
}
