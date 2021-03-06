using LES.Models;
using LES.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LES.DAO
{
    public class ClienteDAO : IDAO
    {

        private AppDbContext _contexto;


        public ClienteDAO(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public string Add(EntidadeDominio e)
        {

            Cliente c = (Cliente)e;

            c.DtCadastro = DateTime.Now;
            foreach (var end in c.Enderecos) end.DtCadastro = DateTime.Now;

            _contexto.Add(c);

            try
            {
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex) {
                string str = "Erro no banco:\n" + ex.Message;
                System.Console.WriteLine(str);
                return str;
            }

            return "";
        }

        public string Delete(int id)
        {
            Cliente cliente = (Cliente)Get(id);

            if (cliente is object)
            {
                _contexto.Clientes.Remove(cliente);

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
            Cliente clienteNovo = (Cliente)e;

            var clienteVelho = (Cliente)Get(clienteNovo.Id);
            clienteVelho = clienteNovo;

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
            Cliente cliente = new Cliente();

            try
            {
                cliente = _contexto.Clientes.Where(c => c.Id == id)
                    .Include
                    (
                        c => c.Telefone
                    )
                    .Include
                    (
                        c => c.Enderecos
                    )
                        .ThenInclude
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
                    .FirstOrDefault();
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

            return cliente;
        }

        public IList<EntidadeDominio> List()
        {

            IList<Cliente> clientes;

            try
            {
                clientes = _contexto.Clientes
                    .Include
                    (
                        c => c.Telefone
                    )
                    .Include
                    (
                        c => c.Enderecos
                    )
                        .ThenInclude
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
                string str = "Não há tabela: \n" + ex.Message;
                System.Console.WriteLine(str);
                return null;
            }

            IList<EntidadeDominio> entidades = new List<EntidadeDominio>();

            foreach(var c in clientes)
            {
                entidades.Add((EntidadeDominio)c);
            }

            return entidades;
        }
    }
}
