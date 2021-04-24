using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Data.DAO
{
    public interface IDAOTabelaRel<T> where T : MuitosPMuitos
    {
        public string Remove(T e);
    }
}
