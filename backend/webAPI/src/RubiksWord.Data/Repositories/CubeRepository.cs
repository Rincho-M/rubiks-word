using RubiksWord.Core.Entities;
using RubiksWord.Core.Repositories;
using RubiksWord.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace RubiksWord.Data.Repositories;

public class CubeRepository : ICubeRepository
{
    private MainContext _mainContext;

    public CubeRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
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
