using Anubus.Api.Domain.Brs;
using Anubus.Api.Domain.Docs.Grbs.KuDetail;
using Anubus.Api.Domain.Docs.Grbs.ToPbs;
using Anubus.Api.Domain.Docs.Grbs.ToRezerv;
using Anubus.Api.Domain.Spr;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Anubus.Api.Db;

//dotnet ef migrations add Intial -c AnubusContext -o Database/Migrations 

public class AnubusContext : DbContext, IGrbsDbContext
{
    public AnubusContext(DbContextOptions<AnubusContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        //AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
                v => v.HasValue ? v.Value.ToUniversalTime() : v,
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (entityType.IsKeyless)
            {
                continue;
            }

            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetValueConverter(dateTimeConverter);
                }
                else if (property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(nullableDateTimeConverter);
                }
            }
        }
    }

    public DbSet<Br> Brs { get; set; } = null!;

    public DbSet<DocKuDetail> GrbsKuDetails { get; set; } = null!;

    public DbSet<DocKuDetailRow> GrbsKuDetailRows { get; set; } = null!;

    public DbSet<DocToRezerv> GrbsToRezerv { get; set; } = null!;

    public DbSet<DocToRezervRow> GrbsToRezervRows { get; set; } = null!;

    public DbSet<DocToPbs> GrbsToPbs { get; set; } = null!;

    public DbSet<DocToPbsRow> GrbsToPbsRows { get; set; } = null!;

    DbSet<DocKuDetail> IGrbsDbContext.KuDetails => this.GrbsKuDetails;

    DbSet<DocKuDetailRow> IGrbsDbContext.KuDetailRows => this.GrbsKuDetailRows;

    DbSet<DocToRezerv> IGrbsDbContext.ToRezerv => this.GrbsToRezerv;

    DbSet<DocToRezervRow> IGrbsDbContext.ToRezervRows => this.GrbsToRezervRows;

    DbSet<DocToPbs> IGrbsDbContext.ToPbs => this.GrbsToPbs;

    DbSet<DocToPbsRow> IGrbsDbContext.ToPbsRows => this.GrbsToPbsRows;




    public DbSet<SprGrbs> SprGrbs { get; set; } = null!;

    public DbSet<SprRzPrz> SprRzPrz { get; set; } = null!;

    public DbSet<SprCsr> SprCsr { get; set; } = null!;

    public DbSet<SprVr> SprVr { get; set; } = null!;

    public DbSet<SprOuNr> SprOuNr { get; set; } = null!;
}
