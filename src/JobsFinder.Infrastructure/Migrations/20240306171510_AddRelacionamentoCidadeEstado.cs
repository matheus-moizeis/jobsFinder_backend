using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacionamentoCidadeEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EstadoId",
                table: "Cidades",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstadoId",
                table: "Cidades",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_Id",
                table: "Cidades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_Estados_EstadoId",
                table: "Cidades",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_Estados_EstadoId",
                table: "Cidades");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_EstadoId",
                table: "Cidades");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_Id",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Cidades");
        }
    }
}
