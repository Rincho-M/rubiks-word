using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RubiksWord.Core.UseCases;
using RubiksWord.Core.Repositories;
using RubiksWord.Data.Contexts;
using RubiksWord.Data.Repositories;
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
app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});
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

        #region seeds
        Cube testCube = new()
        {
            Id = 1,
            Name = "test",
        };
        Point testPoint1 = new()
        {
            Color = "red",
            Position = new(1, 2, 3),
            Orientation = new(0, 1, 2, 3),
            Letters = new string[,] { { "t", "p", "s", "g" }, { "a", "o", "u", "e" }, { "q", "n", "k", "m" }, { "n", "h", "o", "j" }, },
            Cube = testCube,
        };
        Point testPoint2 = new()
        {
            Color = "red",
            Position = new(1, 2, 3),
            Orientation = new(0, 1, 2, 3),
            Letters = new string[,] { { "t", "p", "s", "g" }, { "a", "o", "u", "e" }, { "q", "n", "k", "m" }, { "n", "h", "o", "j" }, },
            Cube = testCube,
        };
        Point testPoint3 = new()
        {
            Color = "red",
            Position = new(1, 2, 3),
            Orientation = new(0, 1, 2, 3),
            Letters = new string[,] { { "t", "p", "s", "g" }, { "a", "o", "u", "e" }, { "q", "n", "k", "m" }, { "n", "h", "o", "j" }, },
            Cube = testCube,
        };
        Point testPoint4 = new()
        {
            Color = "red",
            Position = new(1, 2, 3),
            Orientation = new(0, 1, 2, 3),
            Letters = new string[,] { { "t", "p", "s", "g" }, { "a", "o", "u", "e" }, { "q", "n", "k", "m" }, { "n", "h", "o", "j" }, },
            Cube = testCube,
        };
        Point testPoint5 = new()
        {
            Color = "red",
            Position = new(1, 2, 3),
            Orientation = new(0, 1, 2, 3),
            Letters = new string[,] { { "t", "p", "s", "g" }, { "a", "o", "u", "e" }, { "q", "n", "k", "m" }, { "n", "h", "o", "j" }, },
            Cube = testCube,
        };
        Point testPoint6 = new()
        {
            Color = "red",
            Position = new(1, 2, 3),
            Orientation = new(0, 1, 2, 3),
            Letters = new string[,] { { "t", "p", "s", "g" }, { "a", "o", "u", "e" }, { "q", "n", "k", "m" }, { "n", "h", "o", "j" }, },
            Cube = testCube,
        };
        Point testPoint7 = new()
        {
            Color = "red",
            Position = new(1, 2, 3),
            Orientation = new(0, 1, 2, 3),
            Letters = new string[,] { { "t", "p", "s", "g" }, { "a", "o", "u", "e" }, { "q", "n", "k", "m" }, { "n", "h", "o", "j" }, },
            Cube = testCube,
        };
        Point testPoint8 = new()
        {
            Color = "red",
            Position = new(1, 2, 3),
            Orientation = new(0, 1, 2, 3),
            Letters = new string[,] { { "t", "p", "s", "g" }, { "a", "o", "u", "e" }, { "q", "n", "k", "m" }, { "n", "h", "o", "j" }, },
            Cube = testCube,
        };
        Point testPoint9 = new()
        {
            Color = "red",
            Position = new(1, 2, 3),
            Orientation = new(0, 1, 2, 3),
            Letters = new string[,] { { "t", "p", "s", "g" }, { "a", "o", "u", "e" }, { "q", "n", "k", "m" }, { "n", "h", "o", "j" }, },
            Cube = testCube,
        };
        #endregion
        testCube.Points.Add(testPoint1);
        testCube.Points.Add(testPoint2);
        testCube.Points.Add(testPoint3);
        testCube.Points.Add(testPoint4);
        testCube.Points.Add(testPoint5);
        testCube.Points.Add(testPoint6);
        testCube.Points.Add(testPoint7);
        testCube.Points.Add(testPoint8);
        testCube.Points.Add(testPoint9);
        context.Cubes.Add(testCube);
        context.SaveChanges();
    }
}

app.Run();