namespace Api_Filmes.Models
{
    public class FilmesModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Gênero { get; set; }
        public int Ano { get; set; }
        public string Sinopse { get; set; }
        public string Duração { get; set; }
        public string Classificação { get; set; }   
        public double Avaliação { get; set; }

        public DiretorModel Diretor { get; set; }







    }
}
