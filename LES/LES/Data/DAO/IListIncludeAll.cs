﻿using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Data.DAO
{
    interface IListIncludeAll
    {
        public IList<EntidadeDominio> ListIncludeAll();

    }
}
