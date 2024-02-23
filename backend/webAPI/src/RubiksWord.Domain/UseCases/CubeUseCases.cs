using FluentValidation;
using FluentValidation.Results;
using RubiksWord.Domain.Entities;
using RubiksWord.Domain.Repositories;

namespace RubiksWord.Domain.UseCases;

public class CubeUseCases
{
    private readonly ICubeRepository _cubeRepo;
    private readonly IValidator<Cube> _cubeValidator;

    public CubeUseCases(
        ICubeRepository cubeRepo,
        IValidator<Cube> cubeValidator)
    {
        _cubeRepo = cubeRepo;
        _cubeValidator = cubeValidator;
    }

    public async Task<Cube> GetByName(string name)
    {
        return await _cubeRepo.GetByName(name);
    }

    public async Task<Cube> Create(Cube cube)
    {
        ValidationResult result = await _cubeValidator.ValidateAsync(cube);
        if(!result.IsValid) 
        {
            throw new ValidationException(result.Errors);
        }

        return await _cubeRepo.Create(cube);
    }

    public async Task<Cube> RotateFull(int cubeId, int axis, int direction)
    {
        // Get cube by id from cache/db
        Cube cube = await _cubeRepo.GetById(cubeId);

        // Rotate cube
        //cube.Points;

        // Update cache
        return cube;
    }
}
