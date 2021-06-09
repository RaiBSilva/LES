using LES.Models.Entity;
using LES.Models.ViewHelpers.Shared;
using LES.Models.ViewModel.Admin;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewHelpers.Admin
{
    public class AdminLivroViewHelper : AbstractViewHelper, IViewHelper
    {
        protected override void ToEntidade()
        {
            AdminLivroModel livro = (AdminLivroModel)ViewModel;

            Livro l = new Livro
            {
                Altura = livro.Altura,
                Autor = livro.Autor,
                Comprimento = livro.Comprimento,
                CodigoBarras = livro.CodigoBarras,
                DtLancamento = livro.DtLancamento,
                Edicao = livro.Edicao,
                Editora = new Editora { Nome = livro.Editora },
                GrupoPrecoId = livro.GrupoPrecoId,
                Isbn = livro.Isbn,
                Inativo = true,
                Largura = livro.Largura,
                Paginas = livro.Paginas,
                Valor = livro.Preco,
                Sinopse = livro.Sinopse,
                Titulo = livro.Titulo,
                Estoque = livro.Estoque,
                Id = livro.Id
            };
            if(livro.Capa != null) 
            { 
                if (livro.Capa.Length > 0 && livro.Capa.ContentType == "image/png")
                {
                    using var ms = new MemoryStream();
                    livro.Capa.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    l.Capa = fileBytes;
                }
                else livro.Capa = null;
            }

            IList<LivroCategoriaLivro> categorias = new List<LivroCategoriaLivro>();

            foreach(var ctg in livro.CategoriasIds)
                categorias.Add(new LivroCategoriaLivro
                {
                    LivroId = l.Id,
                    CategoriaLivroId = ctg
                });

            _entidades = new Dictionary<string, object>
            {
                [typeof(Livro).Name] = l
            };
        }

        protected override void ToViewModel()
        {
            Livro livro = (Livro)Entidades[typeof(Livro).Name];

            AdminLivroModel vm = new AdminLivroModel
            {
                Altura = livro.Altura,
                Autor = livro.Autor,
                CodigoBarras = livro.CodigoBarras,
                Comprimento = livro.Comprimento,
                DtLancamento = livro.DtLancamento,
                Edicao = livro.Edicao,
                Editora = livro.Editora.Nome,
                Isbn = livro.Isbn,
                Inativo = livro.Inativo,
                Largura = livro.Largura,
                Paginas = livro.Paginas,
                Preco = livro.Valor,
                Sinopse = livro.Sinopse,
                Titulo = livro.Titulo,
                Estoque = livro.Estoque,
                Id = livro.Id
            };

            if(livro.GrupoPreco != null)
                vm.GrupoPreco = (GrupoPrecoModel)new GrupoPrecoViewHelper 
                { 
                    Entidades = new Dictionary<string, object> 
                    { 
                        [typeof(GrupoPreco).Name] = livro.GrupoPreco 
                    } 
                }.ViewModel;

            vm.Capa = new FormFile(new MemoryStream(livro.Capa), 0, livro.Capa.Length, "Capa", "capa.png");
            IList<int> ids = new List<int>();

            if(livro.LivrosCategoriaLivros != null)
            {
                foreach (var item in livro.LivrosCategoriaLivros)
                    ids.Add(item.CategoriaLivroId);

                vm.CategoriasIds = ids.ToArray();
            }

            _viewModel = vm;
        }
    }
}
