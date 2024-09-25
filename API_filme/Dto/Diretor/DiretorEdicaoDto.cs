﻿namespace API_filme.Dto.Diretor
{
    // DiretorEdicaoDto é uma classe que serve como um Data Transfer Object (DTO), ou seja, um objeto usado para transferir dados entre a aplicação e a API.
    public class DiretorEdicaoDto // Define uma classe que é um DTO (Data Transfer Object) para a edição de diretores
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
