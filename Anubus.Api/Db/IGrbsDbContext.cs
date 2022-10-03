using Anubus.Api.Domain.Brs;
using Anubus.Api.Domain.Docs.Grbs.KuDetail;
using Anubus.Api.Domain.Docs.Grbs.ToPbs;
using Anubus.Api.Domain.Docs.Grbs.ToRezerv;
using Anubus.Api.Domain.Spr;

namespace Anubus.Api.Db;

public interface IGrbsDbContext: IDisposable
{
    DbSet<Br> Brs { get; }

    DbSet<DocKuDetail> KuDetails { get; }

    DbSet<DocKuDetailRow> KuDetailRows { get; }

    DbSet<DocToRezerv> ToRezerv { get; }

    DbSet<DocToRezervRow> ToRezervRows { get; }

    DbSet<DocToPbs> ToPbs { get; }

    DbSet<DocToPbsRow> ToPbsRows { get; }

    DbSet<SprGrbs> SprGrbs { get; }

    DbSet<SprRzPrz> SprRzPrz { get; }

    DbSet<SprCsr> SprCsr { get; }

    DbSet<SprVr> SprVr { get; }

    DbSet<SprOuNr> SprOuNr { get; }

}
