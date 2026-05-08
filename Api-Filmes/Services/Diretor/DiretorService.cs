using Api_Filmes.Data;
using Api_Filmes.DTO.DiretorDTO;
using Api_Filmes.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Filmes.Services.Diretor
{
    public class DiretorService : DiretorInterface
    {
        private readonly AppDBContext _context;
        public DiretorService(AppDBContext context)
        { 
            _context = context;
        }

        public async Task<ResponseModel<DiretorModel>> BuscarDiretorPorId(int idDiretor)
        {

            ResponseModel<DiretorModel> response = new ResponseModel<DiretorModel>();
            try
            {

                var diretor = await _context.Diretores.FirstOrDefaultAsync(diretorbanco => diretorbanco.Id == idDiretor );

                if(diretor == null)
                {
                    response.Mensagem = "Diretor não encontrado.";
                    return response;
                }
             
                response.Dados = diretor;
                response.Mensagem = "Diretor encontrado com sucesso.";
                return response;



            } catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<DiretorModel>> BuscarDiretorPorIdFilme(int idFilme)
        {
            ResponseModel<DiretorModel> response = new ResponseModel<DiretorModel>();
            try
            {
               var filme = await _context.Filmes.Include(d => d.Diretor).FirstOrDefaultAsync(filmeBanco => filmeBanco.Id == idFilme);

                if (filme == null)
                {
                    response.Mensagem = "Nenhum registro encontrado.";
                    return response;
                }
                response.Dados = filme.Diretor;
                response.Mensagem = "Diretor encontrado com sucesso.";
                return response;


            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;

            }
        }


        public async Task<ResponseModel<DiretorModel>> CadastrarDiretor(DiretorCriaçãoDTO diretorCriaçãoDTO)
        {
            ResponseModel<DiretorModel> response = new ResponseModel<DiretorModel>();

            try
            {
                var diretor
                    = new DiretorModel

                {
                    
                    Nome = diretorCriaçãoDTO.Nome,
                    Sobrenome = diretorCriaçãoDTO.Sobrenome,
                    Nascimento = diretorCriaçãoDTO.Nascimento,
                    Nacionalidade = diretorCriaçãoDTO.Nacionalidade
                };

                _context.Diretores.Add(diretor);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Diretores.FindAsync(diretor.Id);
                response.Mensagem = "Diretor cadastrado com sucesso.";
                return response;




            } catch (Exception ex)
            {
                response.Mensagem = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                response.Status = false;
                return response;
            }
           


        }

        public async Task<ResponseModel<List<DiretorModel>>> EditarDiretor(DiretorEdiçãoDTO diretorEdiçãoDTO)
        {
            ResponseModel<List<DiretorModel>> response = new ResponseModel<List<DiretorModel>>();
            try
            {
                var diretor = await _context.Diretores.FirstOrDefaultAsync(diretorBanco => diretorBanco.Id == diretorEdiçãoDTO.Id);

                if (diretor == null)
                {
                    response.Mensagem = "Diretor não encontrado.";
                    response.Status = false;

                    return response;

                }

                diretor.Nome = diretorEdiçãoDTO.Nome;
                diretor.Sobrenome = diretorEdiçãoDTO.Sobrenome;
                diretor.Nascimento = diretorEdiçãoDTO.Nascimento;
                diretor.Nacionalidade = diretorEdiçãoDTO.Nacionalidade;

                _context.Diretores.Update(diretor);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Diretores.ToListAsync();
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

        public async Task<ResponseModel<List<DiretorModel>>> ListarDiretores()
        {
            ResponseModel<List<DiretorModel>> response = new ResponseModel<List<DiretorModel>>();
            try
            {

                var diretores = await _context.Diretores.ToListAsync();

                response.Dados = diretores;
                response.Mensagem = "Diretores listados com sucesso."; 

                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;

            }
        }

        public async Task<ResponseModel<List<DiretorModel>>> RemoverDiretor(int idDiretor)
        {
            ResponseModel<List<DiretorModel>> response = new ResponseModel<List<DiretorModel>>();
            try
            {
                var diretor = await _context.Diretores.FirstOrDefaultAsync(diretorBanco => diretorBanco.Id == idDiretor);

                if (diretor == null)
                {
                    response.Mensagem = "Diretor não encontrado.";
                    response.Status = false;
                    return response;
                    
                }

                _context.Diretores.Remove(diretor);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Diretores.ToListAsync();
                response.Mensagem = "Diretor removido com sucesso.";
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
