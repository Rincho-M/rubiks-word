using RubiksWord.Core.DataTypes;

namespace RubiksWord.API.DTO;

public class PointDTO
{
    public int Id { get; set; }

    public Vector3 Position { get; set; }

    public Quaternion Orientation { get; set; }

    public string[][]? Letters { get; set; }

    public string? Color { get; set; }
}
