using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.DAO
{
    interface IDAO
    {

        public IList<EntidadeDominio> list();
        public EntidadeDominio get(int id);
        public String add(EntidadeDominio e);
        public String edit(EntidadeDominio e);
        public String delete(int id);


    }
}
