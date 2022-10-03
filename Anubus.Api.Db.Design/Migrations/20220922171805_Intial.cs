using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Anubus.Api.Migrations
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
                name: "KuDetails",
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
                    table.PrimaryKey("PK_KuDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToPbs",
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
                    table.PrimaryKey("PK_ToPbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToRezerv",
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
                    table.PrimaryKey("PK_ToRezerv", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KuDetailRows",
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
                    table.PrimaryKey("PK_KuDetailRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KuDetailRows_KuDetailRows_ParentId",
                        column: x => x.ParentId,
                        principalTable: "KuDetailRows",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KuDetailRows_KuDetails_DocId",
                        column: x => x.DocId,
                        principalTable: "KuDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToPbsRows",
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
                    table.PrimaryKey("PK_ToPbsRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToPbsRows_ToPbs_DocId",
                        column: x => x.DocId,
                        principalTable: "ToPbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToPbsRows_ToPbsRows_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ToPbsRows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ToRezervRows",
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
                    table.PrimaryKey("PK_ToRezervRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToRezervRows_ToRezerv_DocId",
                        column: x => x.DocId,
                        principalTable: "ToRezerv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToRezervRows_ToRezervRows_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ToRezervRows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KuDetailRows_DocId",
                table: "KuDetailRows",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_KuDetailRows_ParentId",
                table: "KuDetailRows",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ToPbsRows_DocId",
                table: "ToPbsRows",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_ToPbsRows_ParentId",
                table: "ToPbsRows",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ToRezervRows_DocId",
                table: "ToRezervRows",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_ToRezervRows_ParentId",
                table: "ToRezervRows",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brs");

            migrationBuilder.DropTable(
                name: "KuDetailRows");

            migrationBuilder.DropTable(
                name: "ToPbsRows");

            migrationBuilder.DropTable(
                name: "ToRezervRows");

            migrationBuilder.DropTable(
                name: "KuDetails");

            migrationBuilder.DropTable(
                name: "ToPbs");

            migrationBuilder.DropTable(
                name: "ToRezerv");
        }
    }
}
