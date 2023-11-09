using AutoMapper;

namespace testK8sApp.Web.Mapping;

public class DataProfile : Profile
{
    public DataProfile()
    {
        CreateMap<Domain.Author, Dto.Author>().ReverseMap();
        CreateMap<Domain.Author, Dto.AuthorWithBooks>().ReverseMap();
        CreateMap<Domain.Book, Dto.Book>().ReverseMap();
    }
}