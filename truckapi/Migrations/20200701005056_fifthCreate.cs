using Microsoft.EntityFrameworkCore.Migrations;

namespace truckapi.Migrations
{
    public partial class fifthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommodityOwners_Address_AddressId",
                table: "CommodityOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_CommodityOwners_CommodityOwnerId",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommodityOwners",
                table: "CommodityOwners");

            migrationBuilder.RenameTable(
                name: "CommodityOwners",
                newName: "CommodityOwner");

            migrationBuilder.RenameIndex(
                name: "IX_CommodityOwners_AddressId",
                table: "CommodityOwner",
                newName: "IX_CommodityOwner_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommodityOwner",
                table: "CommodityOwner",
                column: "CommodityOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommodityOwner_Address_AddressId",
                table: "CommodityOwner",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_CommodityOwner_CommodityOwnerId",
                table: "Request",
                column: "CommodityOwnerId",
                principalTable: "CommodityOwner",
                principalColumn: "CommodityOwnerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommodityOwner_Address_AddressId",
                table: "CommodityOwner");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_CommodityOwner_CommodityOwnerId",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommodityOwner",
                table: "CommodityOwner");

            migrationBuilder.RenameTable(
                name: "CommodityOwner",
                newName: "CommodityOwners");

            migrationBuilder.RenameIndex(
                name: "IX_CommodityOwner_AddressId",
                table: "CommodityOwners",
                newName: "IX_CommodityOwners_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommodityOwners",
                table: "CommodityOwners",
                column: "CommodityOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommodityOwners_Address_AddressId",
                table: "CommodityOwners",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_CommodityOwners_CommodityOwnerId",
                table: "Request",
                column: "CommodityOwnerId",
                principalTable: "CommodityOwners",
                principalColumn: "CommodityOwnerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
