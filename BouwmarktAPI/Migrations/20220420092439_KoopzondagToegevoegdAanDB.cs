using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bouwmarkt_API.Migrations
{
    public partial class KoopzondagToegevoegdAanDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Koopzondag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumOpeningstijdVan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumOpeningstijdTot = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VestigingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Koopzondag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Koopzondag_Vestigingen_VestigingId",
                        column: x => x.VestigingId,
                        principalTable: "Vestigingen",
                        principalColumn: "VestigingsNummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Koopzondag_VestigingId",
                table: "Koopzondag",
                column: "VestigingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Koopzondag");
        }
    }
}
