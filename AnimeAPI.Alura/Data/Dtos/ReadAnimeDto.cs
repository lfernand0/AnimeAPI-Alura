namespace AnimeAPI.Alura.Data.Dtos;

public class ReadAnimeDto
{
    public string Nome { get; set; }
    public string Genero { get; set; }
    public int DuracaoEmMinutos { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}