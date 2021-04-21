using LES.Models;
using LES.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Data.DAO
{
    public class DAOCarrinho<T> : DAO<T>, IGetIncludeAll where T : Carrinho
    {
        public DAOCarrinho(AppDbContext contexto) : base(contexto)
        {
        }

        public EntidadeDominio IncludeAll(EntidadeDominio e)
        {
            Carrinho request = (Carrinho)e;
            string email = request.Cliente.Usuario.Email;

            Carrinho response = _entidade.Select(c => c).Where(c => c.Cliente.Usuario.Email == email)
                .Include(c => c.CarrinhoLivro)
                    .ThenInclude(c => c.Livro)
                .Include(c => c.Cliente)
                    .ThenInclude(c => c.Usuario)
                .FirstOrDefault();

            return response;

        }
    }
}
