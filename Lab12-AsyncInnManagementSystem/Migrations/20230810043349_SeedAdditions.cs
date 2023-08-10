using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab12_AsyncInnManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdditions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "HotelRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "HotelRoom",
                keyColumn: "ID",
                keyValue: 1,
                column: "RoomNumber",
                value: 101);

            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "ID", "HotelID", "Price", "RoomID", "RoomNumber" },
                values: new object[,]
                {
                    { 2, 1, 149.99000000000001, 2, 201 },
                    { 3, 2, 69.989999999999995, 1, 102 },
                    { 4, 2, 169.99000000000001, 3, 301 },
                    { 5, 3, 99.989999999999995, 2, 202 },
                    { 6, 3, 159.99000000000001, 3, 302 }
                });

            migrationBuilder.InsertData(
                table: "RoomAmenity",
                columns: new[] { "ID", "AmenityID", "RoomID" },
                values: new object[,]
                {
                    { 3, 2, 2 },
                    { 4, 3, 3 },
                    { 5, 3, 1 },
                    { 6, 4, 3 },
                    { 7, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenity_AmenityID",
                table: "RoomAmenity",
                column: "AmenityID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenity_RoomID",
                table: "RoomAmenity",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_HotelID",
                table: "HotelRoom",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_RoomID",
                table: "HotelRoom",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Hotel_HotelID",
                table: "HotelRoom",
                column: "HotelID",
                principalTable: "Hotel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Room_RoomID",
                table: "HotelRoom",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenity_Amenity_AmenityID",
                table: "RoomAmenity",
                column: "AmenityID",
                principalTable: "Amenity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenity_Room_RoomID",
                table: "RoomAmenity",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Hotel_HotelID",
                table: "HotelRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Room_RoomID",
                table: "HotelRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenity_Amenity_AmenityID",
                table: "RoomAmenity");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenity_Room_RoomID",
                table: "RoomAmenity");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenity_AmenityID",
                table: "RoomAmenity");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenity_RoomID",
                table: "RoomAmenity");

            migrationBuilder.DropIndex(
                name: "IX_HotelRoom_HotelID",
                table: "HotelRoom");

            migrationBuilder.DropIndex(
                name: "IX_HotelRoom_RoomID",
                table: "HotelRoom");

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RoomAmenity",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomAmenity",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomAmenity",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoomAmenity",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RoomAmenity",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "HotelRoom");
        }
    }
}
