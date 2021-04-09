using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Models.ViewModel;
using LES.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Reflection.Metadata;
using System.Text.Json;

namespace LES.Controllers
{
    /*
    public class ClientesController : Controller
    {
        private IFacadeCrud _facade;
       
        public ClientesController(IFacadeCrud facade) 
        {
            _facade = facade;

        }

        // GET: Clientes
        public ActionResult Index()
        {
            IEnumerable<EntidadeDominio> Entidades = _facade.Listar(new Cliente());
            IList <ClienteCadastro> EntidadesView = new List<ClienteCadastro>();

            foreach (var e in Entidades) 
            {
                Cliente c = (Cliente)e;
                EntidadesView.Add(ClienteModelParaView(c));
            }
;
            return View(EntidadesView);
        }

        // GET: Clientes/Details/5
        public ActionResult Detalhes(int id)
        {
            Cliente cliente = (Cliente)_facade.GetEntidade(new Cliente() { Id = id});

            ClienteCadastro clienteCadastro = ClienteModelParaView(cliente);

            return View(clienteCadastro);
        }

        // GET: Clientes/Create
        public ActionResult Cadastro()
        {
            ClienteCadastro clienteVazio = new ClienteCadastro(new DateTime(DateTime.Now.Ticks), new List<EnderecoCadastro>());

            for (int i = 0; i < 10; i++) clienteVazio.Enderecos.Add(new EnderecoCadastro());

            return View(clienteVazio);

        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(ClienteCadastro clienteCadastro)
        {
            /*for(int i = 0; i < clienteCadastro.Enderecos.Count; i++)
            {
                ModelState.Remove("Enderecos.[" + i + "].EEntrega");
                ModelState.Remove("Enderecos.[" + i + "].ECobranca");
            }

            if (ModelState.IsValid)
            {
                Cliente cliente = ClienteViewParaModel(clienteCadastro);
                try
                {
                    string msg = _facade.Cadastrar(cliente);
                    if (msg != "")
                    {
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(clienteCadastro);
                }
            }
            return View(clienteCadastro);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            Cliente cliente = (Cliente)_facade.GetEntidade(new Cliente() { Id= id});

            ClienteCadastro clienteCadastro = ClienteModelParaView(cliente);

            return View(clienteCadastro);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _facade.Deletar(new Cliente(){Id =id});
            }
            catch(Exception ex)
            {
            }

            return RedirectToAction(nameof(Index));

        }

        public ActionResult Editar(int id)
        {
            Cliente cliente = (Cliente)_facade.GetEntidade(new Cliente() { Id=id});
            ClienteCadastro clienteCadastro = ClienteModelParaView(cliente);
            return View(clienteCadastro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ClienteCadastro clienteCadastro) 
        {

            ModelState.Remove("Senha");

            if (ModelState.IsValid)
            {
                Cliente clienteEdit = ClienteViewParaModel(clienteCadastro);

                Cliente cliente = (Cliente)_facade.GetEntidade(clienteEdit);

                cliente.Nome = clienteEdit.Nome;
                cliente.DtNascimento = clienteEdit.DtNascimento;
                cliente.Genero = clienteEdit.Genero;
                cliente.Cpf = clienteEdit.Cpf;
                cliente.Email = clienteEdit.Email;
                cliente.Telefone = clienteEdit.Telefone;

                try
                {
                    _facade.Editar(cliente);
                }
                catch
                {
                    return View(clienteCadastro);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult EditarSenha(int id)
        {
            Cliente cliente = (Cliente)_facade.GetEntidade(new Cliente() { Id=id});
            ClienteCadastro clienteCadastro = ClienteModelParaView(cliente);
            return View(clienteCadastro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarSenha(ClienteCadastro clienteCadastro)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("Ddd");
            ModelState.Remove("Genero");
            ModelState.Remove("Email");
            ModelState.Remove("Telefone");
            ModelState.Remove("Cpf");

            if (ModelState.IsValid)
            {
                Cliente clienteEdit = ClienteViewParaModel(clienteCadastro);

                Cliente cliente = (Cliente)_facade.GetEntidade(clienteEdit);

                cliente.Senha = clienteEdit.Senha;

                try
                {
                    _facade.Editar(cliente);
                }
                catch
                {
                    return View(clienteCadastro);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult EditarEndereco(int id) 
        {
            Endereco endereco = (Endereco)_facade.GetEntidade(new Endereco(id));
            EnderecoCadastro enderecoCadastro = EnderecoModelParaView(endereco);
            return View(enderecoCadastro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEndereco(EnderecoCadastro enderecoCadastro)
        {
            if (ModelState.IsValid)
            {
                Endereco enderecoEdit = EnderecoViewParaModel(enderecoCadastro);

                try
                {
                    _facade.Editar(enderecoEdit);
                }
                catch
                {
                    return View(enderecoCadastro);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult _EnderecoPartial(int id) {

            List<EnderecoCadastro> enderecos = new List<EnderecoCadastro>();
            for (int i = 0; i <= id; i++) enderecos.Add(new EnderecoCadastro());

            return PartialView(new EnderecoExistente(enderecos, id));
        }

        #region Metodos de conversão
        private Cliente ClienteViewParaModel(ClienteCadastro clienteCadastro)
        {
            Cliente cliente = new Cliente();

            cliente.Id = clienteCadastro.Id;

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

            if (clienteCadastro.Enderecos != null) 
            { 
                foreach (var end in clienteCadastro.Enderecos)
                {
                    Endereco endereco = new Endereco();

                    endereco = EnderecoViewParaModel(end);
                    if (end.Logradouro is object && end.Logradouro != "")
                        cliente.Enderecos.Add(endereco);
                } 
            }

            return cliente;
        }

        private Endereco EnderecoViewParaModel(EnderecoCadastro enderecoCadastro)
        {
            Endereco endereco = new Endereco();

            if (enderecoCadastro.Id > 0) endereco.Id = enderecoCadastro.Id;  

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

        private ClienteCadastro ClienteModelParaView(Cliente cliente)
        {
            ClienteCadastro clienteCadastro = new ClienteCadastro();

            clienteCadastro.Id = cliente.Id;

            clienteCadastro.Nome = cliente.Nome;

            clienteCadastro.DtNascimento = cliente.DtNascimento;

            clienteCadastro.Genero = cliente.Genero;

            clienteCadastro.Email = cliente.Email;

            clienteCadastro.Senha = cliente.Senha;

            clienteCadastro.Cpf = cliente.Cpf;

            clienteCadastro.TipoTelefone = cliente.Telefone.TipoTelefone;

            clienteCadastro.Ddd = cliente.Telefone.Ddd;

            clienteCadastro.Telefone = cliente.Telefone.Numero;

            clienteCadastro.Enderecos = new List<EnderecoCadastro>();

            foreach(var end in cliente.Enderecos)
            {
                clienteCadastro.Enderecos.Add(EnderecoModelParaView(end));
            }

            return clienteCadastro;
        }

        private EnderecoCadastro EnderecoModelParaView(Endereco endereco)
        {
            EnderecoCadastro enderecoCadastro = new EnderecoCadastro();

            if (endereco.Id > 0) enderecoCadastro.Id = endereco.Id;

            enderecoCadastro.Logradouro = endereco.Logradouro;

            enderecoCadastro.Numero = endereco.Numero;

            enderecoCadastro.Cep = endereco.Cep;

            enderecoCadastro.Complemento = endereco.Complemento;

            enderecoCadastro.Cidade = endereco.Cidade.Nome;

            enderecoCadastro.Estado = endereco.Cidade.Estado.Nome;

            enderecoCadastro.Pais = endereco.Cidade.Estado.Pais.Nome;

            enderecoCadastro.Observacoes = endereco.Observacoes;

            enderecoCadastro.TipoEndereco = endereco.TipoEndereco;

            enderecoCadastro.EEntrega = endereco.EEntrega;

            enderecoCadastro.ECobranca = endereco.ECobranca;

            return enderecoCadastro;
        }
        #endregion
    }
*/
}