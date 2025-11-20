using Modelo.Domain;

namespace Modelo.Infra.Repositorio.interfaces
{
    public interface IAlunoRepositorio
    {
        Task<Aluno> BuscarAluno(int ID);

        Task AdicionarAluno(Aluno aluno);

        Task<Aluno> AtualizarAluno(Aluno aluno);

        Task<bool> Excluir(int ID);
    }
}
