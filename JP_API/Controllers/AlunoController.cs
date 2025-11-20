using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Aplication.Interface;
using Modelo.Domain;

namespace JP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoApplication _alunoApplication;
        private readonly ICepService _cepService;
     
        public AlunoController(IAlunoApplication alunoApplication, ICepService cepService)
        {
            _alunoApplication = alunoApplication;
            _cepService = cepService;
        }

        [HttpGet("BuscarDadosAluno/{id}")]
        public async Task<IActionResult> BuscarDadosAluno(int id) 
        {

            Retorno<Aluno> retorno = new(null);

            try
            {
                Aluno aluno = await _alunoApplication.BuscarAluno(id);
                retorno.CarregaRetorno(aluno, true, "Aluno encontrado com sucesso", 200);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.CarregaRetorno(false, ex.Message, 400);
                return BadRequest(retorno);
            }

        }

        [HttpPost("AdicionarAluno")]
        public async Task<IActionResult> AdicionarAluno([FromBody]Aluno aluno)
        {
            Retorno<Aluno> retorno = new(null);
            try
            {
                await _alunoApplication.AdicionarAluno(aluno);
                retorno.CarregaRetorno(aluno, true, "Aluno adicionado com sucesso", 200);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.CarregaRetorno(false, ex.Message, 400);
                return BadRequest(retorno);
            }

        }
        [HttpPatch("AtualizarAluno")]
        public async Task<IActionResult> AtualizarAluno([FromBody] Aluno aluno)
        {

            Retorno<Aluno> retorno = new(null);
            try
            {
                var aluno1 = await _alunoApplication.AtualizarAluno(aluno);
                retorno.CarregaRetorno(aluno1, true, "Aluno atualizado com sucesso", 200);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.CarregaRetorno(false, ex.Message, 400);
                return BadRequest(retorno);
            }

        }

        [HttpDelete("DeletarAluno/{id}")]
        public async Task<IActionResult> DeletarAluno(int id)
        {

            Retorno retorno = new();
            try
            {
                await _alunoApplication.Excluir(id);
                retorno.CarregaRetorno(true, "Aluno excluído com sucesso", 200);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.CarregaRetorno(false, ex.Message, 400);
                return BadRequest(retorno);
            }

        }



        [HttpGet("BuscarCep/{cep}")]
        public async Task<IActionResult> BuscarCep(string cep) 
        {

            Retorno<Endereco> retorno = new(null);
            try
            {
                var endereco = await _cepService.BuscarfEnderecoPorCep(cep);
                retorno.CarregaRetorno(endereco, true, "Endereço encontrado com sucesso", 200);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.CarregaRetorno(false, ex.Message, 400);
                return BadRequest(retorno);
            }

        }


        /*
        [HttpGet("aa")]
        public string AA() 
        {
            return "aa";
        }
        */

    }
}
