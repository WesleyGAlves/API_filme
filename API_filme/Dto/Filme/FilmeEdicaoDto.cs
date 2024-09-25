using API_filme.Dto.Vinculo;
using API_filme.Models;

namespace API_filme.Dto.Filme
{
    // FilmeEdicaoDto é uma classe Data Transfer Object (DTO) usada para transferir dados ao criar um novo filme.

    public class FilmeEdicaoDto // Define uma classe que é um DTO (Data Transfer Object) para a edição de filmes
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DiretorVinculoDto Diretor { get; set; }
    }
}
