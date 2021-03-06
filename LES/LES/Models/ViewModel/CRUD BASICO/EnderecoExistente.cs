using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel
{
    public class EnderecoExistente
    {
        public IList<EnderecoCadastro> Enderecos { get; set; }
        public int Id { get; set; }

        public EnderecoExistente(IList<EnderecoCadastro> enderecos, int id)
        {
            Enderecos = enderecos;
            Id = id;
        }
    }
}
