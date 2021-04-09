using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Controllers.Facade
{
    public interface IFacadeCrud
    {

        public IEnumerable<EntidadeDominio> Listar(EntidadeDominio e);
        public EntidadeDominio GetEntidade(EntidadeDominio e);
        public String Cadastrar(EntidadeDominio e);
        public String Editar(EntidadeDominio e);
        public String Deletar(EntidadeDominio e);


    }
}
