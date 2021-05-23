using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Schedulers
{
    public interface IAgendarJob
    {
        public void AgendarJob(DateTime dataExecucao, int idCarrinho, string emailCliente);

        public void CancelaJob(string keyStr);

    }
}
