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

            #region PKs e Trigramação

            #region Cidade

            modelBuilder.Entity<Cidade>()
                .HasKey(c => new { c.Id }).HasName("PK_CID");

            modelBuilder.Entity<Cidade>()
                .Property(c => c.Id)
                .HasColumnName("cid_id");

            modelBuilder.Entity<Cidade>()
                .Property(c => c.DtCadastro)
                .HasColumnName("cid_dt_cadastro");

            #endregion

            #region Cliente

            modelBuilder.Entity<Cliente>()
                .HasKey(c => new { c.Id }).HasName("PK_CLI");

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Id)
                .HasColumnName("cli_id");

            modelBuilder.Entity<Cliente>()
                .Property(c => c.DtCadastro)
                .HasColumnName("cli_dt_cadastro");

            #endregion

            #region Endereco

            modelBuilder.Entity<Endereco>()
                .HasKey(c => new { c.Id }).HasName("PK_END");

            modelBuilder.Entity<Endereco>()
                .Property(c => c.Id)
                .HasColumnName("end_id");

            modelBuilder.Entity<Endereco>()
                .Property(c => c.DtCadastro)
                .HasColumnName("end_dt_cadastro");

            #endregion

            #region Estado

            modelBuilder.Entity<Estado>()
                .HasKey(c => new { c.Id }).HasName("PK_EST");

            modelBuilder.Entity<Estado>()
                .Property(c => c.Id)
                .HasColumnName("est_id");

            modelBuilder.Entity<Estado>()
                .Property(c => c.DtCadastro)
                .HasColumnName("est_dt_cadastro");

            #endregion

            #region Pais

            modelBuilder.Entity<Pais>()
                .HasKey(c => new { c.Id }).HasName("PK_PAI");

            modelBuilder.Entity<Pais>()
                .Property(c => c.Id)
                .HasColumnName("pai_id");

            modelBuilder.Entity<Pais>()
                .Property(c => c.DtCadastro)
                .HasColumnName("pai_dt_cadastro");

            #endregion

            #region Telefone

            modelBuilder.Entity<Telefone>()
                .HasKey(c => new { c.Id }).HasName("PK_TEL");

            modelBuilder.Entity<Telefone>()
                .Property(c => c.Id)
                .HasColumnName("tel_id");

            modelBuilder.Entity<Telefone>()
                .Property(c => c.DtCadastro)
                .HasColumnName("tel_dt_cadastro");

            #endregion

            #endregion

        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

    }
}
