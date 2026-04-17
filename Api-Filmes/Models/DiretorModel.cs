using System.Text.Json.Serialization;

namespace Api_Filmes.Models
{
    public class DiretorModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public string Nacionalidade { get; set; }
        [JsonIgnore]
        public ICollection<FilmesModel> Filmes { get; set; }







    }
}
