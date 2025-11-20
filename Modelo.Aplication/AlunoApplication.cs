using Modelo.Aplication.Interface;
using Modelo.Domain;
using Modelo.Infra.Repositorio.interfaces;

namespace Modelo.Aplication
{
    public class AlunoApplication : IAlunoApplication
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoApplication(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public async Task AdicionarAluno(Aluno aluno)
        {
            await _alunoRepositorio.AdicionarAluno(aluno);
        }

        public async Task<Aluno> BuscarAluno(int ID)
        {
            return await _alunoRepositorio.BuscarAluno(ID);
        }

        public async Task<Aluno> AtualizarAluno(Aluno aluno)
        {
            Aluno aluno1 = await _alunoRepositorio.BuscarAluno(aluno.Id);
            aluno.CEP ??= aluno1.CEP;
            aluno.Logradouro ??= aluno1.Logradouro;
            aluno.Bairro ??= aluno1.Bairro;
            aluno.Matricula ??= aluno1.Matricula;
            aluno.Cidade ??= aluno1.Cidade;
            aluno.Nome ??= aluno1.Nome;

            return await _alunoRepositorio.AtualizarAluno(aluno);
        }

        public async Task<bool> Excluir(int ID)
        {
            return await _alunoRepositorio.Excluir(ID);
        }
    }
}
