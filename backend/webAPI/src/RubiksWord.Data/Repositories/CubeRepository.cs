using RubiksWord.Domain.Entities;
using RubiksWord.Domain.Repositories;
using RubiksWord.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace RubiksWord.Data.Repositories;

public class CubeRepository : ICubeRepository
{
    private CommonContext _mainContext;

    public CubeRepository(CommonContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<Cube> Create(Cube cube)
    {
        _mainContext.Cubes.Add(cube);
        await _mainContext.SaveChangesAsync();

        return await GetByName(cube.Name!);
    }

    public async Task<Cube> GetById(int id)
    {
        return await _mainContext.Cubes
            .Where(c => c.Id == id)
            .Include(c => c.Points)
            .AsNoTracking()
            .SingleAsync();
    }

    public async Task<Cube> GetByName(string cubeName)
    {
        return await _mainContext.Cubes
            .Where(c => c.Name == cubeName)
            .Include(c => c.Points)
            .AsNoTracking()
            .SingleAsync();
    }
}
