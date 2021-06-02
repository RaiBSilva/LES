using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Schedulers
{
    public interface IAgendarJob
    {
        public void AgendarJob(DateTime dataExecucao, Carrinho carrinhoCli, string emailCliente);

        public void CancelaJob(string keyStr);

    }
}
