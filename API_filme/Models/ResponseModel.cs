namespace API_filme.Models
{
    public class ResponseModel<T> // Modelo genérico usado para encapsular a resposta da API. Ela pode ser usada para qualquer tipo de dado,
                                  // fornecendo um formato consistente que contém:
    {
        public T? Dados { get; set; } /* Pode ser nulo */
        public string Mensagem {  get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
