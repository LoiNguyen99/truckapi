using Microsoft.EntityFrameworkCore.Migrations;

namespace truckapi.Migrations
{
    public partial class thirthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommodityOwnerId",
                table: "Request",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Request",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReciverId",
                table: "Request",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_Place_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingInf",
                columns: table => new
                {
                    ShippingInfId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingInf", x => x.ShippingInfId);
                    table.ForeignKey(
                        name: "FK_ShippingInf_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Request_CommodityOwnerId",
                table: "Request",
                column: "CommodityOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ReciverId",
                table: "Request",
                column: "ReciverId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_AddressId",
                table: "Place",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingInf_AddressId",
                table: "ShippingInf",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_ShippingInf_CommodityOwnerId",
                table: "Request",
                column: "CommodityOwnerId",
                principalTable: "ShippingInf",
                principalColumn: "ShippingInfId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_ShippingInf_ReciverId",
                table: "Request",
                column: "ReciverId",
                principalTable: "ShippingInf",
                principalColumn: "ShippingInfId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_ShippingInf_CommodityOwnerId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_ShippingInf_ReciverId",
                table: "Request");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "ShippingInf");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Request_CommodityOwnerId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_ReciverId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "CommodityOwnerId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "ReciverId",
                table: "Request");
        }
    }
}
