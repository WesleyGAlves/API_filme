using API_filme.Dto.Vinculo;
using API_filme.Models;

namespace API_filme.Dto.Filme
{
    // FilmeCriacaoDto é uma classe Data Transfer Object (DTO) usada para transferir dados ao criar um novo filme.

    public class FilmeCriacaoDto  // Define uma classe que é um DTO (Data Transfer Object) para a criação de filmes
    {
        public string Titulo { get; set; }
        public DiretorVinculoDto Diretor { get; set; }
    }
}
