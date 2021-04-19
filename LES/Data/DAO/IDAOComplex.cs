using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Data.DAO
{
    interface IDAOComplex
    {
        public EntidadeDominio IncludeAll(EntidadeDominio e);
    }
}
