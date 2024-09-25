using API_filme.Models;
using Microsoft.EntityFrameworkCore;

namespace API_filme.Data
{
    public class AppDbContext : DbContext // Define a classe AppDbContext, que representa o contexto de banco de dados
    {

        // Construtor que recebe as opções de configuração do contexto e passa essas opções para a classe base (DbContext)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {        
        }

        // Representa a tabela de Diretores no banco de dados, onde cada instância de DiretorModel será uma linha na tabela
        public DbSet<DiretorModel> Diretores { get; set; }

        // Representa a tabela de Filmes no banco de dados, onde cada instância de FilmesModel será uma linha na tabela
        public DbSet<FilmesModel> Filmes { get; set; }
    }
}
