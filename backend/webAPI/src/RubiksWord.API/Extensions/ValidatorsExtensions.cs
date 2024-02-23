using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RubiksWord.Domain.Entities;
using RubiksWord.Domain.Validators;

namespace RubiksWord.API.Extensions;

public static class ValidatorsExtensions
{
    public static IServiceCollection AddValidators(
        this IServiceCollection services)
    {
        services.AddScoped<IValidator<Cube>, CubeValidator>();
        return services;
    }
}
