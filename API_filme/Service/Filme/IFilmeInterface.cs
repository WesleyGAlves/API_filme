using API_filme.Dto.Diretor;
using API_filme.Dto.Filme;
using API_filme.Models;

namespace API_filme.Service.Filme
{
    public interface IFilmeInterface
    {
        Task<ResponseModel<List<FilmesModel>>> ListarFilmes(); // Método para listar todos os filmes
        Task<ResponseModel<FilmesModel>> BuscarFilmePorId(int idFilme); // Método para buscar um filme pelo seu ID
        Task<ResponseModel<List<FilmesModel>>> BuscarFilmePorIdDiretor(int idDiretor); // Método para buscar filmes associados a um diretor pelo ID do diretor
        Task<ResponseModel<List<FilmesModel>>> CriarFilme(FilmeCriacaoDto filmeCriacaoDto); // Método para criar um novo filme com base no DTO de criação
        Task<ResponseModel<List<FilmesModel>>> EditarFilme(FilmeEdicaoDto filmeEdicaoDto); // Método para editar um filme existente com base no DTO de edição
        Task<ResponseModel<List<FilmesModel>>> ExcluirFilme(int idFilme); // Método para excluir um filme pelo seu ID
    }
}
