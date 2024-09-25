namespace API_filme.Dto.Vinculo
{
    /* 
    Agrupa os DTOs de vínculo, facilitando a organização e a manutenção do código, e evita conflitos de nome com outros DTOs ou classes.
    DiretorVinculoDto é uma classe Data Transfer Object (DTO) que representa os dados de um diretor que será vinculado a outro objeto, como um filme.
    */

    public class DiretorVinculoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
