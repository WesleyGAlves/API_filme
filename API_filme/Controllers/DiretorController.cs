using API_filme.Dto.Diretor;
using API_filme.Models;
using API_filme.Service.Diretor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API_filme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    /*
     O modificador async indica que o método é assíncrono. Permite que o método execute operações que podem demorar sem bloquear a thread principal.
     combinado com await, ele "pausa" a execução do método até que a tarefa assíncrona seja concluída, mas sem bloquear o restante do código. 
     Quando a tarefa termina, a execução continua.

     Task é um objeto que encapsula o resultado de uma operação que pode ainda não ter sido concluída. No caso de um método marcado como async,
     a Task é usada para que o chamador saiba quando a operação termina e, opcionalmente, qual o resultado da operação.
     */

    public class DiretorController : ControllerBase
    {
        private readonly IDiretorInterface _diretorInterface; // Injeção de dependência da interface de serviço para diretores

        public DiretorController(IDiretorInterface diretorInterface) // Construtor que recebe a implementação da interface de serviço
        {
            _diretorInterface = diretorInterface;
        }


        [HttpGet("ListarDiretores")] // Método para listar todos os diretores
        public async Task<ActionResult<ResponseModel<List<DiretorModel>>>> ListarDiretores()
        {
            var diretores = await _diretorInterface.ListarDiretores(); // Chama o serviço para listar os diretores
            return Ok(diretores);  // Retorna os diretores
        }


        [HttpGet("BuscarDiretorPorId/{idDiretor}")] // Método para buscar um diretor pelo ID
        public async Task<ActionResult<ResponseModel<List<DiretorModel>>>> BuscarDiretorPorId(int idDiretor)
        {
            var diretor = await _diretorInterface.BuscarDiretorPorId(idDiretor);  // Chama o serviço para buscar um diretor específico pelo ID
            return Ok(diretor); // Retorna o diretor
        }


        [HttpGet("BuscarDiretorPorIdFilme/{idFilme}")] // Método para buscar um diretor com base no ID de um filme
        public async Task<ActionResult<ResponseModel<List<DiretorModel>>>> BuscarDiretorPorIdFilme(int idFilme)
        {
            var diretor = await _diretorInterface.BuscarDiretorPorIdFilme(idFilme);  // Chama o serviço para buscar diretores relacionados a um filme
            return Ok(diretor); // Retorna o diretor
        }


        [HttpPost("CriarDiretor")] // Método para criar um novo diretor
        public async Task<ActionResult<ResponseModel<List<DiretorModel>>>> CriarDiretor(DiretorCriacaoDto diretorCriacaoDto)
        {
            var diretores = await _diretorInterface.CriarDiretor(diretorCriacaoDto); // Chama o serviço para criar um novo diretor a partir dos dados do DTO
            return Ok(diretores); // Retorna a lista de diretores após a criação
        }


        [HttpPut("EditarDiretor")] // Método para editar um diretor existente
        public async Task<ActionResult<ResponseModel<List<DiretorModel>>>> EditarDiretor(DiretorEdicaoDto diretorEdicaoDto)
        {
            var diretores = await _diretorInterface.EditarDiretor(diretorEdicaoDto);  // Chama o serviço para editar um diretor a partir dos dados do DTO
            return Ok(diretores);  // Retorna a lista de diretores atualizada
        }


        [HttpDelete("ExcluirDiretor")]  // Método para excluir um diretor pelo ID
        public async Task<ActionResult<ResponseModel<List<DiretorModel>>>> ExcluirDiretor(int idDiretor)
        {
            var diretores = await _diretorInterface.ExcluirDiretor(idDiretor); // Chama o serviço para excluir o diretor com o ID fornecido
            return Ok(diretores); // Retorna a lista de diretores
        }
    }
}