using LES.Models;
using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LES.Controllers
{
    /*
    public class Facade : IFacadeCrud
    {
       
        AppDbContext Contexto;

        public Facade(AppDbContext contexto)
        {
            Contexto = contexto;
            DefinirDAO();
            DefinirStrategies();
        }

        private Dictionary<String, IDAO> _daos;
        private Dictionary<String, ICollection<IStrategy>> _strategies;

        private void DefinirDAO() {
            _daos = new Dictionary<string, IDAO>();
            _daos[typeof(Cliente).Name] = new ClienteDAO(Contexto);
            _daos[typeof(Endereco).Name] = new EnderecoDAO(Contexto);
        }

        private void DefinirStrategies() {
            _strategies = new Dictionary<String, ICollection<IStrategy>>();
            _strategies[typeof(Cliente).Name] = new List<IStrategy>();
        }

        private String ExecutarRegras(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            StringBuilder msgBuilder = new StringBuilder();

            String msg = msgBuilder.ToString();

            return "";

        }

        public IEnumerable<EntidadeDominio> Listar(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            IEnumerable<EntidadeDominio> entidades = dao.List();
            return entidades;
        }

        public EntidadeDominio GetEntidade(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            return dao.Get(e.Id);
        }

        public String Cadastrar(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            String msg = ExecutarRegras(e);

            if (msg == "")
            {
                return dao.Add(e);
            }

            return msg;
        }

        public String Editar(EntidadeDominio e)
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            String msg = ExecutarRegras(e);

            if (msg == "")
            {
                return dao.Edit(e);
            }

            return msg;
        }

        public String Deletar(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            return dao.Delete(e.Id);
        }

    }
    */
}
