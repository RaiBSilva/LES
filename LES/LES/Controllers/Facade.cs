using LES.DAO;
using LES.Models.Entity;
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

        public Facade() 
        {
            definirDAO();
            definirStrategies();
        }

        private void definirDAO() { }

        private void definirStrategies() { }

        private String executarRegras(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            StringBuilder msgBuilder = new StringBuilder();

            String msg = msgBuilder.ToString();

            return msg;

        }

        public IEnumerable<EntidadeDominio> listar(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            IEnumerable<EntidadeDominio> entidades = dao.list();
            return entidades;
        }

        public EntidadeDominio getEntidade(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            return dao.get(e.Id);
        }

        public String cadastrar(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            String msg = executarRegras(e);

            if (msg != "")
            {
                return dao.add(e);
            }

            return msg;
        }

        public String editar(EntidadeDominio e)
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            String msg = executarRegras(e);

            if (msg != "")
            {
                return dao.edit(e);
            }

            return msg;
        }

        public String deletar(EntidadeDominio e) 
        {
            String nmClasse = e.GetType().Name;
            IDAO dao = _daos[nmClasse];

            return dao.delete(e.Id);
        }

    }
}
