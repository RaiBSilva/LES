using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class dbEntrega1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BANDEIRAS_CARTAO_CREDITO",
                columns: table => new
                {
                    ban_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ban_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ban_inativo = table.Column<bool>(type: "bit", nullable: false),
                    ban_nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAN", x => x.ban_id);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIAS_ATIVACAO",
                columns: table => new
                {
                    cta_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cta_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cta_inativo = table.Column<bool>(type: "bit", nullable: false),
                    cta_nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTA", x => x.cta_id);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIAS_INATIVACAO",
                columns: table => new
                {
                    cti_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cti_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cti_inativo = table.Column<bool>(type: "bit", nullable: false),
                    cti_nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTI", x => x.cti_id);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIAS_LIVRO",
                columns: table => new
                {
                    ctl_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ctl_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ctl_inativo = table.Column<bool>(type: "bit", nullable: false),
                    ctl_nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTL", x => x.ctl_id);
                });

            migrationBuilder.CreateTable(
                name: "EDITORAS",
                columns: table => new
                {
                    edi_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    edi_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    edi_inativo = table.Column<bool>(type: "bit", nullable: false),
                    edi_nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI", x => x.edi_id);
                });

            migrationBuilder.CreateTable(
                name: "GRUPO_PRECOS",
                columns: table => new
                {
                    gpp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gpp_margem_lucro = table.Column<double>(type: "float", nullable: false),
                    gpp_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gpp_inativo = table.Column<bool>(type: "bit", nullable: false),
                    gpp_nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPP", x => x.gpp_id);
                });

            migrationBuilder.CreateTable(
                name: "PAISES",
                columns: table => new
                {
                    pai_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pai_nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pai_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pai_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAI", x => x.pai_id);
                });

            migrationBuilder.CreateTable(
                name: "TIPOS_ENDERECO",
                columns: table => new
                {
                    tpe_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tpe_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tpe_inativo = table.Column<bool>(type: "bit", nullable: false),
                    tpe_nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPE", x => x.tpe_id);
                });

            migrationBuilder.CreateTable(
                name: "TIPOS_TELEFONES",
                columns: table => new
                {
                    tpt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tpt_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tpt_inativo = table.Column<bool>(type: "bit", nullable: false),
                    tpt_nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPT", x => x.tpt_id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    usu_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usu_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usu_senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usu_role = table.Column<int>(type: "int", nullable: false),
                    usu_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usu_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USU", x => x.usu_id);
                });

            migrationBuilder.CreateTable(
                name: "LIVROS",
                columns: table => new
                {
                    liv_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    liv_altura = table.Column<int>(type: "int", nullable: false),
                    liv_autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    liv_codigo_barras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    liv_comprimento = table.Column<int>(type: "int", nullable: false),
                    liv_edi_id = table.Column<int>(type: "int", nullable: false),
                    liv_estoque = table.Column<int>(type: "int", nullable: false),
                    liv_gpp_id = table.Column<int>(type: "int", nullable: false),
                    liv_isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    liv_largura = table.Column<int>(type: "int", nullable: false),
                    liv_num_pag = table.Column<int>(type: "int", nullable: false),
                    liv_peso = table.Column<double>(type: "float", nullable: false),
                    liv_sinopse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    liv_valor = table.Column<double>(type: "float", nullable: false),
                    liv_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    liv_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIV", x => x.liv_id);
                    table.ForeignKey(
                        name: "FK_LIV_EDI",
                        column: x => x.liv_edi_id,
                        principalTable: "EDITORAS",
                        principalColumn: "edi_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LIV_GPP",
                        column: x => x.liv_gpp_id,
                        principalTable: "GRUPO_PRECOS",
                        principalColumn: "gpp_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ESTADOS",
                columns: table => new
                {
                    est_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    est_nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    est_pai_id = table.Column<int>(type: "int", nullable: false),
                    est_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    est_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EST", x => x.est_id);
                    table.ForeignKey(
                        name: "FK_EST_PAI",
                        column: x => x.est_pai_id,
                        principalTable: "PAISES",
                        principalColumn: "pai_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    cli_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cli_codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cli_cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cli_dt_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    cli_nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cli_nota = table.Column<int>(type: "int", nullable: false),
                    cli_usu_id = table.Column<int>(type: "int", nullable: false),
                    cli_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cli_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLI", x => x.cli_id);
                    table.ForeignKey(
                        name: "FK_CLI_USU",
                        column: x => x.cli_usu_id,
                        principalTable: "USUARIOS",
                        principalColumn: "usu_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ATIVACOES",
                columns: table => new
                {
                    ati_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ati_cta_id = table.Column<int>(type: "int", nullable: false),
                    ati_liv_id = table.Column<int>(type: "int", nullable: false),
                    ati_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ati_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATI", x => x.ati_id);
                    table.ForeignKey(
                        name: "FK_ATI_CTA",
                        column: x => x.ati_cta_id,
                        principalTable: "CATEGORIAS_ATIVACAO",
                        principalColumn: "cta_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ATI_LIV",
                        column: x => x.ati_liv_id,
                        principalTable: "LIVROS",
                        principalColumn: "liv_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INATIVACOES",
                columns: table => new
                {
                    ina_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ina_cta_id = table.Column<int>(type: "int", nullable: false),
                    ina_liv_id = table.Column<int>(type: "int", nullable: false),
                    ina_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ina_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INA", x => x.ina_id);
                    table.ForeignKey(
                        name: "FK_INA_CTA",
                        column: x => x.ina_cta_id,
                        principalTable: "CATEGORIAS_INATIVACAO",
                        principalColumn: "cti_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INA_LIV",
                        column: x => x.ina_liv_id,
                        principalTable: "LIVROS",
                        principalColumn: "liv_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LIVROS_CATEGORIAS_LIVROS",
                columns: table => new
                {
                    lcl_ctl_id = table.Column<int>(type: "int", nullable: false),
                    lcl_liv_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LCL", x => new { x.lcl_liv_id, x.lcl_ctl_id });
                    table.ForeignKey(
                        name: "FK_LCL_CTL",
                        column: x => x.lcl_ctl_id,
                        principalTable: "CATEGORIAS_LIVRO",
                        principalColumn: "ctl_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LCL_LIV",
                        column: x => x.lcl_liv_id,
                        principalTable: "LIVROS",
                        principalColumn: "liv_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CIDADES",
                columns: table => new
                {
                    cid_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cid_nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cid_pai_id = table.Column<int>(type: "int", nullable: false),
                    cid_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cid_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CID", x => x.cid_id);
                    table.ForeignKey(
                        name: "FK_CID_EST",
                        column: x => x.cid_pai_id,
                        principalTable: "ESTADOS",
                        principalColumn: "est_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CARTOES_CREDITO",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_ban_id = table.Column<int>(type: "int", nullable: false),
                    car_codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    car_cvv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    car_e_favorito = table.Column<bool>(type: "bit", nullable: false),
                    car_nome_impresso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    car_vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    car_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    car_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR", x => x.car_id);
                    table.ForeignKey(
                        name: "FK_CAR_BAN",
                        column: x => x.car_ban_id,
                        principalTable: "BANDEIRAS_CARTAO_CREDITO",
                        principalColumn: "ban_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CARTOES_CREDITO_CLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "CLIENTES",
                        principalColumn: "cli_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDOS",
                columns: table => new
                {
                    ped_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ped_cli_id = table.Column<int>(type: "int", nullable: false),
                    ped_status = table.Column<int>(type: "int", nullable: false),
                    ped_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ped_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PED", x => x.ped_id);
                    table.ForeignKey(
                        name: "FK_PED_PED",
                        column: x => x.ped_cli_id,
                        principalTable: "CLIENTES",
                        principalColumn: "cli_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TELEFONES",
                columns: table => new
                {
                    tel_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tel_cli_id = table.Column<int>(type: "int", nullable: false),
                    tel_ddd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tel_e_favorito = table.Column<bool>(type: "bit", nullable: false),
                    tel_numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tel_tpd_id = table.Column<int>(type: "int", nullable: false),
                    tel_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tel_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEL", x => x.tel_id);
                    table.ForeignKey(
                        name: "FK_TEL_CLI",
                        column: x => x.tel_cli_id,
                        principalTable: "CLIENTES",
                        principalColumn: "cli_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TEL_TPT",
                        column: x => x.tel_tpd_id,
                        principalTable: "TIPOS_TELEFONES",
                        principalColumn: "tpt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECOS",
                columns: table => new
                {
                    end_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    end_cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_cid_id = table.Column<int>(type: "int", nullable: false),
                    end_complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_e_cobranca = table.Column<bool>(type: "bit", nullable: false),
                    end_e_entrega = table.Column<bool>(type: "bit", nullable: false),
                    end_e_favorito = table.Column<bool>(type: "bit", nullable: false),
                    end_e_residencia = table.Column<bool>(type: "bit", nullable: false),
                    end_logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_nome_endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_tpe_id = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    end_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_END", x => x.end_id);
                    table.ForeignKey(
                        name: "FK_END_CID",
                        column: x => x.end_cid_id,
                        principalTable: "CIDADES",
                        principalColumn: "cid_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_END_TPE",
                        column: x => x.end_tpe_id,
                        principalTable: "TIPOS_ENDERECO",
                        principalColumn: "tpe_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ENDERECOS_CLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "CLIENTES",
                        principalColumn: "cli_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LIVROS_PEDIDOS",
                columns: table => new
                {
                    lip_liv_id = table.Column<int>(type: "int", nullable: false),
                    lip_ped_id = table.Column<int>(type: "int", nullable: false),
                    lip_trocado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIP", x => new { x.lip_liv_id, x.lip_ped_id });
                    table.ForeignKey(
                        name: "FK_LIP_LIV",
                        column: x => x.lip_liv_id,
                        principalTable: "LIVROS",
                        principalColumn: "liv_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LIP_PED",
                        column: x => x.lip_ped_id,
                        principalTable: "PEDIDOS",
                        principalColumn: "ped_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATIVACOES_ati_cta_id",
                table: "ATIVACOES",
                column: "ati_cta_id");

            migrationBuilder.CreateIndex(
                name: "IX_ATIVACOES_ati_liv_id",
                table: "ATIVACOES",
                column: "ati_liv_id");

            migrationBuilder.CreateIndex(
                name: "IX_CARTOES_CREDITO_car_ban_id",
                table: "CARTOES_CREDITO",
                column: "car_ban_id");

            migrationBuilder.CreateIndex(
                name: "IX_CARTOES_CREDITO_ClienteId",
                table: "CARTOES_CREDITO",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CIDADES_cid_pai_id",
                table: "CIDADES",
                column: "cid_pai_id");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_cli_usu_id",
                table: "CLIENTES",
                column: "cli_usu_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECOS_ClienteId",
                table: "ENDERECOS",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECOS_end_cid_id",
                table: "ENDERECOS",
                column: "end_cid_id");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECOS_end_tpe_id",
                table: "ENDERECOS",
                column: "end_tpe_id");

            migrationBuilder.CreateIndex(
                name: "IX_ESTADOS_est_pai_id",
                table: "ESTADOS",
                column: "est_pai_id");

            migrationBuilder.CreateIndex(
                name: "IX_INATIVACOES_ina_cta_id",
                table: "INATIVACOES",
                column: "ina_cta_id");

            migrationBuilder.CreateIndex(
                name: "IX_INATIVACOES_ina_liv_id",
                table: "INATIVACOES",
                column: "ina_liv_id");

            migrationBuilder.CreateIndex(
                name: "IX_LIVROS_liv_edi_id",
                table: "LIVROS",
                column: "liv_edi_id");

            migrationBuilder.CreateIndex(
                name: "IX_LIVROS_liv_gpp_id",
                table: "LIVROS",
                column: "liv_gpp_id");

            migrationBuilder.CreateIndex(
                name: "IX_LIVROS_CATEGORIAS_LIVROS_lcl_ctl_id",
                table: "LIVROS_CATEGORIAS_LIVROS",
                column: "lcl_ctl_id");

            migrationBuilder.CreateIndex(
                name: "IX_LIVROS_PEDIDOS_lip_ped_id",
                table: "LIVROS_PEDIDOS",
                column: "lip_ped_id");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_ped_cli_id",
                table: "PEDIDOS",
                column: "ped_cli_id");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONES_tel_cli_id",
                table: "TELEFONES",
                column: "tel_cli_id");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONES_tel_tpd_id",
                table: "TELEFONES",
                column: "tel_tpd_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATIVACOES");

            migrationBuilder.DropTable(
                name: "CARTOES_CREDITO");

            migrationBuilder.DropTable(
                name: "ENDERECOS");

            migrationBuilder.DropTable(
                name: "INATIVACOES");

            migrationBuilder.DropTable(
                name: "LIVROS_CATEGORIAS_LIVROS");

            migrationBuilder.DropTable(
                name: "LIVROS_PEDIDOS");

            migrationBuilder.DropTable(
                name: "TELEFONES");

            migrationBuilder.DropTable(
                name: "CATEGORIAS_ATIVACAO");

            migrationBuilder.DropTable(
                name: "BANDEIRAS_CARTAO_CREDITO");

            migrationBuilder.DropTable(
                name: "CIDADES");

            migrationBuilder.DropTable(
                name: "TIPOS_ENDERECO");

            migrationBuilder.DropTable(
                name: "CATEGORIAS_INATIVACAO");

            migrationBuilder.DropTable(
                name: "CATEGORIAS_LIVRO");

            migrationBuilder.DropTable(
                name: "LIVROS");

            migrationBuilder.DropTable(
                name: "PEDIDOS");

            migrationBuilder.DropTable(
                name: "TIPOS_TELEFONES");

            migrationBuilder.DropTable(
                name: "ESTADOS");

            migrationBuilder.DropTable(
                name: "EDITORAS");

            migrationBuilder.DropTable(
                name: "GRUPO_PRECOS");

            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "PAISES");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
