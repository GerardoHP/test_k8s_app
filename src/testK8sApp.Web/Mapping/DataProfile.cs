using AutoMapper;

namespace testK8sApp.Web.Mapping;

public class DataProfile : Profile
{
    public DataProfile()
    {
        CreateMap<Domain.Author, Dto.AuthorPatch>()
                    .ForMember(src => src.Id, dest => dest.MapFrom(opt => opt.AuthorId))
                    .ReverseMap();
        CreateMap<Domain.Author, Dto.Author>()
            .ForMember(src => src.Id, dest => dest.MapFrom(opt => opt.AuthorId))
            .ReverseMap();
        CreateMap<Domain.Author, Dto.AuthorWithBooks>()
            .ForMember(src => src.Id, dest => dest.MapFrom(opt => opt.AuthorId))
            .ReverseMap();
        CreateMap<Domain.Book, Dto.Book>()
            .ForMember(src => src.Id, dest => dest.MapFrom(opt => opt.AuthorId))
            .ReverseMap();
    }
}