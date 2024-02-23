using RubiksWord.Domain.Entities;

namespace RubiksWord.Domain.Repositories;

public interface ICubeRepository
{
    Task<Cube> GetByName(string cubeName);
    Task<Cube> Create(Cube cube);
    Task<Cube> GetById(int id);
}
