using Api_Filmes.DTO.DiretorDTO;
using Api_Filmes.DTO.FilmeDTO;
using Api_Filmes.Models;

namespace Api_Filmes.Services.Filme
{
    public interface IFilmeInterface
    {
        Task<ResponseModel<List<FilmesModel>>> ListarFilmes();
        Task<ResponseModel<FilmesModel>> BuscarFilmesPorId(int idfilme);
        Task<ResponseModel<List<FilmesModel>>> BuscarFilmePorIdDiretor(int idDiretor);
        Task<ResponseModel<FilmesModel>> CadastrarFilme(FilmeCriaçãoDTO filmeCriaçãoDTO);

        Task<ResponseModel<List<FilmesModel>>> EditarFilme(FilmeEdiçãoDTO filmeEdiçãoDTO);

        Task<ResponseModel<List<FilmesModel>>> RemoverFilme(int idfilme);
    }
}
