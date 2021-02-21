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
        }

        // GET: Clientes
        public ActionResult Index()
        {
            ViewBag.Entidades = _facade.listar(new Cliente());
            return View();
        }

        // GET: Clientes/Details/5
        public ActionResult Detalhes(int id)
        {
            ViewBag.Entidade = _facade.getEntidade(new Cliente(id));
            return View();
        }

        // GET: Clientes/Create
        public ActionResult Cadastro(int? id)
        {
            if (id is null)
            {
                return View(new Cliente());
            }



            return View(new Cliente());
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

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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