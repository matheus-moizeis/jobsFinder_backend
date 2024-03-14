using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JobsFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityPerfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Sobrenome = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<int>(type: "integer", nullable: false),
                    Foto = table.Column<string>(type: "text", nullable: true),
                    DtNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Naturalidade = table.Column<string>(type: "text", nullable: true),
                    Genero = table.Column<int>(type: "integer", nullable: false),
                    Nascionalidade = table.Column<string>(type: "text", nullable: true),
                    EstadoCivil = table.Column<int>(type: "integer", nullable: false),
                    Linkedin = table.Column<string>(type: "text", nullable: true),
                    Site = table.Column<string>(type: "text", nullable: true),
                    Cep = table.Column<int>(type: "integer", nullable: false),
                    Logradouro = table.Column<string>(type: "text", nullable: true),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: true),
                    CarteiraMotorista = table.Column<string>(type: "text", nullable: true),
                    CategoriaCarteiraMotorista = table.Column<int>(type: "integer", nullable: false),
                    IdCidade = table.Column<long>(type: "bigint", nullable: false),
                    CidadeId = table.Column<long>(type: "bigint", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfis_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_CidadeId",
                table: "Perfis",
                column: "CidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perfis");
        }
    }
}
