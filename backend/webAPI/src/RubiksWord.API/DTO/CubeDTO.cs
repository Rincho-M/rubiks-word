using System.Collections.Generic;

namespace RubiksWord.API.DTO;

public class CubeDTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public IEnumerable<PointDTO>? Points { get; set; }
}
