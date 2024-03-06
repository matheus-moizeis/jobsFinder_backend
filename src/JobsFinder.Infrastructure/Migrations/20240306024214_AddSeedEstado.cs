using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "NomeEstado", "Uf", "DataCriacao" },
                values: new object[,]
                {
                    {"Acre", "AC", DateTime.UtcNow },
                    {"Alagoas", "AL", DateTime.UtcNow },
                    {"Amapá", "AP", DateTime.UtcNow },
                    {"Amazonas", "AM", DateTime.UtcNow },
                    {"Bahia", "BA", DateTime.UtcNow },
                    {"Ceará", "CE", DateTime.UtcNow },
                    {"Distrito Federal", "DF", DateTime.UtcNow },
                    {"Espírito Santo", "ES", DateTime.UtcNow },
                    {"Goiás", "GO", DateTime.UtcNow },
                    {"Maranhão", "MA", DateTime.UtcNow },
                    {"Mato Grosso", "MT", DateTime.UtcNow },
                    {"Mato Grosso do Sul", "MS", DateTime.UtcNow },
                    {"Minas Gerais", "MG", DateTime.UtcNow },
                    {"Pará", "PA", DateTime.UtcNow},
                    {"Paraíba", "PB", DateTime.UtcNow },
                    {"Paraná", "PR", DateTime.UtcNow },
                    {"Pernambuco", "PE", DateTime.UtcNow },
                    {"Piauí", "PI", DateTime.UtcNow },
                    {"Rio de Janeiro", "RJ", DateTime.UtcNow },
                    {"Rio Grande do Norte", "RN", DateTime.UtcNow },
                    {"Rio Grande do Sul", "RS", DateTime.UtcNow },
                    {"Rondônia", "RO", DateTime.UtcNow },
                    {"Roraima", "RR", DateTime.UtcNow },
                    {"Santa Catarina", "SC", DateTime.UtcNow },
                    {"São Paulo", "SP", DateTime.UtcNow },
                    {"Sergipe", "SE", DateTime.UtcNow },
                    {"Tocantins", "TO", DateTime.UtcNow }

                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
