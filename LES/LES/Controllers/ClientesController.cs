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
        private Facade _facade;

        //public ClientesController(Facade facade) : base() => this._facade = facade;

        public ClientesController() 
        {
            _facade = new Facade();

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
                return View(new ClienteCadastro());
            }



            return View(Cliente1);
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(ClienteCadastro cliente)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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

        private Cliente ViewModelToModel()
        {
            return new Cliente();
        }
    }
}