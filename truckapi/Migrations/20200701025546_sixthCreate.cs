using Microsoft.EntityFrameworkCore.Migrations;

namespace truckapi.Migrations
{
    public partial class sixthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reciver_Address_Addressid",
                table: "Reciver");

            migrationBuilder.RenameColumn(
                name: "Addressid",
                table: "Reciver",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Reciver_Addressid",
                table: "Reciver",
                newName: "IX_Reciver_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reciver_Address_AddressId",
                table: "Reciver",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reciver_Address_AddressId",
                table: "Reciver");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Reciver",
                newName: "Addressid");

            migrationBuilder.RenameIndex(
                name: "IX_Reciver_AddressId",
                table: "Reciver",
                newName: "IX_Reciver_Addressid");

            migrationBuilder.AddForeignKey(
                name: "FK_Reciver_Address_Addressid",
                table: "Reciver",
                column: "Addressid",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
