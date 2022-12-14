// <auto-generated />
using System;
using Anubus.Api.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Anubus.Api.Database.Migrations
{
    [DbContext(typeof(AnubusContext))]
    partial class AnubusContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Anubus.Api.Domain.Brs.Br", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<int>("BrType")
                        .HasColumnType("integer");

                    b.Property<long>("OrgSid")
                        .HasColumnType("bigint");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Brs");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.KuDetail.DocKuDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("ApproveDt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("BrSid")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocNum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocStatusName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsFirstDistribution")
                        .HasColumnType("boolean");

                    b.Property<long>("OrgSid")
                        .HasColumnType("bigint");

                    b.Property<long>("TopBrRowSid")
                        .HasColumnType("bigint");

                    b.Property<string>("TopFullSprKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserSid")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("DocKuDetail");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.KuDetail.DocKuDetailRow", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("DocId")
                        .HasColumnType("bigint");

                    b.Property<string>("FullSprKey")
                        .HasColumnType("text");

                    b.Property<long>("Generation")
                        .HasColumnType("bigint");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("SmBa1")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmBa2")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmBa3")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmLbo1")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmLbo2")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmLbo3")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmPof")
                        .HasColumnType("numeric");

                    b.Property<long>("SprId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StructRowId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("SysChangeDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("DocId");

                    b.HasIndex("ParentId");

                    b.ToTable("DocKuDetailRow");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.ToPbs.DocToPbs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("ApproveDt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("BrSid")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocNum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocStatusName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsFirstDistribution")
                        .HasColumnType("boolean");

                    b.Property<long>("OrgSid")
                        .HasColumnType("bigint");

                    b.Property<long>("TopBrRowSid")
                        .HasColumnType("bigint");

                    b.Property<string>("TopFullSprKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserSid")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("DocToPbs");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.ToPbs.DocToPbsRow", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("DocId")
                        .HasColumnType("bigint");

                    b.Property<string>("FullSprKey")
                        .HasColumnType("text");

                    b.Property<long>("Generation")
                        .HasColumnType("bigint");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("SmBa1")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmBa2")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmBa3")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmLbo1")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmLbo2")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmLbo3")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmPof")
                        .HasColumnType("numeric");

                    b.Property<long>("SprId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StructRowId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("SysChangeDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("DocId");

                    b.HasIndex("ParentId");

                    b.ToTable("DocToPbsRow");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.ToRezerv.DocToRezerv", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("ApproveDt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("BrSid")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocNum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocStatusName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsFirstDistribution")
                        .HasColumnType("boolean");

                    b.Property<long>("OrgSid")
                        .HasColumnType("bigint");

                    b.Property<long>("TopBrRowSid")
                        .HasColumnType("bigint");

                    b.Property<string>("TopFullSprKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserSid")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("DocToRezerv");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.ToRezerv.DocToRezervRow", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("DocId")
                        .HasColumnType("bigint");

                    b.Property<string>("FullSprKey")
                        .HasColumnType("text");

                    b.Property<long>("Generation")
                        .HasColumnType("bigint");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("SmBa1")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmBa2")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmBa3")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmLbo1")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmLbo2")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmLbo3")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmPof")
                        .HasColumnType("numeric");

                    b.Property<long>("SprId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StructRowId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("SysChangeDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("DocId");

                    b.HasIndex("ParentId");

                    b.ToTable("DocToRezervRow");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Spr.SprCsr", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("OnDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("SprCsr");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Spr.SprGrbs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("OnDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("SprGrbs");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Spr.SprOuNr", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRezerv")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("OnDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("TgHide")
                        .HasColumnType("boolean");

                    b.Property<int>("TgOrder")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("SprOuNr");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Spr.SprRzPrz", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("OnDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("SprRzPrz");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Spr.SprVr", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("OnDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("SprVr");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.KuDetail.DocKuDetailRow", b =>
                {
                    b.HasOne("Anubus.Api.Domain.Docs.Grbs.KuDetail.DocKuDetail", "Doc")
                        .WithMany("Rows")
                        .HasForeignKey("DocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anubus.Api.Domain.Docs.Grbs.KuDetail.DocKuDetailRow", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Doc");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.ToPbs.DocToPbsRow", b =>
                {
                    b.HasOne("Anubus.Api.Domain.Docs.Grbs.ToPbs.DocToPbs", "Doc")
                        .WithMany("Rows")
                        .HasForeignKey("DocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anubus.Api.Domain.Docs.Grbs.ToPbs.DocToPbsRow", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Doc");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.ToRezerv.DocToRezervRow", b =>
                {
                    b.HasOne("Anubus.Api.Domain.Docs.Grbs.ToRezerv.DocToRezerv", "Doc")
                        .WithMany("Rows")
                        .HasForeignKey("DocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anubus.Api.Domain.Docs.Grbs.ToRezerv.DocToRezervRow", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Doc");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.KuDetail.DocKuDetail", b =>
                {
                    b.Navigation("Rows");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.KuDetail.DocKuDetailRow", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.ToPbs.DocToPbs", b =>
                {
                    b.Navigation("Rows");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.ToPbs.DocToPbsRow", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.ToRezerv.DocToRezerv", b =>
                {
                    b.Navigation("Rows");
                });

            modelBuilder.Entity("Anubus.Api.Domain.Docs.Grbs.ToRezerv.DocToRezervRow", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
