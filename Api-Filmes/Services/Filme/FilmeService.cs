using Api_Filmes.Data;
using Api_Filmes.DTO.DiretorDTO;
using Api_Filmes.DTO.FilmeDTO;
using Api_Filmes.DTO.Vinculo;
using Api_Filmes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Api_Filmes.Services.Filme
{
    public class FilmeService : IFilmeInterface
    {    
        private readonly AppDBContext _context;

        public FilmeService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<FilmesModel>>> BuscarFilmePorIdDiretor(int idDiretor)
        {
            ResponseModel<List<FilmesModel>> response = new ResponseModel<List<FilmesModel>>();
            try
            {
                var filme = await _context.Filmes.Include(d => d.Diretor).Where
                    (filmebanco => filmebanco.Diretor.Id != null && filmebanco.Diretor.Id == idDiretor)
                    .ToListAsync();

                if (filme == null)
                {
                    response.Mensagem = "Nenhum filme encontrado para o diretor especificado.";
                    response.Status = false;
                    return response;
                }
                {
                    response.Dados = filme;
                    response.Mensagem = "Filmes encontrados com sucesso.";
                    response.Status = true;
                    return response;
                }



            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }


        public async Task<ResponseModel<FilmesModel>> BuscarFilmesPorId(int idfilme)
        {
            ResponseModel<FilmesModel> response = new ResponseModel<FilmesModel>();
            try
            {

                var filmes = await _context.Filmes.Include(d => d.Diretor).FirstOrDefaultAsync(filmebanco => filmebanco.Id == idfilme);

                if (filmes == null)
                {
                    response.Mensagem = "Filme não encontrado.";
                    return response;
                }

                response.Dados = filmes;
                response.Mensagem = "Filme encontrado com sucesso.";
                return response;



            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<FilmesModel>> CadastrarFilme(FilmeCriaçãoDTO filmeCriaçãoDTO)
        {
            ResponseModel<FilmesModel> response = new ResponseModel<FilmesModel>();

            try
            {
                var novoFilme = new FilmesModel
                {
                    Titulo = filmeCriaçãoDTO.Titulo,
                    Genero = filmeCriaçãoDTO.Genero,
                    Ano = filmeCriaçãoDTO.Ano,
                    Sinopse = filmeCriaçãoDTO.Sinopse,
                    Duração = filmeCriaçãoDTO.Duração,
                    Avaliação = filmeCriaçãoDTO.Avaliação,
                    
                };

                if (filmeCriaçãoDTO.Diretor.Id > 0)

                novoFilme.Diretor = await _context.Diretores.FirstOrDefaultAsync(diretorbanco => diretorbanco.Id == filmeCriaçãoDTO.Diretor.Id);

                else
                {
                    var novoDiretor = new DiretorModel
                    {
                        Nome = filmeCriaçãoDTO.Diretor.Nome,
                        Sobrenome = filmeCriaçãoDTO.Diretor.Sobrenome,
                        Nascimento = filmeCriaçãoDTO.Diretor.Nascimento,
                        Nacionalidade = filmeCriaçãoDTO.Diretor.Nacionalidade
                    };
                    _context.Diretores.Add(novoDiretor);
                    await _context.SaveChangesAsync();

                    response.Dados = novoFilme;
                    response.Mensagem = "Diretor cadastrado com sucesso.";

                }



                    _context.Filmes.Add(novoFilme);
                await _context.SaveChangesAsync();

                response.Dados = novoFilme;
                response.Mensagem = "Filme cadastrado com sucesso.";
            } 
                        catch (Exception ex)
            {
                response.Mensagem = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                response.Status = false;
                
            }

            return response;
        }

        public async Task<ResponseModel<List<FilmesModel>>> EditarFilme(FilmeEdiçãoDTO filmeEdiçãoDTO)
        {
            ResponseModel<List<FilmesModel>> response = new ResponseModel<List<FilmesModel>>();
            try
            {
                var filme = await _context.Filmes.Include(d => d.Diretor).FirstOrDefaultAsync(filmebanco => filmebanco.Id == filmeEdiçãoDTO.Id);


                if (filme == null)
                {
                    response.Mensagem = "Nenhum resgistro de filme encontrado.";
                    return response;
                }


                filme.Titulo = filmeEdiçãoDTO.Titulo;
                filme.Genero = filmeEdiçãoDTO.Genero;
                filme.Ano = filmeEdiçãoDTO.Ano;
                filme.Sinopse = filmeEdiçãoDTO.Sinopse;
                filme.Duração = filmeEdiçãoDTO.Duração;
                filme.Avaliação = filmeEdiçãoDTO.Avaliação;

                if (filme.Diretor != null)
                {
                    filme.Diretor.Nome = filmeEdiçãoDTO.Diretor.Nome;
                    filme.Diretor.Sobrenome = filmeEdiçãoDTO.Diretor.Sobrenome;
                    filme.Diretor.Nascimento = filmeEdiçãoDTO.Diretor.Nascimento;
                    filme.Diretor.Nacionalidade = filmeEdiçãoDTO.Diretor.Nacionalidade;
                }




                _context.Update(filme);
                await _context.SaveChangesAsync();

                response.Mensagem = "Dados editados com sucesso.";
                return response;

            }
            catch (Exception ex)

            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;

            }
        }

        public async Task<ResponseModel<List<FilmesModel>>> ListarFilmes()
        {
            ResponseModel<List<FilmesModel>> response = new ResponseModel<List<FilmesModel>>();
            try
            {

                var filmes = await _context.Filmes.Include(d => d.Diretor).ToListAsync();

                response.Dados = filmes;
                response.Mensagem = "Filmes listados com sucesso.";

                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;

            }
        }

        public async Task<ResponseModel<List<FilmesModel>>> RemoverFilme(int idfilme)
        {
            ResponseModel<List<FilmesModel>> response = new ResponseModel<List<FilmesModel>>();
            try
            {
                var filme = await _context.Filmes.FirstOrDefaultAsync(filmebanco => filmebanco.Id == idfilme);

                if (filme == null)
                {
                    response.Mensagem = "Filme não encontrado.";
                    return response;
                }

                _context.Filmes.Remove(filme);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Filmes.ToListAsync();
                response.Mensagem = "Filme removido com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;

            }
        }




    }
}
