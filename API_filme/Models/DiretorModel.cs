using System.Text.Json.Serialization;

namespace API_filme.Models
{
    public class DiretorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        /* JsonIgnore ira ignorar a coleção de filmes */
        [JsonIgnore]
        public ICollection<FilmesModel> Filmes { get; set; }    /* Criação de uma coleção de filmes */
    }
}
