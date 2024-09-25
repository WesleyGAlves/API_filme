using API_filme.Data;
using API_filme.Dto.Diretor;
using API_filme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API_filme.Service.Diretor
{
    // Implementa a interface IDiretorInterface, definindo as operações que lidam com dados do Diretor
    public class DiretorService : IDiretorInterface
    {
        // Instância de AppDbContext usada para interagir com o banco de dados
        private readonly AppDbContext _context;

        // Construtor que injeta o contexto de banco de dados
        public DiretorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<DiretorModel>> BuscarDiretorPorId(int idDiretor)  // Método para buscar diretor por ID
        {
            ResponseModel<DiretorModel> resposta = new ResponseModel<DiretorModel>();
            try
            { 
                var diretor = await _context.Diretores.FirstOrDefaultAsync(diretorBanco => diretorBanco.Id == idDiretor); // Busca o diretor no banco de dados com base no ID

                if (diretor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = diretor;
                resposta.Mensagem = "Autor localizado!";

                return resposta;

            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<DiretorModel>> BuscarDiretorPorIdFilme(int idFilme) // Método para buscar diretor associado a um filme pelo ID do filme
        {
            ResponseModel<DiretorModel> resposta = new ResponseModel<DiretorModel>();
            try
            {
                var filme = await _context.Filmes.Include(a => a.Diretor).FirstOrDefaultAsync(filmeBanco => filmeBanco.Id == idFilme); // Inclui o diretor relacionado ao filme na busca

                if (filme == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = filme.Diretor;
                resposta.Mensagem = "Diretor localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<DiretorModel>>> CriarDiretor(DiretorCriacaoDto diretorCriacaoDto) // Método para criar um novo diretor
        {
            ResponseModel<List<DiretorModel>> resposta = new ResponseModel<List<DiretorModel>>();

            try
            {
                var diretor = new DiretorModel()  // Cria um novo objeto de diretor a partir do DTO de criação
                {
                    Nome = diretorCriacaoDto.Nome,
                    Sobrenome = diretorCriacaoDto.Sobrenome
                };

                // Adiciona o novo diretor no contexto do banco e salva as mudanças
                _context.Add(diretor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Diretores.ToListAsync();
                resposta.Mensagem = "Diretor criado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<DiretorModel>>> EditarDiretor(DiretorEdicaoDto diretorEdicaoDto)  // Método para editar um diretor existente
        {
            ResponseModel<List<DiretorModel>> resposta = new ResponseModel<List<DiretorModel>>();
            try
            {
                var diretor = await _context.Diretores.FirstOrDefaultAsync(diretorBanco => diretorBanco.Id == diretorEdicaoDto.Id); // Busca o diretor pelo ID fornecido no DTO de edição
                if (diretor == null)
                {
                    resposta.Mensagem = "Nenhum diretor localizado!";
                    return resposta;
                }

                // Atualiza as informações do diretor
                diretor.Nome = diretorEdicaoDto.Nome;
                diretor.Sobrenome = diretorEdicaoDto.Sobrenome;

                // Atualiza o diretor no banco e salva as mudanças
                _context.Update(diretor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Diretores.ToListAsync();
                resposta.Mensagem = "Diretor editado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<DiretorModel>>> ExcluirDiretor(int idDiretor) // Método para excluir um diretor pelo ID
        {
            ResponseModel<List<DiretorModel>> resposta = new ResponseModel<List<DiretorModel>>();
            try
            {
                var diretor = await _context.Diretores.FirstOrDefaultAsync(diretorBanco => diretorBanco.Id == idDiretor); // Busca o diretor pelo ID

                if (diretor == null)
                {
                    resposta.Mensagem = "Nenhum diretor localizado!";
                    return resposta;
                }

                // Remove o diretor do banco de dados e salva as mudanças
                _context.Remove(diretor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Diretores.ToListAsync();
                resposta.Mensagem = "Diretor removido com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<DiretorModel>>> ListarDiretores() // Método para listar todos os diretores
        {
            ResponseModel<List<DiretorModel>> resposta = new ResponseModel<List<DiretorModel>>();
            try
            {
                var diretores = await _context.Diretores.ToListAsync(); // Recupera todos os diretores do banco de dados

                resposta.Dados = diretores;
                resposta.Mensagem = "Todos os diretores foram coletados!";

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
    