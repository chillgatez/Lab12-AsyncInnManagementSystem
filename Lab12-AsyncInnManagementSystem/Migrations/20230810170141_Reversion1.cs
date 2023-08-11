using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab12_AsyncInnManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Reversion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Amenity_AmenityID",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_AmenityID",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "AmenityID",
                table: "Room");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmenityID",
                table: "Room",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 1,
                column: "AmenityID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 2,
                column: "AmenityID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 3,
                column: "AmenityID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Room_AmenityID",
                table: "Room",
                column: "AmenityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Amenity_AmenityID",
                table: "Room",
                column: "AmenityID",
                principalTable: "Amenity",
                principalColumn: "ID");
        }
    }
}
