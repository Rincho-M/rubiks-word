namespace RubiksWord.API.DTO;

public record FaceDTO
{
    public int CubeId { get; set; }

    public string? CubeName { get; set; }

    public PointDTO[][]? Points { get; set; }
}
