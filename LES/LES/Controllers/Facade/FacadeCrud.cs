using LES.Models;
using LES.Models.Entity;
using LES.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Controllers.Facade
{
    public class FacadeCrud : IFacadeCrud
    {

        AppDbContext Contexto;

        public FacadeCrud(AppDbContext contexto)
        {
            Contexto = contexto;
            DefinirStrategies();
        }

        private Dictionary<String, ICollection<IStrategy>> _strategies;

        private void DefinirStrategies()
        {
            _strategies = new Dictionary<String, ICollection<IStrategy>>();
            _strategies[typeof(Cliente).Name] = new List<IStrategy>();
        }

        public string Cadastrar(EntidadeDominio e)
        {
            throw new NotImplementedException();
        }

        public string Deletar(EntidadeDominio e)
        {
            throw new NotImplementedException();
        }

        public string Editar(EntidadeDominio e)
        {
            throw new NotImplementedException();
        }

        public EntidadeDominio GetEntidade(EntidadeDominio e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EntidadeDominio> Listar(EntidadeDominio e)
        {
            throw new NotImplementedException();
        }
    }
}
