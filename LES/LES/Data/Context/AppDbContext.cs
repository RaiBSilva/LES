using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Models.Entity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

            string tri = "";

            #region Ativacao

            tri = "ati";

            modelBuilder = configBasico<Ativacao>(modelBuilder, "ATIVACOES", tri);

            modelBuilder.Entity<Ativacao>()
                .Property(a => a.LivroId)
                .HasColumnName(tri + "_liv_id")
                .IsRequired();

            modelBuilder.Entity<Ativacao>()
                .Property(a => a.CategoriaId)
                .HasColumnName(tri + "_cta_id")
                .IsRequired();

            modelBuilder.Entity<Ativacao>()
                .HasOne(a => a.Categoria)
                .WithMany(c => c.Ativacoes)
                .HasForeignKey(a => a.CategoriaId)
                .HasConstraintName("FK_"+ tri.ToUpper() + "_CTA"); 

            modelBuilder.Entity<Ativacao>()
                .HasOne(a => a.Livro)
                .WithMany(l => l.Ativacoes)
                .HasForeignKey(a => a.LivroId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_LIV");

            #endregion

            #region BandeiraCartaoCredito

            tri = "ban";

            modelBuilder = configBasico<BandeiraCartaoCredito>(modelBuilder, "BANDEIRAS_CARTAO_CREDITO", tri);

            modelBuilder.Entity<BandeiraCartaoCredito>()
                .Property(b => b.Nome)
                .HasColumnName(tri + "_nome")
                .IsRequired();

            #endregion

            #region Carrinho

            tri = "crr";

            modelBuilder = configBasico<Carrinho>(modelBuilder, "CARRINHOS", tri);

            modelBuilder.Entity<Carrinho>()
                .Property(c => c.TimeoutDate)
                .HasColumnName($"{tri}_dt_timeout")
                .IsRequired();

            modelBuilder.Entity<Carrinho>()
                .Property(c => c.JobKeyStr)
                .HasColumnName(tri + "_job_key");

            #endregion

            #region CarrinhoLivro

            tri = "crl";

            modelBuilder.Entity<CarrinhoLivro>().ToTable("CARRINHOS_LIVROS");

            modelBuilder.Entity<CarrinhoLivro>().HasKey(l => new { l.CarrinhoId, l.LivroId })
                .HasName("PK_" + tri.ToUpper());

            modelBuilder.Entity<CarrinhoLivro>()
                .Property(l => l.LivroId)
                .HasColumnName(tri + "_liv_id")
                .IsRequired();

            modelBuilder.Entity<CarrinhoLivro>()
                .Property(l => l.CarrinhoId)
                .HasColumnName(tri + "_crr_id")
                .IsRequired();

            modelBuilder.Entity<CarrinhoLivro>()
                .Property(l => l.Quantia)
                .HasColumnName($"{tri}_quantia")
                .IsRequired();

            modelBuilder.Entity<CarrinhoLivro>()
                .HasOne(l => l.Carrinho)
                .WithMany(c => c.CarrinhoLivro)
                .HasForeignKey(l => l.CarrinhoId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_CRR");

            modelBuilder.Entity<CarrinhoLivro>()
                .HasOne(l => l.Livro)
                .WithMany(l => l.CarrinhoLivro)
                .HasForeignKey(l => l.LivroId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_LIV");

            #endregion

            #region CartaoCredito

            tri = "car";

            modelBuilder = configBasico<CartaoCredito>(modelBuilder, "CARTOES_CREDITO", tri);

            modelBuilder.Entity<CartaoCredito>()
                .Property(c => c.BandeiraId)
                .HasColumnName(tri + "_ban_id")
                .IsRequired();

            modelBuilder.Entity<CartaoCredito>()
                .Property(c => c.ClienteId)
                .HasColumnName(tri + "_cli_id")
                .IsRequired();

            modelBuilder.Entity<CartaoCredito>()
                .Property(c => c.Codigo)
                .HasColumnName(tri + "_codigo")
                .IsRequired();

            modelBuilder.Entity<CartaoCredito>()
                .Property(c => c.Cvv)
                .HasColumnName(tri + "_cvv")
                .IsRequired();

            modelBuilder.Entity<CartaoCredito>()
                .Property(c => c.EFavorito)
                .HasColumnName(tri + "_e_favorito")
                .IsRequired();

            modelBuilder.Entity<CartaoCredito>()
                .Property(c => c.NomeImpresso)
                .HasColumnName(tri + "_nome_impresso")
                .IsRequired();

            modelBuilder.Entity<CartaoCredito>()
                .Property(c => c.Vencimento)
                .HasColumnName(tri + "_vencimento")
                .IsRequired();

            modelBuilder.Entity<CartaoCredito>()
                .HasOne(c => c.Bandeira)
                .WithMany(b => b.Cartoes)
                .HasForeignKey(c => c.BandeiraId)
                .HasConstraintName("FK_"+ tri.ToUpper() +"_BAN");

            modelBuilder.Entity<CartaoCredito>()
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Cartoes)
                .HasForeignKey(c => c.ClienteId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_CLI");

            #endregion

            #region CartaoPedido

            tri = "cap";

            modelBuilder.Entity<CartaoPedido>().ToTable("CARTOES_PEDIDOS");

            modelBuilder.Entity<CartaoPedido>().HasKey(c => new { c.CartaoId, c.PedidoId })
                .HasName("PK_" + tri.ToUpper());

            modelBuilder.Entity<CartaoPedido>()
                .Property(c => c.CartaoId)
                .HasColumnName(tri + "_car_id")
                .IsRequired();

            modelBuilder.Entity<CartaoPedido>()
                .Property(c => c.PedidoId)
                .HasColumnName(tri + "_ped_id")
                .IsRequired();

            modelBuilder.Entity<CartaoPedido>()
                .Property(c => c.Valor)
                .HasColumnName($"{tri}_valor")
                .IsRequired();

            modelBuilder.Entity<CartaoPedido>()
                .HasOne(c => c.Cartao)
                .WithMany(c => c.CartaoPedidos)
                .HasForeignKey(l => l.CartaoId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_CAR");

            modelBuilder.Entity<CartaoPedido>()
                .HasOne(l => l.Pedido)
                .WithMany(l => l.CartaoPedidos)
                .HasForeignKey(l => l.PedidoId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_PED").OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region CategoriaAtivacao

            tri = "cta";

            modelBuilder = configMetadado<CategoriaAtivacao>(modelBuilder, "CATEGORIAS_ATIVACAO", tri);

            #endregion

            #region CategoriaInativacao

            tri = "cti";

            modelBuilder = configMetadado<CategoriaInativacao>(modelBuilder, "CATEGORIAS_INATIVACAO", tri);

            #endregion

            #region CategoriaLivro

            tri = "ctl";

            modelBuilder = configMetadado<CategoriaLivro>(modelBuilder, "CATEGORIAS_LIVRO", tri);

            #endregion

            #region Cidade

            tri = "cid";

            modelBuilder = configBasico<Cidade>(modelBuilder, "CIDADES", tri);

            modelBuilder.Entity<Cidade>()
                .Property(c => c.Nome)
                .HasColumnName(tri + "_nome")
                .IsRequired();

            modelBuilder.Entity<Cidade>()
                .Property(c => c.EstadoId)
                .HasColumnName(tri + "_pai_id")
                .IsRequired();

            modelBuilder.Entity<Cidade>()
                .HasOne(c => c.Estado)
                .WithMany(e => e.Cidades)
                .HasForeignKey(c => c.EstadoId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_EST");

            #endregion

            #region CodigoPromocional

            tri = "cod";

            modelBuilder = configBasico<CodigoPromocional>(modelBuilder, "CODIGOS", tri);

            modelBuilder.Entity<CodigoPromocional>()
                .Property(c => c.Codigo)
                .HasColumnName($"{tri}_codigo")
                .IsRequired();

            modelBuilder.Entity<CodigoPromocional>()
                .Property(c => c.DtValidade)
                .HasColumnName($"{tri}_dt_validade")
                .IsRequired();

            modelBuilder.Entity<CodigoPromocional>()
                .Property(c => c.UsosRestantes)
                .HasColumnName($"{tri}_usos_restantes")
                .IsRequired();

            modelBuilder.Entity<CodigoPromocional>()
                .Property(c => c.Valor)
                .HasColumnName($"{tri}_valor")
                .IsRequired();

            #endregion

            #region Cupom

            tri = "cup";

            modelBuilder = configBasico<Cupom>(modelBuilder, "CUPONS", tri);

            modelBuilder.Entity<Cupom>()
                .Property(c => c.ClienteId)
                .HasColumnName($"{tri}_cli_id")
                .IsRequired();

            modelBuilder.Entity<Cupom>()
                .Property(c => c.Codigo)
                .HasColumnName($"{tri}_codigo")
                .IsRequired();

            modelBuilder.Entity<Cupom>()
                .Property(c => c.Valor)
                .HasColumnName($"{tri}_valor")
                .IsRequired();

            modelBuilder.Entity<Cupom>()
                .Property(c => c.Inativo)
                .HasColumnName($"{tri}_usado")
                .IsRequired();

            modelBuilder.Entity<Cupom>()
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Cupons)
                .HasForeignKey(c => c.ClienteId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_CLI");

            #endregion

            #region Cliente

            tri = "cli";

            modelBuilder = configBasico<Cliente>(modelBuilder, "CLIENTES", tri);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.CarrinhoId)
                .HasColumnName(tri + "_crr_id");

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Codigo)
                .HasColumnName(tri + "_codigo")
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Cpf)
                .HasColumnName(tri + "_cpf")
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.DtNascimento)
                .HasColumnName(tri + "_dt_nascimento")
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Genero)
                .HasColumnName(tri + "_genero")
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nome)
                .HasColumnName(tri + "_nome")
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nota)
                .HasColumnName(tri + "_nota")
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.UsuarioId)
                .HasColumnName(tri + "_usu_id")
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Carrinho)
                .WithOne(u => u.Cliente)
                .HasForeignKey<Cliente>(c => c.CarrinhoId)
                .HasConstraintName("FK_"+ tri.ToUpper() +"_CRR")
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Usuario)
                .WithOne(u => u.Cliente)
                .HasForeignKey<Cliente>(c => c.UsuarioId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_USU");

            #endregion

            #region Editora

            tri = "edi";

            modelBuilder = configMetadado<Editora>(modelBuilder, "EDITORAS", tri);

            #endregion

            #region Endereco

            tri = "end";

            modelBuilder = configBasico<Endereco>(modelBuilder, "ENDERECOS", tri);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Cep)
                .HasColumnName(tri + "_cep")
                .IsRequired();

            modelBuilder.Entity<Endereco>()
               .Property(e => e.CidadeId)
               .HasColumnName(tri + "_cid_id")
               .IsRequired();

            modelBuilder.Entity<Endereco>()
               .Property(e => e.ClienteId)
               .HasColumnName(tri + "_cli_id")
               .IsRequired();

            modelBuilder.Entity<Endereco>()
               .Property(e => e.Complemento)
               .HasColumnName(tri + "_complemento")
               .IsRequired();

            modelBuilder.Entity<Endereco>()
               .Property(e => e.ECobranca)
               .HasColumnName(tri + "_e_cobranca")
               .IsRequired();

            modelBuilder.Entity<Endereco>()
               .Property(e => e.EEntrega)
               .HasColumnName(tri + "_e_entrega")
               .IsRequired();

            modelBuilder.Entity<Endereco>()
               .Property(e => e.EFavorito)
               .HasColumnName(tri + "_e_favorito")
               .IsRequired();

            modelBuilder.Entity<Endereco>()
               .Property(e => e.EResidencia)
               .HasColumnName(tri + "_e_residencia")
               .IsRequired();

            modelBuilder.Entity<Endereco>()
               .Property(e => e.Logradouro)
               .HasColumnName(tri + "_logradouro")
               .IsRequired();

            modelBuilder.Entity<Endereco>()
               .Property(e => e.NomeEndereco)
               .HasColumnName(tri + "_nome_endereco")
               .IsRequired();

            modelBuilder.Entity<Endereco>()
               .Property(e => e.Numero)
               .HasColumnName(tri + "_numero")
               .IsRequired();

            modelBuilder.Entity<Endereco>()
               .Property(e => e.Observacoes)
               .HasColumnName(tri + "_observacoes");

            modelBuilder.Entity<Endereco>()
               .Property(e => e.TipoEnderecoId)
               .HasColumnName(tri + "_tpe_id")
               .IsRequired();

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Cidade)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.CidadeId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_CID");

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_CLI");

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.TipoEndereco)
                .WithMany(t => t.Enderecos)
                .HasForeignKey(e => e.TipoEnderecoId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_TPE");

            #endregion

            #region Estado

            tri = "est";

            modelBuilder = configBasico<Estado>(modelBuilder, "ESTADOS", tri);

            modelBuilder.Entity<Estado>()
                .Property(e => e.Nome)
                .HasColumnName(tri + "_nome")
                .IsRequired();

            modelBuilder.Entity<Estado>()
                .Property(e => e.PaisId)
                .HasColumnName(tri + "_pai_id")
                .IsRequired();

            modelBuilder.Entity<Estado>()
                .HasOne(e => e.Pais)
                .WithMany(p => p.Estados)
                .HasForeignKey(e => e.PaisId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_PAI");

            #endregion

            #region GrupoPreco

            tri = "gpp";

            modelBuilder = configMetadado<GrupoPreco>(modelBuilder, "GRUPO_PRECOS", tri);

            modelBuilder.Entity<GrupoPreco>()
                .Property(g => g.MargemLucro)
                .HasColumnName(tri + "_margem_lucro")
                .IsRequired();

            #endregion

            #region Inativacao

            tri = "ina";

            modelBuilder = configBasico<Inativacao>(modelBuilder, "INATIVACOES", tri);

            modelBuilder.Entity<Inativacao>()
                .Property(i => i.LivroId)
                .HasColumnName(tri + "_liv_id")
                .IsRequired();

            modelBuilder.Entity<Inativacao>()
                .Property(i => i.CategoriaId)
                .HasColumnName(tri + "_cta_id")
                .IsRequired();

            modelBuilder.Entity<Inativacao>()
                .HasOne(i => i.Categoria)
                .WithMany(c => c.Inativacoes)
                .HasForeignKey(i => i.CategoriaId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_CTA");

            modelBuilder.Entity<Inativacao>()
                .HasOne(i => i.Livro)
                .WithMany(l => l.Inativacoes)
                .HasForeignKey(i => i.LivroId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_LIV");

            #endregion

            #region Livro

            tri = "liv";

            modelBuilder = configBasico<Livro>(modelBuilder, "LIVROS", tri);

            modelBuilder.Entity<Livro>()
                .Property(l => l.Altura)
                .HasColumnName(tri + "_altura")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Autor)
                .HasColumnName(tri + "_autor")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Capa)
                .HasColumnName(tri + "_capa")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.CodigoBarras)
                .HasColumnName(tri + "_codigo_barras")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Comprimento)
                .HasColumnName(tri + "_comprimento")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.DtLancamento)
                .HasColumnName(tri + "_dt_lancamento")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Edicao)
                .HasColumnName(tri + "_edicao")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.EditoraId)
                .HasColumnName(tri + "_edi_id")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Estoque)
                .HasColumnName(tri + "_estoque")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.EstoqueBloqueado)
                .HasColumnName(tri + "_estoque_bloqueado")
                .IsRequired()
                .HasDefaultValue(0);

            modelBuilder.Entity<Livro>()
                .Property(l => l.GrupoPrecoId)
                .HasColumnName(tri + "_gpp_id")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Isbn)
                .HasColumnName(tri + "_isbn")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Largura)
                .HasColumnName(tri + "_largura")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.MaiorCusto)
                .HasColumnName(tri + "_maior_custo")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Paginas)
                .HasColumnName(tri + "_num_pag")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Peso)
                .HasColumnName(tri + "_peso")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Sinopse)
                .HasColumnName(tri + "_sinopse")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Titulo)
                .HasColumnName(tri + "_titulo")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Valor)
                .HasColumnName(tri + "_valor")
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .HasOne(l => l.Editora)
                .WithMany(e => e.Livros)
                .HasForeignKey(l => l.EditoraId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_EDI");

            modelBuilder.Entity<Livro>()
                .HasOne(l => l.GrupoPreco)
                .WithMany(g => g.Livros)
                .HasForeignKey(l => l.GrupoPrecoId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_GPP");

            #endregion

            #region LivroCategoriaLivro

            tri = "lcl";

            modelBuilder.Entity<LivroCategoriaLivro>().ToTable("LIVROS_CATEGORIAS_LIVROS");

            modelBuilder.Entity<LivroCategoriaLivro>().HasKey(l => new { l.LivroId, l.CategoriaLivroId})
                .HasName("PK_" + tri.ToUpper());

            modelBuilder.Entity<LivroCategoriaLivro>()
                .Property(l => l.LivroId)
                .HasColumnName(tri + "_liv_id")
                .IsRequired();

            modelBuilder.Entity<LivroCategoriaLivro>()
                .Property(l => l.CategoriaLivroId)
                .HasColumnName(tri + "_ctl_id")
                .IsRequired();

            modelBuilder.Entity<LivroCategoriaLivro>()
                .HasOne(l => l.CategoriaLivro)
                .WithMany(c => c.LivrosCategoriaLivros)
                .HasForeignKey(l => l.CategoriaLivroId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_CTL");

            modelBuilder.Entity<LivroCategoriaLivro>()
                .HasOne(l => l.Livro)
                .WithMany(l => l.LivrosCategoriaLivros)
                .HasForeignKey(l => l.LivroId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_LIV");

            #endregion

            #region LivroPedido

            tri = "lip";

            modelBuilder = configBasico<LivroPedido>(modelBuilder, "LIVROS_PEDIDOS", tri);

            modelBuilder.Entity<LivroPedido>()
                .Ignore(l => l.Inativo);

            modelBuilder.Entity<LivroPedido>()
                .Property(l => l.LivroId)
                .HasColumnName(tri + "_liv_id")
                .IsRequired();

            modelBuilder.Entity<LivroPedido>()
                .Property(l => l.PedidoId)
                .HasColumnName(tri + "_ped_id")
                .IsRequired();

            modelBuilder.Entity<LivroPedido>()
                .Property(l => l.Trocado)
                .HasColumnName(tri + "_trocado")
                .IsRequired();

            modelBuilder.Entity<LivroPedido>()
                .HasOne(l => l.Livro)
                .WithMany(l => l.LivroPedidos)
                .HasForeignKey(l => l.LivroId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_LIV");

            modelBuilder.Entity<LivroPedido>()
                .HasOne(l => l.Pedido)
                .WithMany(p => p.LivrosPedidos)
                .HasForeignKey(l => l.PedidoId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_PED");

            #endregion

            #region Pais

            tri = "pai";

            modelBuilder = configBasico<Pais>(modelBuilder, "PAISES", tri);

            modelBuilder.Entity<Pais>()
                .Property(c => c.Nome)
                .HasColumnName(tri + "_nome")
                .IsRequired();

            #endregion

            #region Pedido

            tri = "ped";

            modelBuilder = configBasico<Pedido>(modelBuilder, "PEDIDOS", tri);

            modelBuilder.Entity<Pedido>()
                .Property(p => p.ClienteId)
                .HasColumnName(tri + "_cli_id")
                .IsRequired();

            modelBuilder.Entity<Pedido>()
                .Property(c => c.CodigoId)
                .HasColumnName($"{tri}_cod_id");

            modelBuilder.Entity<Pedido>()
                .Property(p => p.CupomId)
                .HasColumnName(tri + "_cup_id");

            modelBuilder.Entity<Pedido>()
                .Property(p => p.EnderecoId)
                .HasColumnName(tri + "_end_id")
                .IsRequired();

            modelBuilder.Entity<Pedido>()
                .Property(p => p.Status)
                .HasColumnName(tri + "_status")
                .IsRequired();

            modelBuilder.Entity<Pedido>()
                .Property(p => p.ValorTotal)
                .HasColumnName(tri + "_valor_total")
                .IsRequired();

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(c => c.ClienteId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_CLI");

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.CodigoPromocional)
                .WithOne(c => c.Pedido)
                .HasForeignKey<Pedido>(p => p.CodigoId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_COD");

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Endereco)
                .WithMany(e => e.Pedidos)
                .HasForeignKey(p => p.EnderecoId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_END")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cupom)
                .WithOne(c => c.Pedido)
                .HasForeignKey<Pedido>( p => p.CupomId )
                .HasConstraintName("FK_" + tri.ToUpper() + "_CUP");

            #endregion

            #region Telefone

            tri = "tel";

            modelBuilder = configBasico<Telefone>(modelBuilder, "TELEFONES", tri);

            modelBuilder.Entity<Telefone>()
                .Property(t => t.ClienteId)
                .HasColumnName(tri + "_cli_id")
                .IsRequired();

            modelBuilder.Entity<Telefone>()
                .Property(t => t.Ddd)
                .HasColumnName(tri + "_ddd")
                .IsRequired();

            modelBuilder.Entity<Telefone>()
                .Property(t => t.EFavorito)
                .HasColumnName(tri + "_e_favorito")
                .IsRequired();

            modelBuilder.Entity<Telefone>()
                .Property(t => t.Numero)
                .HasColumnName(tri + "_numero")
                .IsRequired();

            modelBuilder.Entity<Telefone>()
                .Property(t => t.TipoTelefoneId)
                .HasColumnName(tri + "_tpd_id")
                .IsRequired();

            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.Cliente)
                .WithMany(c => c.Telefones)
                .HasForeignKey(t => t.ClienteId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_CLI");

            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.TipoTelefone)
                .WithMany(t => t.Telefones)
                .HasForeignKey(t => t.TipoTelefoneId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_TPT");

            #endregion

            #region TipoEndereco

            tri = "tpe";

            modelBuilder = configMetadado<TipoEndereco>(modelBuilder, "TIPOS_ENDERECO", tri);

            #endregion

            #region TipoTelefone

            tri = "tpt";

            modelBuilder = configMetadado<TipoTelefone>(modelBuilder, "TIPOS_TELEFONES", tri);

            #endregion

            #region Troca

            tri = "tro";

            modelBuilder = configBasico<Troca>(modelBuilder, "TROCAS", tri);

            modelBuilder.Entity<Troca>()
                .Property(t => t.ClienteId)
                .HasColumnName(tri + "_cli_id")
                .IsRequired();

            modelBuilder.Entity<Troca>()
                .Property(t => t.LivroPedidoId)
                .HasColumnName(tri + "_lip_id")
                .IsRequired();

            modelBuilder.Entity<Troca>()
                .Property(t => t.StatusTroca)
                .HasColumnName(tri + "_status")
                .IsRequired();

            modelBuilder.Entity<Troca>()
                .HasOne(t => t.Cliente)
                .WithMany(c => c.Trocas)
                .HasForeignKey(t => t.ClienteId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_CLI");

            modelBuilder.Entity<Troca>()
                .HasOne(t => t.LivroPedido)
                .WithOne(l => l.Troca)
                .HasForeignKey<Troca>(t => t.LivroPedidoId)
                .HasConstraintName("FK_" + tri.ToUpper() + "_LIP")
                .OnDelete(DeleteBehavior.NoAction);

            #endregion  

            #region Usuario

            tri = "usu";

            modelBuilder = configBasico<Usuario>(modelBuilder, "USUARIOS", tri);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .HasColumnName(tri + "_email")
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Senha)
                .HasColumnName(tri + "_senha")
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Role)
                .HasColumnName(tri + "_role")
                .IsRequired();

            #endregion

        }

        public DbSet<Ativacao> Ativacaos { get; set; }
        public DbSet<BandeiraCartaoCredito> BandeiraCartaoCreditos { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<CarrinhoLivro> CarrinhosLivro { get; set; }
        public DbSet<CartaoCredito> CartaoCreditos { get; set; }
        public DbSet<CartaoPedido> CartaoPedidos { get; set; }
        public DbSet<CategoriaAtivacao> CategoriaAtivacaos { get; set; }
        public DbSet<CategoriaInativacao> CategoriasInativacaos { get; set; }
        public DbSet<CategoriaLivro> CategoriaLivros { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CodigoPromocional> CodigosPromocionais { get; set; }
        public DbSet<Cupom> Cupons { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<GrupoPreco> GrupoPrecos { get; set; }
        public DbSet<Inativacao> Inativacaos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<LivroCategoriaLivro> LivrosCategoriaLivros { get; set; }
        public DbSet<LivroPedido> LivroPedidos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TipoEndereco> TipoEnderecos { get; set; }
        public DbSet<TipoTelefone> TipoTelefones { get; set; }
        public DbSet<Troca> Trocas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        private ModelBuilder configBasico<T>  (ModelBuilder mb, string nomeTabela, string trigrama)
            where T : EntidadeDominio
        {
            mb.Entity<T>().ToTable(nomeTabela);

            mb.Entity<T>()
                .HasKey(t => new { t.Id })
                .HasName("PK_" + trigrama.ToUpper());

            mb.Entity<T>()
                .Property(t => t.Id)
                .HasColumnName(trigrama.ToLower() + "_id") ;

            mb.Entity<T>()
                .Property(t => t.DtCadastro)
                .HasColumnName(trigrama.ToLower() + "_dt_cadastro")
                .IsRequired();

            mb.Entity<T>()
                .Property(t => t.Inativo)
                .HasColumnName(trigrama.ToLower() + "_inativo")
                .IsRequired();

            return mb;
        }

        private ModelBuilder configMetadado<T> (ModelBuilder mb, string nomeTabela, string trigrama)
            where T: MetadadoBase
        {
            mb = configBasico<T>(mb, nomeTabela, trigrama);

            mb.Entity<T>()
                .Property(t => t.Nome)
                .HasColumnName(trigrama + "_nome")
                .IsRequired();

            return mb;

        }
    }
}
