using API_filme.Dto.Diretor;
using API_filme.Models;

namespace API_filme.Service.Diretor
{
    public interface IDiretorInterface
    {
        Task<ResponseModel<List<DiretorModel>>> ListarDiretores();  // Método para listar todos os diretores
        Task<ResponseModel<DiretorModel>> BuscarDiretorPorId(int idDiretor); // Método para buscar um diretor pelo seu ID
        Task<ResponseModel<DiretorModel>> BuscarDiretorPorIdFilme(int idFilme); // Método para buscar um diretor associado a um filme pelo ID do filme
        Task<ResponseModel<List<DiretorModel>>> CriarDiretor(DiretorCriacaoDto diretorCriacaoDto); // Método para criar um novo diretor com base no DTO de criação
        Task<ResponseModel<List<DiretorModel>>> EditarDiretor(DiretorEdicaoDto diretorEdicaoDto); // Método para editar um diretor existente com base no DTO de edição
        Task<ResponseModel<List<DiretorModel>>> ExcluirDiretor(int idDiretor); // Método para excluir um diretor pelo seu ID
    }
}
