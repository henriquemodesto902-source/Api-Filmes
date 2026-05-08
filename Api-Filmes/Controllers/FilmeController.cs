using Api_Filmes.DTO.DiretorDTO;
using Api_Filmes.DTO.FilmeDTO;
using Api_Filmes.Models;
using Api_Filmes.Services.Diretor;
using Api_Filmes.Services.Filme;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeInterface _filmeInterface;
        public FilmeController(IFilmeInterface filmeInterface)
        {
            _filmeInterface = filmeInterface;
        }

        [HttpGet("ListarFilmes")]

        public async Task<ActionResult<ResponseModel<List<FilmesModel>>>> ListarFilmes()
        {
            var filmes = await _filmeInterface.ListarFilmes();
            return Ok(filmes);
        }

        [HttpGet("BuscarFilmePorId/{idFilme}")]
        public async Task<ActionResult<ResponseModel<DiretorModel>>> BuscarFilmePorId(int idFilme)
        {
            var filme = await _filmeInterface.BuscarFilmesPorId(idFilme);
            return Ok(filme);
        }

        [HttpGet("BuscarFilmePorIdDiretor/{idDiretor}")]
        public async Task<ActionResult<ResponseModel<List<FilmesModel>>>> BuscarFilmePorIdDiretor(int idDiretor)
        {
            var filme = await _filmeInterface.BuscarFilmePorIdDiretor(idDiretor);
            return Ok(filme);
        }

        [HttpPost("CadastrarFilme")]

        public async Task<ActionResult<ResponseModel<FilmesModel>>> CadastrarFilme(FilmeCriaçãoDTO filmeCriaçãoDTO)
        {
            var filme = await _filmeInterface.CadastrarFilme(filmeCriaçãoDTO);
            return Ok(filme);
        }

        [HttpPut("EditarFilme")]
        public async Task<ActionResult<ResponseModel<FilmesModel>>> EditarFilme(FilmeEdiçãoDTO filmeEdiçãoDTO)
        {
            var filme = await _filmeInterface.EditarFilme(filmeEdiçãoDTO);
            return Ok(filme);
        }

        [HttpDelete("RemoverFilme")]

        public async Task<ActionResult<ResponseModel<List<FilmesModel>>>> RemoverFilme(int idFilme)
        {
            var Filme = await _filmeInterface.RemoverFilme(idFilme);
            return Ok(Filme);
        }
    }

   
}
