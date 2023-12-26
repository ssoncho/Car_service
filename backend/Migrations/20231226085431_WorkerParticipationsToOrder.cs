using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceWebConsole.Migrations
{
    /// <inheritdoc />
    public partial class WorkerParticipationsToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerParticipations_Records_RecordId",
                table: "WorkerParticipations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerParticipations_Workers_WorkerId",
                table: "WorkerParticipations");

            migrationBuilder.RenameColumn(
                name: "RecordId",
                table: "WorkerParticipations",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerParticipations_RecordId",
                table: "WorkerParticipations",
                newName: "IX_WorkerParticipations_OrderId");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "WorkerParticipations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerParticipations_Orders_OrderId",
                table: "WorkerParticipations",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerParticipations_Workers_WorkerId",
                table: "WorkerParticipations",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "MobileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerParticipations_Orders_OrderId",
                table: "WorkerParticipations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerParticipations_Workers_WorkerId",
                table: "WorkerParticipations");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "WorkerParticipations",
                newName: "RecordId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerParticipations_OrderId",
                table: "WorkerParticipations",
                newName: "IX_WorkerParticipations_RecordId");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "WorkerParticipations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerParticipations_Records_RecordId",
                table: "WorkerParticipations",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerParticipations_Workers_WorkerId",
                table: "WorkerParticipations",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "MobileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
