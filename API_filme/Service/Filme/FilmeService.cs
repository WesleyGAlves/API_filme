using API_filme.Data;
using API_filme.Dto.Diretor;
using API_filme.Dto.Filme;
using API_filme.Models;
using Microsoft.EntityFrameworkCore;

namespace API_filme.Service.Filme
{
    public class FilmeService : IFilmeInterface // Classe que implementa a interface IFilmeInterface
    {
        private readonly AppDbContext _context; // Contexto do banco de dados
        public FilmeService(AppDbContext context) // Construtor que recebe o contexto do banco de dados
        { 
            _context = context;
        }

        public async Task<ResponseModel<FilmesModel>> BuscarFilmePorId(int idFilme) // Método para buscar um filme pelo ID
        {
            ResponseModel<FilmesModel> resposta = new ResponseModel<FilmesModel>();
            try
            {
                var filme = await _context.Filmes.Include(a => a.Diretor).FirstOrDefaultAsync(filmeBanco => filmeBanco.Id == idFilme); // Busca o filme no banco de dados, incluindo o diretor associado

                if (filme == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = filme;
                resposta.Mensagem = "Filme localizado com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FilmesModel>>> BuscarFilmePorIdDiretor(int idDiretor) // Método para buscar filmes por ID do diretor
        {
            ResponseModel<List<FilmesModel>> resposta = new ResponseModel<List<FilmesModel>>();
            try
            {
                var filme = await _context.Filmes.Include(a => a.Diretor).Where(filmeBanco => filmeBanco.Diretor.Id == idDiretor).ToListAsync(); // Busca todos os filmes que pertencem ao diretor especificado

                if (filme == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = filme;
                resposta.Mensagem = "Filme localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FilmesModel>>> CriarFilme(FilmeCriacaoDto filmeCriacaoDto) // Método para criar um novo filme
        {
            ResponseModel<List<FilmesModel>> resposta = new ResponseModel<List<FilmesModel>>();
            try
            {
                var diretor = await _context.Diretores.FirstOrDefaultAsync(diretorBanco => diretorBanco.Id == filmeCriacaoDto.Diretor.Id); // Busca o diretor pelo ID fornecido

                if (diretor == null)
                {
                    resposta.Mensagem = "Nenhum registro de diretor localizado!";
                    return resposta;
                }

                var filme = new FilmesModel() // Cria um novo objeto FilmeModel com os dados fornecidos
                {
                    Titulo = filmeCriacaoDto.Titulo,
                    Diretor = diretor
                };

                // Adiciona o filme ao contexto e salva as mudanças no banco de dados
                _context.Add(filme);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Filmes.Include(a => a.Diretor).ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FilmesModel>>> EditarFilme(FilmeEdicaoDto filmeEdicaoDto) // Método para editar um filme existente
        {
            ResponseModel<List<FilmesModel>> resposta = new ResponseModel<List<FilmesModel>>();
            try
            {
                var filme = await _context.Filmes.Include(a => a.Diretor).FirstOrDefaultAsync(filmeBanco => filmeBanco.Id == filmeEdicaoDto.Id); // Busca o filme pelo ID

                var diretor = await _context.Diretores.FirstOrDefaultAsync(diretorBanco => diretorBanco.Id == filmeEdicaoDto.Diretor.Id); // Busca o diretor pelo ID

                if (diretor == null)
                {
                    resposta.Mensagem = "Nenhum registro de diretor localizado!";
                    return resposta;
                }

                if(filme == null)
                {
                    resposta.Mensagem = "Nenhum registro de filme localizado!";
                    return resposta;
                }

                // Atualiza os dados do filme
                filme.Titulo = filmeEdicaoDto.Titulo;
                filme.Diretor = diretor;

                // Marca o filme como atualizado e salva as mudanças no banco de dados
                _context.Update(filme);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Filmes.ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FilmesModel>>> ExcluirFilme(int idFilme) // Método para excluir um filme
        {
            ResponseModel<List<FilmesModel>> resposta = new ResponseModel<List<FilmesModel>>();
            try
            {
                var filme = await _context.Filmes.Include(a => a.Diretor).FirstOrDefaultAsync(filmeBanco => filmeBanco.Id == idFilme); // Busca o filme pelo ID

                if (filme == null)
                {
                    resposta.Mensagem = "Nenhum filme localizado!";
                    return resposta;
                }

                // Remove o filme do contexto e salva as mudanças no banco de dados
                _context.Remove(filme);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Filmes.ToListAsync();
                resposta.Mensagem = "Filme removido com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FilmesModel>>> ListarFilmes()  // Método para listar todos os filmes
        {
            ResponseModel<List<FilmesModel>> resposta = new ResponseModel<List<FilmesModel>>();
            try
            {
                var filmes = await _context.Filmes.Include(a => a.Diretor).ToListAsync();  // Busca todos os filmes do banco de dados

                resposta.Dados = filmes;
                resposta.Mensagem = "Todos os filmes foram coletados!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}