using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using RubiksWord.Core.Entities;
using RubiksWord.Core.DataTypes;
using static RubiksWord.Data.Constants.PgsqlTypeNames;

namespace RubiksWord.Data.Contexts;

public class MainContext : DbContext
{
    public DbSet<Cube> Cubes { get; set; }
    public DbSet<Point> Points { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Point>()
            .HasOne(p => p.Cube)
            .WithMany(c => c.Points)
            .HasForeignKey(p => p.CubeId);
        modelBuilder.Entity<Point>()
            .Property(p => p.Orientation)
            .HasColumnType(Varchar)
            .HasConversion(
                v => v.ToString(),
                v => Quaternion.Parse(v)
            );
        modelBuilder.Entity<Point>()
            .Property(p => p.Position)
            .HasColumnType(Varchar)
            .HasConversion(
                v => v.ToString(),
                v => Vector3.Parse(v)
            );
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Remove(typeof(TableNameFromDbSetConvention));
    }
}
