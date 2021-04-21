using LES.Models.Entity;
using LES.Negocio.Strategy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LES.Negócio.Strategy.ClienteStrategy
{
    public class ValidarCpfStrategy : IStrategy
    {

        public string Validar(EntidadeDominio e)
        {
            Cliente cliente = (Cliente)e;

            if (cliente.Cpf.Length == 11)
            {
                bool rtnPrimeiro = ValidarPrimeiroDigito(cliente.Cpf);
                if (!rtnPrimeiro) return "O CPF é inválido.";

                bool rtnSegundo = ValidarPrimeiroDigito(cliente.Cpf);
                if (!rtnSegundo) return "O CPF é inválido.";
            }
            else
            {
                return "O cpf deve ter 11 dígitos.";
            }

            return "";
        }

        static bool ValidarPrimeiroDigito(String cpf)
        {
            int multiplicador = 10;
            int total = 0;

            string novePrimeiros = cpf[0..9];
            int primeiroDigito = Int16.Parse(cpf[9].ToString());

            //Validando o primeiro digito verificador
            foreach (char numero in novePrimeiros)
            {
                total += Int16.Parse(numero.ToString()) * multiplicador;
                multiplicador -= 1;
            }

            int resto = 11 - (total % 11);

            if (resto != primeiroDigito) return false;

            return true;
        }

        static bool ValidarSegundoDigito(String cpf)
        {
            int multiplicador = 11;
            int total = 0;

            string dezPrimeiros = cpf[0..10];
            int segundoDigito = Int16.Parse(cpf[10].ToString());

            //Validando o segundo digito verificador
            foreach (char numero in dezPrimeiros)
            {
                total += Int16.Parse(numero.ToString()) * multiplicador;
                multiplicador -= 1;
            }

            int resto = 11 - (total % 11);

            if (resto != segundoDigito) return false;

            return true;
        }
    }
}
