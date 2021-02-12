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
        public string add(EntidadeDominio e)
        {
            Cliente c = (Cliente)e;
            StringBuilder str = new StringBuilder();

            str.Append(c.id + "\n");
            str.Append(c.dtCadastro + "\n");
            str.Append(c.nome + " ");
            str.Append(c.documentos[0].tipoDocumento + "\n") ;
            str.Append(c.documentos[0].codigo + "\n");
            str.Append(c.enderecos[0].logradouro + "\n");

            return str.ToString();
        }

        public string delete(int id)
        {
            return "Elemento com id" + id + "removido.\n";
        }

        public string edit(EntidadeDominio e)
        {
            Cliente c = (Cliente)e;
            StringBuilder str = new StringBuilder();

            str.Append(c.id + "\n");
            str.Append(c.dtCadastro + "\n");
            str.Append(c.nome + " ");
            str.Append(c.documentos[0].tipoDocumento + "\n");
            str.Append(c.documentos[0].codigo + "\n");
            str.Append(c.enderecos[0].logradouro + "\n");

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
