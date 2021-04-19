using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Negocio.Strategy
{
    interface IStrategy<T> where T : EntidadeDominio
    {
        public string Validar(T e);
    }
}
