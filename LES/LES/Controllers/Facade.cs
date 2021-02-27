using LES.DAO;
using LES.Models.Entity;
using LES.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LES.Controllers
{
    public class Facade
    {

        private Dictionary<String, IDAO> _daos;
        private Dictionary<String, ICollection<IStrategy>> _strategies;

        public Facade() 
        {
            DefinirDAO();
            DefinirStrategies();
        }

        private void DefinirDAO() {
            _daos = new Dictionary<string, IDAO>();
            _daos[typeof(Cliente).Name] = new ClienteDAO();
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

            return msg;

        }

        public IEnumerable<EntidadeDominio> Listar(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            IEnumerable<EntidadeDominio> entidades = dao.list();
            return entidades;
        }

        public EntidadeDominio GetEntidade(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            return dao.get(e.Id);
        }

        public String Cadastrar(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            String msg = ExecutarRegras(e);

            if (msg != "")
            {
                return dao.add(e);
            }

            return msg;
        }

        public String Editar(EntidadeDominio e)
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            String msg = ExecutarRegras(e);

            if (msg != "")
            {
                return dao.edit(e);
            }

            return msg;
        }

        public String Deletar(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            return dao.delete(e.Id);
        }

    }
}
