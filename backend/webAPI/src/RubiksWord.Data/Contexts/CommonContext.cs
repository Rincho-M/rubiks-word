using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using RubiksWord.Domain.Entities;
using RubiksWord.Domain.DataTypes;
using static RubiksWord.Data.Constants.PgsqlTypeNames;

namespace RubiksWord.Data.Contexts;

public class CommonContext : DbContext
{
    public DbSet<Cube> Cubes { get; set; }
    public DbSet<Point> Points { get; set; }

    public CommonContext(DbContextOptions<CommonContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Cube>()
            .ToTable(nameof(Cube).ToLower())
            .HasKey(c => c.Id);
        builder.Entity<Cube>()
            .Property(c => c.Name)
            .HasMaxLength(128)
            .IsRequired();

        builder.Entity<Point>()
            .ToTable(nameof(Point).ToLower())
            .HasOne(p => p.Cube)
            .WithMany(c => c.Points)
            .HasForeignKey(p => p.CubeId);
        builder.Entity<Point>()
            .Property(p => p.Orientation)
            .HasColumnType(Varchar)
            .HasConversion(
                v => v.ToString(),
                v => Quaternion.Parse(v)
            );
        builder.Entity<Point>()
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
