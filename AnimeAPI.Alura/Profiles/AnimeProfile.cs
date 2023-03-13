using AnimeAPI.Alura.Data.Dtos;
using AnimeAPI.Alura.Models;
using AutoMapper;

namespace AnimeAPI.Alura.Profiles;

public class AnimeProfile : Profile
{
	public AnimeProfile()
	{
		CreateMap<CreateAnimeDto, Anime>(); 
		CreateMap<UpdateAnimeDto, Anime>(); 
		CreateMap<Anime, UpdateAnimeDto>(); 
		CreateMap<Anime, ReadAnimeDto>(); 
	}
}
