using API_filme.Dto.Diretor;
using API_filme.Dto.Filme;
using API_filme.Models;
using API_filme.Service.Filme;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_filme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeInterface _filmeInterface; // Injeção de dependência da interface de serviço relacionada a filmes

        public FilmeController(IFilmeInterface filmeInterface)  // Construtor que recebe a implementação da interface de serviço para filmes
        {
            _filmeInterface = filmeInterface;
        }


        [HttpGet("ListarFilmes")] // Método para listar todos os filmes
        public async Task<ActionResult<ResponseModel<List<FilmesModel>>>> ListarFilmes()
        {
            var filmes = await _filmeInterface.ListarFilmes(); // Chama o serviço para listar os filmes
            return Ok(filmes); // Retorna a lista de filmes
        }


        [HttpGet("BuscarFilmePorId/{idFilme}")] // Método para buscar um filme específico pelo ID
        public async Task<ActionResult<ResponseModel<List<FilmesModel>>>> BuscarFilmePorId(int idFilme)
        {
            var filme = await _filmeInterface.BuscarFilmePorId(idFilme); // Chama o serviço para buscar um filme pelo ID
            return Ok(filme); // Retorna o filme
        }


        [HttpGet("BuscarFilmePorIdDiretor/{idDiretor}")] // Método para buscar filmes associados a um diretor específico pelo ID do diretor
        public async Task<ActionResult<ResponseModel<List<FilmesModel>>>> BuscarFilmePorIdDiretor(int idDiretor)
        {
            var filme = await _filmeInterface.BuscarFilmePorIdDiretor(idDiretor);
            return Ok(filme);  // Retorna os filmes
        }


        [HttpPost("CriarFilme")] // Método para criar um novo filme
        public async Task<ActionResult<ResponseModel<List<FilmesModel>>>> CriarFilme(FilmeCriacaoDto filmeCriacaoDto)
        {
            var filmes = await _filmeInterface.CriarFilme(filmeCriacaoDto); // Chama o serviço para criar um novo filme com base nos dados do DTO
            return Ok(filmes); // Retorna a lista de filmes, incluindo o novo
        }


        [HttpPut("EditarFilme")] // Método para editar um filme existente
        public async Task<ActionResult<ResponseModel<List<FilmesModel>>>> EditarFilme(FilmeEdicaoDto filmeEdicaoDto)
        {
            var filmes = await _filmeInterface.EditarFilme(filmeEdicaoDto); // Chama o serviço para editar o filme com base nos dados fornecidos no DTO
            return Ok(filmes); // Retorna a lista de filmes atualizada
        }


        [HttpDelete("ExcluirFilme")] // Método para excluir um filme pelo ID
        public async Task<ActionResult<ResponseModel<List<FilmesModel>>>> ExcluirFilme(int idFilme)
        {
            var filmes = await _filmeInterface.ExcluirFilme(idFilme);  // Chama o serviço para excluir o filme pelo ID fornecido
            return Ok(filmes); // Retorna a lista de filmes após a exclusão
        }
    }
}
