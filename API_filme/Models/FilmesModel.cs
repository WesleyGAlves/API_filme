namespace API_filme.Models
{
    public class FilmesModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DiretorModel Diretor { get; set; }  // Propriedade que representa o diretor do filme, usando outro modelo (DiretorModel)
    }
}
