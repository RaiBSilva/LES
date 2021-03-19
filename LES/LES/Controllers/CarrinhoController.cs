using LES.Models.Entity;
using LES.Models.ViewModel.Carrinho;
using LES.Models.ViewModel.Conta;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Views.Carrinho
{
    public class CarrinhoController : Controller
    {

        CarrinhoModel CarrinhoModel = new CarrinhoModel();

        FinalizarCompraModel FCModel = new FinalizarCompraModel();

        public CarrinhoController()
        {
            #region Carrinho Demo

            CarrinhoModel.Livros = new List<CarrinhoLivroModel>();

            CarrinhoLivroModel livro = new CarrinhoLivroModel();

            livro.Titulo = "Winds of Winter";
            livro.Autor = "George R. R. Maritn";
            livro.Preco = 100;
            livro.Quantia = 3;

            CarrinhoModel.Livros.Add(livro);
            CarrinhoModel.Livros.Add(livro);

            #endregion

            #region Finalizar Compra Demo
            DetalhesEnderecoModel end = new DetalhesEnderecoModel();
            end.Id = "1";
            end.NomeEndereco = "Tortura";
            end.TipoEndereco = (TipoEndereco)0;
            end.Logradouro = "Rua Carlos Barattino Vila Nova";
            end.Numero = "908";
            end.Complemento = "Vila Mogilar";
            end.Cep = "08773-600";
            end.Cidade = "Mogi das Cruzes";
            end.Estado = "São Paulo";
            end.Pais = "Brasil";
            end.Observacoes = "Bora cumpade";
            end.ECobranca = true;
            end.EEntrega = true;
            end.EPreferencial = true;

            FCModel.Enderecos.Add(end);

            DetalhesEnderecoModel end2 = new DetalhesEnderecoModel();
            end2.Id = "1";
            end2.NomeEndereco = "Tortura";
            end2.TipoEndereco = (TipoEndereco)0;
            end2.Logradouro = "Rua Carlos Barattino Vila Nova";
            end2.Numero = "908";
            end2.Complemento = "Vila Mogilar";
            end2.Cep = "08773-600";
            end2.Cidade = "Mogi das Cruzes";
            end2.Estado = "São Paulo";
            end2.Pais = "Brasil";
            end2.Observacoes = "Bora cumpade";
            end2.ECobranca = false;
            end2.EEntrega = false;
            end2.EPreferencial = false;

            FCModel.Enderecos.Add(end2);

            DetalhesCartaoModel card = new DetalhesCartaoModel();

            card.Bandeira = (BandeiraCartaoCredito)0;
            card.Codigo = "1234567812345678";
            card.Cvv = "255";
            card.EPreferencial = false;
            card.Id = "1";
            card.Nome = "KEVIN MANMAR";
            card.Vencimento = DateTime.Today;

            FCModel.Cartoes.Add(card);

            DetalhesCartaoModel card2 = new DetalhesCartaoModel();

            card2.Bandeira = (BandeiraCartaoCredito)0;
            card2.Codigo = "1234567812345678";
            card2.Cvv = "255";
            card2.EPreferencial = true;
            card2.Id = "1";
            card2.Nome = "KEVIN MANMAR";
            card2.Vencimento = DateTime.Today;

            FCModel.Cartoes.Add(card2);

            CupomModel c1 = new CupomModel();
            CupomModel c2 = new CupomModel();

            c1.Codigo = "142";
            c1.Valor = 10.30F;

            c2.Codigo = "1444";
            c2.Valor = 20.30F;

            FCModel.Cupons.Add(c1);
            FCModel.Cupons.Add(c2);

            FCModel.Pedido = CarrinhoModel;

            FCModel.Pedido.PrecoTotal = 250.50F;

            #endregion

        }

        public IActionResult FinalizarCompra() {
            return View(FCModel); 
        }

        public IActionResult _CarrinhoPartial()
        {
            return PartialView("_CarrinhoPartial", CarrinhoModel);
        }

        #region Adicionar Endereço e Cartão
        public IActionResult _AdicionarNovoEnderecoPartial()
        {
            return PartialView("../Carrinho/PartialViews/_AdicionarNovoEnderecoPartial");
        }

        [HttpPost]
        public IActionResult AdicionarNovoEndereco(DetalhesEnderecoModel novoEndereco)
        {
            return RedirectToAction(nameof(FinalizarCompra));
        }

        public IActionResult _AdicionarNovoCartaoPartial()
        {
            return PartialView("../Carrinho/PartialViews/_AdicionarNovoCartaoPartial");
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
            return PartialView("../Carrinho/PartialViews/_CalcularFretePartial");
        }

        #endregion

        #region Usar Cupom
        public IActionResult _UsarCupomPartial()
        {
            return PartialView("../Carrinho/PartialViews/_UsarCupomPartial", FCModel.Cupons);
        }

        public IActionResult UsarCupom(int id) 
        {
            return RedirectToAction(nameof(FinalizarCompra));
        }
        #endregion

    }
}
