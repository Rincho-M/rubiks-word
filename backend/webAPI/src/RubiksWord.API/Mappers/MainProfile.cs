using AutoMapper;
using RubiksWord.API.DTO;
using RubiksWord.Core.Entities;

namespace RubiksWord.API.Mappers;

public class MainProfile : Profile
{
    public MainProfile()
    {
        CreateMap<Cube, CubeDTO>();
        CreateMap<Point, PointDTO>();
        CreateMap<string[,], string[][]>()
            .ConvertUsing<JaggedStringArrayTypeConverter>();
    }
}
