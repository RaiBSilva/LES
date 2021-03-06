using LES.DAO;
using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LES.Models.DAO
{
    public class EnderecoDAO : IDAO
    {

        private AppDbContext _contexto;


        public EnderecoDAO(AppDbContext contexto)
        {
            _contexto = contexto;
        }


        public string Add(EntidadeDominio e)
        {
            Endereco end = (Endereco)e;

            end.DtCadastro = DateTime.Now;
            _contexto.Enderecos.Add(end);

            try
            {
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                string str = "Erro no banco:\n" + ex.Message;
                System.Console.WriteLine(str);
                return str;
            }

            return "";
        }

        public string Delete(int id)
        {
            Endereco e = (Endereco)Get(id);

            if (e is object)
            {
                _contexto.Enderecos.Remove(e);

                try
                {
                    _contexto.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    string str = "Erro no banco:\n" + ex.Message;
                    System.Console.WriteLine(str);
                    return str;
                }

                return "";
            }
            string str2 = "Cliente inválido.";
            System.Console.WriteLine(str2);
            return str2;
        }

        public string Edit(EntidadeDominio e)
        {
            Endereco enderecoNovo = (Endereco)e;

            var enderecoVelho = (Endereco)Get(enderecoNovo.Id);

            enderecoVelho.TipoEndereco = enderecoNovo.TipoEndereco;
            enderecoVelho.Logradouro = enderecoNovo.Logradouro;
            enderecoVelho.Numero = enderecoNovo.Numero;
            enderecoVelho.Cep = enderecoNovo.Cep;
            enderecoVelho.Complemento = enderecoNovo.Complemento;
            enderecoVelho.Observacoes = enderecoNovo.Observacoes;
            enderecoVelho.Cidade = enderecoNovo.Cidade;
            enderecoVelho.Cidade.Estado = enderecoNovo.Cidade.Estado;
            enderecoVelho.Cidade.Estado.Pais = enderecoNovo.Cidade.Estado.Pais;

            try
            {
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                string str = "Erro no banco:\n" + ex.Message;
                System.Console.WriteLine(str);
                return str;
            }

            return "";
        }

        public EntidadeDominio Get(int id)
        {
            Endereco endereco = new Endereco();

            try 
            {
                endereco = _contexto.Enderecos.Where(e => e.Id == id)
                        .Include
                        (
                            e => e.Cidade
                        )
                            .ThenInclude
                            (
                                c => c.Estado
                            )
                                .ThenInclude
                                (
                                    e => e.Pais
                                )
                                .SingleOrDefault();
            }
            catch (ArgumentNullException ex)
            {
                string str = "Argumento nulo\n" + ex.Message;
                System.Console.WriteLine(str);
                return null;
            }
            catch (InvalidOperationException ex)
            {
                string str = "Há mais de um objeto com o mesmo id (como diacho isso aconteceu???)\n" + ex.Message;
                System.Console.WriteLine(str);
                return null;
            }

            return endereco;
        }

        public IList<EntidadeDominio> List()
        {
            IList<Endereco> enderecos;

            try
            {
                enderecos = _contexto.Enderecos
                        .Include
                        (
                            e => e.Cidade
                        )
                            .ThenInclude
                            (
                                c => c.Estado
                            )
                                .ThenInclude
                                (
                                    e => e.Pais
                                )
                        .ToList();
            }
            catch (ArgumentNullException ex)
            {
                string str = "Argumento nulo\n" + ex.Message;
                System.Console.WriteLine(str);
                return null;
            }

            IList<EntidadeDominio> entidades = new List<EntidadeDominio>();

            foreach (var e in enderecos)
            {
                entidades.Add((EntidadeDominio)e);
            }

            return entidades;

        }
    }
}
