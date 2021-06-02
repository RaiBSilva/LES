using LES.Controllers.Facade;
using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Schedulers
{
    public interface IAgendarJob
    {
        public void AgendarJob(DateTime dataExecucao, Carrinho carrinhoCli, string emailCliente, IFacadeCrud facade);

        public void CancelaJob(string keyStr);

    }
}
