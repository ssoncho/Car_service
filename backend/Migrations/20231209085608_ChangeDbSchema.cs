using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarServiceWebConsole.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDbSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPositions_Materials_MaterialId",
                table: "MaterialPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPositions_Products_ProductId",
                table: "ProductPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerParticipations_Services_ServiceId",
                table: "WorkerParticipations");

            migrationBuilder.DropTable(
                name: "MaterialPrices");

            migrationBuilder.DropTable(
                name: "ProductPrices");

            migrationBuilder.DropTable(
                name: "ServicePrices");

            migrationBuilder.DropIndex(
                name: "IX_WorkerParticipations_ServiceId",
                table: "WorkerParticipations");

            migrationBuilder.DropIndex(
                name: "IX_ProductPositions_ProductId",
                table: "ProductPositions");

            migrationBuilder.DropIndex(
                name: "IX_MaterialPositions_MaterialId",
                table: "MaterialPositions");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "WorkerParticipations");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductPositions",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "MaterialPositions",
                newName: "Price");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Services",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductPositions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Materials",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MaterialPositions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Vin",
                table: "Cars",
                type: "char(17)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(17)",
                oldMaxLength: 17);

            migrationBuilder.AlterColumn<string>(
                name: "StateNumber",
                table: "Cars",
                type: "char(9)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(9)",
                oldMaxLength: 9);

            migrationBuilder.CreateTable(
                name: "ServicePositions",
                columns: table => new
                {
                    WorkerParticipationId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePositions", x => x.WorkerParticipationId);
                    table.ForeignKey(
                        name: "FK_ServicePositions_WorkerParticipations_WorkerParticipationId",
                        column: x => x.WorkerParticipationId,
                        principalTable: "WorkerParticipations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicePositions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductPositions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MaterialPositions");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ProductPositions",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "MaterialPositions",
                newName: "MaterialId");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "WorkerParticipations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Vin",
                table: "Cars",
                type: "character varying(17)",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(17)");

            migrationBuilder.AlterColumn<string>(
                name: "StateNumber",
                table: "Cars",
                type: "character varying(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(9)");

            migrationBuilder.CreateTable(
                name: "MaterialPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MaterialId = table.Column<int>(type: "integer", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialPrices_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePrices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkerParticipations_ServiceId",
                table: "WorkerParticipations",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPositions_ProductId",
                table: "ProductPositions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPositions_MaterialId",
                table: "MaterialPositions",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPrices_MaterialId",
                table: "MaterialPrices",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductId",
                table: "ProductPrices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePrices_ServiceId",
                table: "ServicePrices",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPositions_Materials_MaterialId",
                table: "MaterialPositions",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPositions_Products_ProductId",
                table: "ProductPositions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerParticipations_Services_ServiceId",
                table: "WorkerParticipations",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
