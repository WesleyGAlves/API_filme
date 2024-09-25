namespace API_filme.Dto.Diretor
{
    // DiretorCriacaoDto é uma classe que serve como um Data Transfer Object (DTO), ou seja, um objeto usado para transferir dados entre a aplicação e a API.
    
    public class DiretorCriacaoDto // Define uma classe que é um DTO (Data Transfer Object) para a criação de diretores
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
