using FluentValidation;
using RubiksWord.Domain.Entities;

namespace RubiksWord.Domain.Validators;

public class CubeValidator : AbstractValidator<Cube>
{
    public CubeValidator()
    {
        RuleFor(cube => cube.SideLength)
            .GreaterThan(0)
            .WithMessage("Cube side must be more than 0.");
        RuleFor(cube => cube.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Cube name mustn't be null and empty.");
    }
}
