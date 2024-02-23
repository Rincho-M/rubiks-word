namespace RubiksWord.API.DTO;

public record RotateFullDTO
{
    public int CubeId { get; init; }
    public int Axis { get; init; }
    public int Direction { get; init; }
}
