using LES.Controllers;
using LES.Controllers.Facade;
using LES.Data.DAO;
using LES.Migrations;
using LES.Models.Entity;
using LES.Models.ViewHelpers.CarrinhoCompra;
using LES.Models.ViewModel.Carrinho;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Views.CarrinhoCompra
{
    public class CarrinhoCompraController : BaseController
    {

        IFacadeCrud<Carrinho> _facadeCarrinho { get; set; }
        IDAOTabelaRel<CarrinhoLivro> _daoCarrinhoLivro { get; set; }
        IFacadeCrud<Cliente> _facadeCliente { get; set; }
        IFacadeCrud<Livro> _facadeLivro { get; set; }

        public CarrinhoCompraController(IFacadeCrud<Carrinho> facadeCarrinho, IFacadeCrud<Cliente> facadeCliente,
            IFacadeCrud<Livro> facadeLivro, IDAOTabelaRel<CarrinhoLivro> daoCarrinhoLivro)
        {
            _facadeCarrinho = facadeCarrinho;
            _facadeCliente = facadeCliente;
            _facadeLivro = facadeLivro;
            _daoCarrinhoLivro = daoCarrinhoLivro;
        }

        public IActionResult FinalizarCompra() {
            return View(); 
        }

        #region Carrinho

        public IActionResult _CarrinhoPartial()
        {
            Carrinho c = GetCarrinho();

            if (c == null) return PartialView("_CarrinhoPartial", new CarrinhoModel());

            _vh = new CarrinhoViewHelper
            {
                Entidades = new Dictionary<string, object>
                {
                    [typeof(Carrinho).Name] = c
                }
            };

            return PartialView("_CarrinhoPartial", _vh.ViewModel);
        }

        [HttpPost]
        public IActionResult _AddToCarrinho(string codBar, int quantia = 1)
        {
            Carrinho c = GetCarrinho();
            Livro livro = _facadeLivro.GetAllInclude(new Livro { CodigoBarras = codBar});
            IEnumerable<CarrinhoLivro> carrinhoLivro = c.CarrinhoLivro.Where(c => c.LivroId == livro.Id);

            if (quantia > livro.Estoque)
            {
                return Json(new { valor = false, ex = "Estoque insuficiente.\n" });
            }

            if (carrinhoLivro.Count() == 0) 
            {
                CarrinhoLivro livroNovo = new CarrinhoLivro
                {
                    Livro = _facadeLivro.GetEntidade(livro),
                    Carrinho = c,
                    Quantia = quantia
                };

                c.CarrinhoLivro.Add(livroNovo);
            }
            else
            {
                carrinhoLivro.FirstOrDefault().Quantia+= 1;
            }

            livro.Estoque -= quantia;

            string msg = _facadeCarrinho.Editar(c);
            msg += _facadeLivro.Editar(livro);

            //INSERIR MÉTODO DE DESATIVAÇÃO AUTOMÁTICA AQUI

            if(msg == "")
                return Json(new { valor = true });
            return Json(new { valor = false, ex = msg });
        }

        [HttpPost]
        public IActionResult _MaisQuantiaNoCarrinho(string codBar)
        {
            return RedirectToAction(nameof(_AlterarQuantiaNoCarrinho), new { codBar, op = "+" });
        }
        [HttpPost]
        public IActionResult _MenosQuantiaNoCarrinho(string codBar)
        {
            return RedirectToAction(nameof(_AlterarQuantiaNoCarrinho), new { codBar, op = "-" });
        }

        public IActionResult _AlterarQuantiaNoCarrinho(string codBar, string op) 
        {
            Carrinho c = GetCarrinho();
            CarrinhoLivro carrinhoLivro = c.CarrinhoLivro.Where(l => l.Livro.CodigoBarras == codBar).FirstOrDefault();

            IDictionary<string, int> operacoes = new Dictionary<string, int>
            {
                ["+"] = 1,
                ["-"] = -1
            };

            if (carrinhoLivro == null)
                return Json(new { valor = false, ex = "Livro não está no carrinho.\n" });

            if (carrinhoLivro.Livro.Estoque == 0 && op == "+")
                return Json(new { valor = false, ex = "Estoque insuficiente.\n" });

            carrinhoLivro.Quantia += operacoes[op];
            carrinhoLivro.Livro.Estoque -= 1;

            string msg = _facadeCarrinho.Editar(c);

            //INSERIR MÉTODO DE DESATIVAÇÃO AUTOMÁTICA AQUI

            if (msg == "")
                return Json(new { valor = true });
            return Json(new { valor = false, ex = msg });
        }

        [HttpPost]
        public IActionResult _RemoverDoCarrinho(string codBar)
        {
            Carrinho c = GetCarrinho();
            Livro livro = _facadeLivro.Query(l => l.CodigoBarras == codBar,
                l => l).FirstOrDefault();

            if (livro == null) 
            {
                return Json(new { valor = false, ex = "Algo deu errado.\n" });
            }

            CarrinhoLivro carrinhoLivro = c.CarrinhoLivro.Where(c => c.LivroId == livro.Id).FirstOrDefault();

            if (carrinhoLivro == null)
            {
                return Json(new { valor = false, ex = "O livro não está no carrinho.\n" });
            }

            livro.Estoque += carrinhoLivro.Quantia;
            c.CarrinhoLivro.Remove(carrinhoLivro);

            string msg = _daoCarrinhoLivro.Remove(carrinhoLivro);
            msg += _facadeLivro.Editar(livro);

            if (msg == "")
                return Json(new { valor = true });
            return Json(new { valor = false, ex = msg });
        }

        #endregion

        #region Adicionar Endereço e Cartão
        public IActionResult _AdicionarNovoEnderecoPartial()
        {
            return PartialView("../CarrinhoCompra/PartialViews/_AdicionarNovoEnderecoPartial");
        }

        [HttpPost]
        public IActionResult AdicionarNovoEndereco(DetalhesEnderecoModel novoEndereco)
        {
            return RedirectToAction(nameof(FinalizarCompra));
        }

        public IActionResult _AdicionarNovoCartaoPartial()
        {
            return PartialView("../CarrinhoCompra/PartialViews/_AdicionarNovoCartaoPartial");
        }

        [HttpPost]
        public IActionResult AdicionarNovoCartao(DetalhesCartaoModel novoEndereco)
        {
            return RedirectToAction(nameof(FinalizarCompra));
        }
        #endregion

        #region Calcular Frete

        public IActionResult _CalcularFretePartial()
        {
            return PartialView("../CarrinhoCompra/PartialViews/_CalcularFretePartial");
        }

        #endregion

        #region Usar Cupom
        public IActionResult _UsarCupomPartial()
        {
            return PartialView("../CarrinhoCompra/PartialViews/_UsarCupomPartial");
        }

        public IActionResult UsarCupom(int id) 
        {
            return RedirectToAction(nameof(FinalizarCompra));
        }
        #endregion

        #region Utilidades

        private Carrinho GetCarrinho()
        {
            return _facadeCarrinho.GetAllInclude(new Carrinho { Cliente = GetClienteComEmail() });

        }

        #endregion

    }
}
