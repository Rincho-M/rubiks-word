using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RubiksWord.Domain.UseCases;
using RubiksWord.Domain.Repositories;
using RubiksWord.Data.Contexts;
using RubiksWord.Data.Repositories;
using RubiksWord.API.Mappers;
using RubiksWord.API.Extensions;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using RubiksWord.API.Hubs;
using MessagePack;
using MessagePack.Resolvers;
using AutoMapper;
using RubiksWord.Domain.Seeds;

// Services.
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        IList<JsonConverter> converters = options.JsonSerializerOptions.Converters;
        converters.Add(new Vector3JsonConverter());
        converters.Add(new QuaternionJsonConverter());
    });
builder.Services.AddSwaggerGen();
builder.Services
    .AddSignalR()
    .AddMessagePackProtocol(options =>
    {
        options.SerializerOptions = MessagePackSerializerOptions.Standard
            .WithSecurity(MessagePackSecurity.UntrustedData)
            .WithResolver(ContractlessStandardResolver.Instance);
    });

builder.Services.AddScoped<CubeUseCases>();
builder.Services.AddScoped<ICubeRepository, CubeRepository>();
builder.Services.AddAutoMapper(typeof(CommonProfile));
builder.Services.AddDbContext<CommonContext>(options =>
    options.UseNpgsql(builder.Configuration.GetValue<string>("ConnectionStrings:CommonContext")));
builder.Services.AddValidators();

// Middlewares.
WebApplication app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder
        .WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});
app.UseGlobalErrorHandler();
app.UseRouting();

// Endpoints.
app.MapControllers();
app.MapHub<CubeHub>("/hubs/cube");

// Dev environment preparations.
if (app.Environment.IsDevelopment())
{
    app.Services
        .GetRequiredService<IMapper>()
        .ConfigurationProvider
        .AssertConfigurationIsValid();

    using (var scope = app.Services.CreateScope())
    {
        CommonContext context = scope.ServiceProvider.GetRequiredService<CommonContext>();
        context.Database.EnsureDeleted();
        string dbInitScript = context.Database.GenerateCreateScript();
        context.Database.EnsureCreated();

        CubeUseCases cubeUseCase = scope.ServiceProvider.GetRequiredService<CubeUseCases>();
        await cubeUseCase.Create(DevSeedData.GetTestCube());
    }
}

app.Run();