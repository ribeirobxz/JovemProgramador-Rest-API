using Dapper;
using Modelo.Domain;
using Modelo.Infra.Repositorio.interfaces;

namespace Modelo.Infra.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        DbConnectionFactory _dbConnectionFactory;

        public AlunoRepositorio(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<Aluno> BuscarAluno(int ID)
        {
            using var connnection = _dbConnectionFactory.CreateConnection();

            string sql = "select * from Aluno where Id = @Id;";

            var aluno = await connnection.QueryFirstOrDefaultAsync<Aluno>(sql, new { Id = ID });

            return aluno;
        }

        public async Task AdicionarAluno(Aluno aluno)
        {
            using var connnection = _dbConnectionFactory.CreateConnection();

            string sql = "insert into Aluno (Matricula, Nome, CEP, Logradouro, Cidade, Bairro) VALUES (@Matricula, @Nome, @CEP, @Logradouro, @Cidade, @Bairro); SELECT SCOPE_IDENTITY();";

            int ID = await connnection.QueryFirstOrDefaultAsync<int>(sql, aluno);
            aluno.Id = ID;
        }

        public async Task<Aluno> AtualizarAluno(Aluno aluno)
        {
            using var connnection = _dbConnectionFactory.CreateConnection();

            string sql = "Update Aluno set Matricula = @Matricula, Nome = @Nome, CEP = @CEP, Logradouro = @Logradouro, Cidade = @Cidade, Bairro = @Bairro WHERE Id = @Id; select * from Aluno where Id = @Id;";

            Aluno aluno1 = await connnection.QueryFirstOrDefaultAsync<Aluno>(sql, aluno);
            return aluno1;
        }

        public async Task<bool> Excluir(int ID)
        {
            using var connnection = _dbConnectionFactory.CreateConnection();

            string sql = "DELETE FROM Aluno where Id = @Id;";

            var ret = await connnection.ExecuteAsync(sql, new { Id = ID });
            return ret != 0;
        }
    }
}
