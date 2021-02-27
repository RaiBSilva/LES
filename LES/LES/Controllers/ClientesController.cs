using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Models.ViewModel;
using LES.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LES.Controllers
{
    public class ClientesController : Controller
    {
        private IFacadeCrud _facade;
       
        public ClientesController(IFacadeCrud facade) 
        {
            _facade = facade;

            EnderecoCadastro a = new EnderecoCadastro(
                    "Rua tal",
                    "Numero tal",
                    "Cep Tal",
                    "Complemento tal",
                    "Mogi",
                    "São Paulo",
                    "Brasil",
                    "",
                    (TipoEndereco)0,
                    true,
                    true
                    );

            Cliente1 = new ClienteCadastro(
                1,
                "Judiscréia",
                new DateTime(),
                (Genero)1,
                "aeaeo@hotmail.com",
                "MXmx@@@@",
                "12345678901",
                (TipoTelefone)0,
                "011",
                "912345678",
                new Dictionary<int, EnderecoCadastro>()
                );

            Cliente1.Enderecos[0] = a;
            Cliente1.Enderecos[1] = a;
            Cliente1.Enderecos[2] = a;
            Cliente1.Enderecos[3] = a;

        }

        public ClienteCadastro Cliente1 { get; set; }

        // GET: Clientes
        public ActionResult Index()
        {
            IList<ClienteCadastro> Entidades = new List<ClienteCadastro>();
            Entidades.Add(Cliente1);
            //ViewBag.Entidades = _facade.listar(new Cliente());
            return View(Entidades);
        }

        // GET: Clientes/Details/5
        public ActionResult Detalhes(int id)
        {
            //ViewBag.Entidade = _facade.getEntidade(new Cliente(id));
            return View(Cliente1);
        }

        // GET: Clientes/Create
        public ActionResult Cadastro(int? id)
        {
            if (id is null)
            {
                ClienteCadastro clienteVazio = new ClienteCadastro(new DateTime(DateTime.Now.Ticks), new Dictionary<int, EnderecoCadastro>());
                clienteVazio.Enderecos[0] = new EnderecoCadastro();

                return View(clienteVazio);
            }



            return View(Cliente1);
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(ClienteCadastro cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string msg = _facade.Cadastrar(ClienteViewParaModel(cliente));
                    if (msg != "")
                    {
                        return RedirectToAction(nameof(Erro), msg);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(cliente);
                }
            }
            return View(cliente);
        }

        public ActionResult Erro(string str) {
            ViewBag.String = str;
            
            return View();
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Cliente1);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        private Cliente ClienteViewParaModel(ClienteCadastro clienteCadastro)
        {
            Cliente cliente = new Cliente();

            cliente.Nome = clienteCadastro.Nome;

            cliente.DtNascimento = clienteCadastro.DtNascimento;

            cliente.Genero = clienteCadastro.Genero;

            cliente.Email = clienteCadastro.Email;

            cliente.Senha = clienteCadastro.Senha;

            cliente.Cpf = clienteCadastro.Cpf;

            cliente.Telefone = new Telefone();

            cliente.Telefone.TipoTelefone = clienteCadastro.TipoTelefone;

            cliente.Telefone.Ddd = clienteCadastro.Ddd;

            cliente.Telefone.Numero = clienteCadastro.Telefone;

            cliente.Enderecos = new List<Endereco>();

            foreach (KeyValuePair<int, EnderecoCadastro> entry in clienteCadastro.Enderecos)
            {
                Endereco endereco = new Endereco();
                endereco.EResidencia = (entry.Key == 0);

                endereco = EnderecoViewParaModel(entry.Value);

                cliente.Enderecos.Add(endereco);
            }

            return cliente;
        }

        private Endereco EnderecoViewParaModel(EnderecoCadastro enderecoCadastro)
        {
            Endereco endereco = new Endereco();

            endereco.Logradouro = enderecoCadastro.Logradouro;

            endereco.Numero = enderecoCadastro.Numero;

            endereco.Cep = enderecoCadastro.Cep;

            endereco.Complemento = enderecoCadastro.Complemento;

            endereco.Cidade = new Cidade();

            endereco.Cidade.Estado = new Estado();

            endereco.Cidade.Estado.Pais = new Pais();

            endereco.Cidade.Nome = enderecoCadastro.Cidade;

            endereco.Cidade.Estado.Nome = enderecoCadastro.Estado;

            endereco.Cidade.Estado.Pais.Nome = enderecoCadastro.Pais;

            endereco.Observacoes = enderecoCadastro.Observacoes;

            endereco.TipoEndereco = enderecoCadastro.TipoEndereco;

            endereco.EEntrega = enderecoCadastro.EEntrega;

            endereco.ECobranca = enderecoCadastro.ECobranca;

            return endereco;
        }
    }
}