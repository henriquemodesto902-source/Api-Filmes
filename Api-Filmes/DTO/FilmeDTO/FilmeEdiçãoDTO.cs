using Api_Filmes.DTO.Vinculo;
using Api_Filmes.Models;

namespace Api_Filmes.DTO.FilmeDTO
{
    public class FilmeEdiçãoDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Ano { get; set; }
        public string Sinopse { get; set; }
        public string Duração { get; set; }
        public double Avaliação { get; set; }

        public VinculoDTO Diretor { get; set; }
    }
}
