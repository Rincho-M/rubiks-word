using RubiksWord.Core.Entities;

namespace RubiksWord.Core.Repositories;

public interface ICubeRepository
{
    Task<Cube> GetByName(string cubeName);
}
