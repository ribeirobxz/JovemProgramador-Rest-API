using Modelo.Domain;

namespace Modelo.Aplication.Interface
{
    public interface IAlunoApplication
    {
        Task<Aluno> BuscarAluno(int ID);

        Task AdicionarAluno(Aluno aluno);

        Task<Aluno> AtualizarAluno(Aluno aluno);

        Task<bool> Excluir(int ID);
    }
}
