using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RubiksWord.Core.UseCases;
using RubiksWord.Core.Repositories;
using RubiksWord.DAL.Contexts;
using RubiksWord.DAL.Repositories;
using RubiksWord.Core.Entities;
using RubiksWord.API.Mappers;
using AutoMapper;
using RubiksWord.API.Extensions;
using System.Text.Json.Serialization;
using System.Collections.Generic;

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

builder.Services.AddScoped<CubeUseCase>();
builder.Services.AddScoped<ICubeRepository, CubeRepository>();
builder.Services.AddAutoMapper(typeof(MainProfile));
builder.Services.AddDbContext<MainContext>(options =>
    options.UseNpgsql(builder.Configuration.GetValue<string>("ConnectionStrings:MainContext")));

// Middlewares.
WebApplication app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseGlobalErrorHandler();
app.UseWebSockets();
app.UseRouting();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.Services
        .GetRequiredService<IMapper>()
        .ConfigurationProvider
        .AssertConfigurationIsValid();

    using (var scope = app.Services.CreateScope())
    {
        MainContext context = scope.ServiceProvider.GetRequiredService<MainContext>();
        context.Database.EnsureDeleted();
        string dbInitScript = context.Database.GenerateCreateScript();
        context.Database.EnsureCreated();

        Cube testCube = new()
        {
            Id = 1,
            Name = "test",
        };
        Point testPoint = new()
        {
            Color = "red",
            Position = new(1, 2, 3),
            Orientation = new(0, 1, 2, 3),
            Letters = new string[,] { { "t", "p", "s" }, { "a", "o", "u" }, { "q", "n", "k" }, },
            Cube = testCube,
            Id = 1
        };
        testCube.Points.Add(testPoint);
        context.Cubes.Add(testCube);

        context.Points.Add(testPoint);
        context.SaveChanges();
    }
}

app.Run();