using RubiksWord.Core.Entities;
using RubiksWord.Core.Repositories;

namespace RubiksWord.Core.UseCases;

public class CubeUseCase
{
    private readonly ICubeRepository _cubeRepo;

    public CubeUseCase(ICubeRepository cubeRepo)
    {
        _cubeRepo = cubeRepo;
    }

    public async Task<Cube> GetByName(string name)
    {
        return await _cubeRepo.GetByName(name);
    }
}
