using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.DAO
{
    interface IDAO
    {

        public IList<EntidadeDominio> List();
        public EntidadeDominio Get(int id);
        public String Add(EntidadeDominio e);
        public String Edit(EntidadeDominio e);
        public String Delete(int id);


    }
}
