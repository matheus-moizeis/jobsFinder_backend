using Dapper;
using Npgsql;

namespace JobsFinder.Infrastructure.Database;
public static class Database
{
    public static void CreateDatabase(string conexaoBD, string nomeBD)
    {
        using var connection = new NpgsqlConnection(conexaoBD);

        var parametros = new DynamicParameters();
        parametros.Add("nomeBD", nomeBD);

        var registros = connection.Query("SELECT datname FROM pg_database WHERE datname = @nomeBD",
            parametros);

        if (!registros.Any()) connection.Execute($"CREATE DATABASE {nomeBD}");
    }
}
