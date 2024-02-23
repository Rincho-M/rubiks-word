using RubiksWord.Domain.DataTypes;

namespace RubiksWord.API.DTO;

public class PointDTO
{
    public int Id { get; set; }

    public Quaternion Orientation { get; set; }

    public string[][]? Letters { get; set; }

    public string? Color { get; set; }
}
