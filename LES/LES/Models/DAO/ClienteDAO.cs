using LES.Models;
using LES.Models.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LES.DAO
{
    public class ClienteDAO : IDAO
    {

        private AppDbContext Contexto;

        public string add(EntidadeDominio e)
        {
            Cliente c = (Cliente)e;

            /*StringBuilder str = new StringBuilder();

            str.Append(c.Id + "\n");
            str.Append(c.DtCadastro + "\n");
            str.Append(c.Nome + " ");
            str.Append(c.Documentos[0].TipoDocumento + "\n") ;
            str.Append(c.Documentos[0].Codigo + "\n");
            str.Append(c.EnderecosEntrega[0].Logradouro + "\n");

            return str.ToString();*/

            Contexto.Clientes.Add(c);
        }

        public string delete(int id)
        {
            return "Elemento com id" + id + "removido.\n";
        }

        public string edit(EntidadeDominio e)
        {
            Cliente c = (Cliente)e;
            StringBuilder str = new StringBuilder();

            str.Append(c.Id + "\n");
            str.Append(c.DtCadastro + "\n");
            str.Append(c.Nome + " ");
            str.Append(c.Documentos[0].TipoDocumento + "\n");
            str.Append(c.Documentos[0].Codigo + "\n");
            str.Append(c.EnderecosEntrega[0].Logradouro + "\n");

            return str.ToString();
        }

        public EntidadeDominio get(int id)
        {
            return new EntidadeDominio();
        }

        public IList<EntidadeDominio> list()
        {
            return new List<EntidadeDominio>();
        }
    }
}
