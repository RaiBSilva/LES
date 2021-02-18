using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LES.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

    }
}
