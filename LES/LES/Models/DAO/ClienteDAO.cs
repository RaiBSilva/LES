using LES.Models;
using LES.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LES.DAO
{
    public class ClienteDAO : IDAO
    {

        private AppDbContext Contexto;


        public ClienteDAO(AppDbContext contexto)
        {
            Contexto = contexto;
        }

        public string Add(EntidadeDominio e)
        {

            Cliente c = (Cliente)e;

            Contexto.Telefones.Add(c.Telefone);
            c.DtCadastro = DateTime.Now;
            Contexto.Clientes.Add(c);

            foreach (var end in c.Enderecos)
            {
                Contexto.Enderecos.Add(end);
            }

            try
            {
                Contexto.SaveChanges();
            }
            catch (DbUpdateException ex) {
                return ex.Message;
            }

            return "";
        }

        public string Delete(int id)
        {
            return "Elemento com id " + id + " removido.\n";
        }

        public string Edit(EntidadeDominio e)
        {
            Cliente c = (Cliente)e;
            StringBuilder str = new StringBuilder();

            str.Append(c.Id + "\n");
            str.Append(c.DtCadastro + "\n");
            str.Append(c.Nome + " ");

            return str.ToString();
        }

        public EntidadeDominio Get(int id)
        {
            return new EntidadeDominio();
        }

        public IList<EntidadeDominio> List()
        {
            return new List<EntidadeDominio>();
        }
    }
}
