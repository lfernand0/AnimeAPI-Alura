using System.ComponentModel.DataAnnotations;

namespace AnimeAPI.Alura.Data.Dtos;

public class CreateAnimeDto
{
    [Required(ErrorMessage = "O campo Nome é obrigatório!")]
    [StringLength(25, ErrorMessage = "O campo Nome não pode ter mais que 25 caracteres!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Gênero é obrigatório!")]
    [StringLength(25, ErrorMessage = "O campo Gênero não pode ter mais que 25 caracteres!")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O campo Duração é obrigatório!")]
    [Range(5, 40, ErrorMessage = "O campo Duração ser entre 5 e 40 minutos!")]
    public int DuracaoEmMinutos { get; set; }
}