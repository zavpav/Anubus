using Anubus.Api.Domain.Brs;
using Anubus.Api.Domain.Docs.Grbs.KuDetail;
using Anubus.Api.Domain.Docs.Grbs.ToPbs;
using Anubus.Api.Domain.Docs.Grbs.ToRezerv;
using Anubus.Api.Domain.Spr;

namespace Anubus.Api.Db;

//dotnet ef migrations add Intial -c AnubusContext -o Database/Migrations 

public class AnubusContext : DbContext, IGrbsDbContext
{
    public AnubusContext(DbContextOptions<AnubusContext> options) : base(options)
    {
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
