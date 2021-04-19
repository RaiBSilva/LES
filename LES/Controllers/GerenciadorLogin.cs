using LES.Models.Entity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;

namespace LES.Controllers
{
    public static class GerenciadorLogin
    {
        public static ClaimsPrincipal FazerLogin(Cliente cliente) 
        {
            int role = (int)cliente.Usuario.Role;

            var userClaims = new List<Claim>()
                    {
                    new Claim(ClaimTypes.Name, cliente.Nome),
                    new Claim(ClaimTypes.Email, cliente.Usuario.Email),
                    new Claim(ClaimTypes.Role, role.ToString())
                     };

            var grandmaIdentity = new ClaimsIdentity(userClaims, "UsuarioInfo");

            return new ClaimsPrincipal(new[] { grandmaIdentity });
        }

        public static bool comparaSenha(string senhaLogin, string senhaDb) 
        {
            byte[] hashBytes = Convert.FromBase64String(senhaDb);
            byte[] salt = new byte[16];

            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(senhaLogin, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;

            return true;
        }


    }
}
