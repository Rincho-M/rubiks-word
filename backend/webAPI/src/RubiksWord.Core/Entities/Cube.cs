using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RubiksWord.Core.Entities;

[Table("cube")]
public class Cube
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [MaxLength(128)]
    public string? Name { get; set; }

    public ICollection<Point> Points { get; set; } = new List<Point>();
}
