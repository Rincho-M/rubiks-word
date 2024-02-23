using AutoMapper;
using RubiksWord.API.DTO;
using RubiksWord.Domain.Entities;

namespace RubiksWord.API.Mappers;

public class CommonProfile : Profile
{
    private const string _cubePrefix = "Cube";

    public CommonProfile()
    {
        RecognizeDestinationPrefixes(_cubePrefix);

        CreateMap<Cube, CubeDTO>()
            .ForMember(
                dest => dest.Points, 
                options => options.MapFrom<ThreeDimentionalToJaggedPointsArrayResolver>());

        CreateMap<CubeDTO, FaceDTO>()
            .ForMember(
                dest => dest.Points,
                options => options.MapFrom<JaggedToSlicePointsArrayResolver>());

        CreateMap<Point, PointDTO>();

        CreateMap<string[,], string[][]>()
            .ConvertUsing<JaggedStringArrayTypeConverter>();
    }
}

public class JaggedToSlicePointsArrayResolver : IValueResolver<CubeDTO, FaceDTO, PointDTO[][]?>
{
    public PointDTO[][]? Resolve(CubeDTO src, FaceDTO dest, PointDTO[][]? destMember, ResolutionContext context)
    {
        if (src.Points is null) return null;

        destMember = new PointDTO[src.Points.Length - 2][];
        for (int i = 1; i < src.Points.Length - 1; i++)
        {
            destMember[i - 1] = new PointDTO[src.Points.Length - 2];
            for (int k = 1; k < src.Points.Length - 1; k++)
            {
                destMember[i - 1][k - 1] = src.Points[src.Points.Length - 1][i][k];
            }
        }
        return destMember;
    }
}

public class ThreeDimentionalToJaggedPointsArrayResolver : IValueResolver<Cube, CubeDTO, PointDTO[][][]?>
{
    public PointDTO[][][]? Resolve(Cube src, CubeDTO dest, PointDTO[][][]? destMember, ResolutionContext context)
    {
        if (src.Points is null) return null;

        destMember = new PointDTO[src.SideLength][][];
        for (int i = 0; i < destMember.Length; i++)
        {
            destMember[i] = new PointDTO[src.SideLength][];
            for (int k = 0; k < src.SideLength; k++)
            {
                destMember[i][k] = new PointDTO[src.SideLength];
            }
        }
        foreach (Point point in src.Points)
        {
            destMember[point.Position.X][point.Position.Y][point.Position.Z] = context.Mapper.Map<PointDTO>(point);
        }
        return destMember;
    }
}