using LES.Models.Entity;
using LES.Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.LivroStrategy
{
    public class ValidaIsbnStrategy : IStrategy
    {
        
        public string Validar(EntidadeDominio e)
        {
            Livro book = (Livro)e;
            StringBuilder sb = new StringBuilder("");

            String isbn13 = book.Isbn;

            bool valorLogico = false;
            if (!string.IsNullOrEmpty(isbn13))
            {
                if(isbn13.Length == 13)
                {
                    long j;

                    if (isbn13.Contains('-'))
                    {
                        isbn13 = isbn13.Replace("-", "");
                    }

                    if (!Int64.TryParse(isbn13, out j))
                        valorLogico = false;

                    int sum = 0;

                    for (int i = 0; i < 12; i++)
                    {
                        sum += Int32.Parse(isbn13[i].ToString()) * (i % 2 == 1 ? 3 : 1);
                    }
                    int remainder = sum % 10;
                    int checkDigit = 10 - remainder;
                    if (checkDigit == 10) checkDigit = 0;
                    valorLogico = (checkDigit == int.Parse(isbn13[12].ToString()));
                }
            }

            if (valorLogico)
                return "";

            return "O ISBN é inválido.";
        }
                
    }
}
