using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LES.Controllers
{
    public class ClientesController : Controller
    {
        private Facade _facade;

        //public ClientesController(Facade facade) : base() => this._facade = facade;

        public ClientesController() 
        {
            _facade = new Facade();

            Endereco a = new Endereco(
                    "Rua tal",
                    "Numero tal",
                    "Cep Tal",
                    "Complemento tal",
                    new Cidade(
                        "Mogi",
                        new Estado(
                            "São Paulo",
                            new Pais(
                                "Brasil"
                                )
                            )
                        ),
                    "",
                    (TipoEndereco)0
                    );

            Cliente1 = new Cliente(
                1,
                new DateTime(),
                "Fernanda",
                new DateTime(),
                (Genero)1,
                new Login(
                    "aeaeo@hotmail.com",
                    "MXmx@@@@"),
                "12345678901",
                new Telefone(
                    (TipoTelefone)0,
                    "011",
                    "912345678"
                    ),
                new List<Endereco>(),
                new List<Endereco>(),
                a
                );

            Cliente1.EnderecosCobranca.Add(a);
            Cliente1.EnderecosCobranca.Add(a);
            Cliente1.EnderecosCobranca.Add(a);
            Cliente1.EnderecosCobranca.Add(a);
            Cliente1.EnderecosEntrega.Add(a);
        }

        public Cliente Cliente1 { get; set; }

        // GET: Clientes
        public ActionResult Index()
        {
            IList<Cliente> Entidades = new List<Cliente>();
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
                return View(new Cliente());
            }



            return View(Cliente1);
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(Cliente cliente)
        {
            try
            {
                _facade.cadastrar(cliente);

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
            return View();
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
    }
}