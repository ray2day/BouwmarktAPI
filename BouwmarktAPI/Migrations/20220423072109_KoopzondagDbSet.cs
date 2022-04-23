using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bouwmarkt_API.Migrations
{
    public partial class KoopzondagDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koopzondag_Vestigingen_VestigingId",
                table: "Koopzondag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Koopzondag",
                table: "Koopzondag");

            migrationBuilder.RenameTable(
                name: "Koopzondag",
                newName: "Koopzondagen");

            migrationBuilder.RenameIndex(
                name: "IX_Koopzondag_VestigingId",
                table: "Koopzondagen",
                newName: "IX_Koopzondagen_VestigingId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumOpeningstijdVan",
                table: "Koopzondagen",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumOpeningstijdTot",
                table: "Koopzondagen",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Koopzondagen",
                table: "Koopzondagen",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Koopzondagen_Vestigingen_VestigingId",
                table: "Koopzondagen",
                column: "VestigingId",
                principalTable: "Vestigingen",
                principalColumn: "VestigingsNummer",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koopzondagen_Vestigingen_VestigingId",
                table: "Koopzondagen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Koopzondagen",
                table: "Koopzondagen");

            migrationBuilder.RenameTable(
                name: "Koopzondagen",
                newName: "Koopzondag");

            migrationBuilder.RenameIndex(
                name: "IX_Koopzondagen_VestigingId",
                table: "Koopzondag",
                newName: "IX_Koopzondag_VestigingId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumOpeningstijdVan",
                table: "Koopzondag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumOpeningstijdTot",
                table: "Koopzondag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Koopzondag",
                table: "Koopzondag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Koopzondag_Vestigingen_VestigingId",
                table: "Koopzondag",
                column: "VestigingId",
                principalTable: "Vestigingen",
                principalColumn: "VestigingsNummer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
