using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Services.
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

// Middlewares.
app.UseRouting();
app.MapControllers();

app.Run();