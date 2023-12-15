using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarServiceWebConsole.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOneToOneRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Orders_OrderId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePositions_WorkerParticipations_WorkerParticipationId",
                table: "ServicePositions");

            migrationBuilder.RenameColumn(
                name: "WorkerParticipationId",
                table: "ServicePositions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Records",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "WorkerParticipations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WorkerParticipations",
                newName: "ServicePositionId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ServicePositions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Records",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RecordId",
                table: "Orders",
                column: "RecordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Records_RecordId",
                table: "Orders",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerParticipations_ServicePositions_ServicePositionId",
                table: "WorkerParticipations",
                column: "ServicePositionId",
                principalTable: "ServicePositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Records_RecordId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerParticipations_ServicePositions_ServicePositionId",
                table: "WorkerParticipations");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RecordId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ServicePositionId",
                table: "WorkerParticipations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ServicePositions",
                newName: "WorkerParticipationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Records",
                newName: "OrderId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "WorkerParticipations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "WorkerParticipationId",
                table: "ServicePositions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Records",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Orders_OrderId",
                table: "Records",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePositions_WorkerParticipations_WorkerParticipationId",
                table: "ServicePositions",
                column: "WorkerParticipationId",
                principalTable: "WorkerParticipations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
