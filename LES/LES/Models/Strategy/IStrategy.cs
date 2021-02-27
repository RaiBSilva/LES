using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Strategy
{
    interface IStrategy
    {
        public string Validar(string s);
    }
}
