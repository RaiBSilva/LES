using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Negocio.Strategy
{
    interface IStrategy
    {
        public string Validar(EntidadeDominio e);
    }
}
