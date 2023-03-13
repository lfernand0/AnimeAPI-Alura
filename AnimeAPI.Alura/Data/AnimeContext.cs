using AnimeAPI.Alura.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeAPI.Alura.Data;

public class AnimeContext : DbContext
{
    public AnimeContext(DbContextOptions<AnimeContext> options) : base(options)
    {

    }

    public DbSet<Anime> Animes { get; set; }
}