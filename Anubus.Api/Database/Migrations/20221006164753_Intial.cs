using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Anubus.Api.Database.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrType = table.Column<int>(type: "integer", nullable: false),
                    OrgSid = table.Column<long>(type: "bigint", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocKuDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocNum = table.Column<string>(type: "text", nullable: false),
                    ApproveDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocStatus = table.Column<string>(type: "text", nullable: false),
                    DocStatusName = table.Column<string>(type: "text", nullable: false),
                    Descr = table.Column<string>(type: "text", nullable: false),
                    UserSid = table.Column<long>(type: "bigint", nullable: false),
                    OrgSid = table.Column<long>(type: "bigint", nullable: false),
                    BrSid = table.Column<long>(type: "bigint", nullable: false),
                    TopBrRowSid = table.Column<long>(type: "bigint", nullable: false),
                    TopFullSprKey = table.Column<string>(type: "text", nullable: false),
                    IsFirstDistribution = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocKuDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocToPbs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocNum = table.Column<string>(type: "text", nullable: false),
                    ApproveDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocStatus = table.Column<string>(type: "text", nullable: false),
                    DocStatusName = table.Column<string>(type: "text", nullable: false),
                    Descr = table.Column<string>(type: "text", nullable: false),
                    UserSid = table.Column<long>(type: "bigint", nullable: false),
                    OrgSid = table.Column<long>(type: "bigint", nullable: false),
                    BrSid = table.Column<long>(type: "bigint", nullable: false),
                    TopBrRowSid = table.Column<long>(type: "bigint", nullable: false),
                    TopFullSprKey = table.Column<string>(type: "text", nullable: false),
                    IsFirstDistribution = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocToPbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocToRezerv",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocNum = table.Column<string>(type: "text", nullable: false),
                    ApproveDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocStatus = table.Column<string>(type: "text", nullable: false),
                    DocStatusName = table.Column<string>(type: "text", nullable: false),
                    Descr = table.Column<string>(type: "text", nullable: false),
                    UserSid = table.Column<long>(type: "bigint", nullable: false),
                    OrgSid = table.Column<long>(type: "bigint", nullable: false),
                    BrSid = table.Column<long>(type: "bigint", nullable: false),
                    TopBrRowSid = table.Column<long>(type: "bigint", nullable: false),
                    TopFullSprKey = table.Column<string>(type: "text", nullable: false),
                    IsFirstDistribution = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocToRezerv", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SprCsr",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    OnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ToDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprCsr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SprGrbs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    OnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ToDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprGrbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SprOuNr",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TgHide = table.Column<bool>(type: "boolean", nullable: false),
                    TgOrder = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    OnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ToDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsRezerv = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprOuNr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SprRzPrz",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    OnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ToDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprRzPrz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SprVr",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    OnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ToDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprVr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocKuDetailRow",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocId = table.Column<long>(type: "bigint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    StructRowId = table.Column<long>(type: "bigint", nullable: true),
                    FullSprKey = table.Column<string>(type: "text", nullable: true),
                    SprId = table.Column<long>(type: "bigint", nullable: false),
                    SmBa1 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmBa2 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmBa3 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmLbo1 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmLbo2 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmLbo3 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmPof = table.Column<decimal>(type: "numeric", nullable: false),
                    SysChangeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Generation = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocKuDetailRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocKuDetailRow_DocKuDetail_DocId",
                        column: x => x.DocId,
                        principalTable: "DocKuDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocKuDetailRow_DocKuDetailRow_ParentId",
                        column: x => x.ParentId,
                        principalTable: "DocKuDetailRow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocToPbsRow",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocId = table.Column<long>(type: "bigint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    StructRowId = table.Column<long>(type: "bigint", nullable: true),
                    FullSprKey = table.Column<string>(type: "text", nullable: true),
                    SprId = table.Column<long>(type: "bigint", nullable: false),
                    SmBa1 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmBa2 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmBa3 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmLbo1 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmLbo2 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmLbo3 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmPof = table.Column<decimal>(type: "numeric", nullable: false),
                    SysChangeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Generation = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocToPbsRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocToPbsRow_DocToPbs_DocId",
                        column: x => x.DocId,
                        principalTable: "DocToPbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocToPbsRow_DocToPbsRow_ParentId",
                        column: x => x.ParentId,
                        principalTable: "DocToPbsRow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocToRezervRow",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocId = table.Column<long>(type: "bigint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    StructRowId = table.Column<long>(type: "bigint", nullable: true),
                    FullSprKey = table.Column<string>(type: "text", nullable: true),
                    SprId = table.Column<long>(type: "bigint", nullable: false),
                    SmBa1 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmBa2 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmBa3 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmLbo1 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmLbo2 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmLbo3 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmPof = table.Column<decimal>(type: "numeric", nullable: false),
                    SysChangeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Generation = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocToRezervRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocToRezervRow_DocToRezerv_DocId",
                        column: x => x.DocId,
                        principalTable: "DocToRezerv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocToRezervRow_DocToRezervRow_ParentId",
                        column: x => x.ParentId,
                        principalTable: "DocToRezervRow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocKuDetailRow_DocId",
                table: "DocKuDetailRow",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_DocKuDetailRow_ParentId",
                table: "DocKuDetailRow",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocToPbsRow_DocId",
                table: "DocToPbsRow",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_DocToPbsRow_ParentId",
                table: "DocToPbsRow",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocToRezervRow_DocId",
                table: "DocToRezervRow",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_DocToRezervRow_ParentId",
                table: "DocToRezervRow",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brs");

            migrationBuilder.DropTable(
                name: "DocKuDetailRow");

            migrationBuilder.DropTable(
                name: "DocToPbsRow");

            migrationBuilder.DropTable(
                name: "DocToRezervRow");

            migrationBuilder.DropTable(
                name: "SprCsr");

            migrationBuilder.DropTable(
                name: "SprGrbs");

            migrationBuilder.DropTable(
                name: "SprOuNr");

            migrationBuilder.DropTable(
                name: "SprRzPrz");

            migrationBuilder.DropTable(
                name: "SprVr");

            migrationBuilder.DropTable(
                name: "DocKuDetail");

            migrationBuilder.DropTable(
                name: "DocToPbs");

            migrationBuilder.DropTable(
                name: "DocToRezerv");
        }
    }
}
