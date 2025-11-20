using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Modelo.Infra
{
    public class DbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public void CriarTabelas()
        {
            var db = CreateConnection();

            var createAlunoQuery = """
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Aluno' AND xtype = 'U')
                CREATE TABLE Aluno (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Matricula VARCHAR(50) NOT NULL,
                    Nome VARCHAR(255) NOT NULL,
                    CEP VARCHAR(9) NOT NULL,
                    Logradouro VARCHAR(200) NOT NULL,
                    Cidade VARCHAR(200) NOT NULL,
                    Bairro VARCHAR(200) NOT NULL
                );
                """;

            db.Open();
            var cmd = db.CreateCommand();
            cmd.CommandText = createAlunoQuery;
            cmd.ExecuteNonQuery();
            db.Close();

        }
    }

}
