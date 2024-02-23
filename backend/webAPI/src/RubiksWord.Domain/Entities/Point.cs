using RubiksWord.Domain.DataTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RubiksWord.Domain.Entities;

[Table("point")]
public class Point
{
    [Column("id")]
    public int Id { get; set; }

    [Column("position")]
    public Vector3 Position { get; set; }

    [Column("orientation")]
    public Quaternion Orientation { get; set; }

    [Column("letters")]
    public string[,]? Letters { get; set; }

    [Column("color")]
    [MaxLength(64)]
    public string? Color { get; set; }

    [Column("cube_id")]
    public int CubeId { get; set; }

    public Cube Cube { get; set; }
}
