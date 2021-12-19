using AutoMapper;

namespace AnimeCollection.API.Profiles
{
    public class AnimeProfile : Profile
    {
        public AnimeProfile()
        {
            CreateMap<DAL.Entities.Anime, Models.Anime>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src =>
                   $"{src.Title} {src.OriginalTitle}"));

            CreateMap<DAL.Entities.Anime, Models.Anime>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src =>
                   $"{src.Author.Name} {src.Author.OriginalName}"));
        }
    }
}
