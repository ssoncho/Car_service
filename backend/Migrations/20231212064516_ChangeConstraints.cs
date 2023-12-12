using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceWebConsole.Migrations
{
    /// <inheritdoc />
    public partial class ChangeConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "Orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "StateNumber",
                table: "Cars",
                type: "varchar(9)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(9)");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PhoneNumber",
                table: "Customers",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TelegramAlias",
                table: "Customers",
                column: "TelegramAlias",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_VkAlias",
                table: "Customers",
                column: "VkAlias",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_StateNumber",
                table: "Cars",
                column: "StateNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Vin",
                table: "Cars",
                column: "Vin",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_PhoneNumber",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TelegramAlias",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_VkAlias",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Cars_StateNumber",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_Vin",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StateNumber",
                table: "Cars",
                type: "char(9)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(9)");
        }
    }
}
