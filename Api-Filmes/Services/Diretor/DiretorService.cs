using Api_Filmes.Data;
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

        public Task<ResponseModel<DiretorModel>> BuscarDiretorPorId(int idDiretor)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<DiretorModel>> BuscarDiretorPorIdFilme(int idFilme)
        {
            throw new NotImplementedException();
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
    }
}
