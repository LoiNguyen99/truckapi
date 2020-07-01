using Microsoft.EntityFrameworkCore.Migrations;

namespace truckapi.Migrations
{
    public partial class fourthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_ShippingInf_CommodityOwnerId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_ShippingInf_ReciverId",
                table: "Request");

            migrationBuilder.DropTable(
                name: "ShippingInf");

            migrationBuilder.CreateTable(
                name: "CommodityOwner",
                columns: table => new
                {
                    CommodityOwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityOwner", x => x.CommodityOwnerId);
                    table.ForeignKey(
                        name: "FK_CommodityOwner_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reciver",
                columns: table => new
                {
                    ReciverId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reciver", x => x.ReciverId);
                    table.ForeignKey(
                        name: "FK_Reciver_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommodityOwner_AddressId",
                table: "CommodityOwner",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Reciver_AddressId",
                table: "Reciver",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_CommodityOwner_CommodityOwnerId",
                table: "Request",
                column: "CommodityOwnerId",
                principalTable: "CommodityOwner",
                principalColumn: "CommodityOwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Reciver_ReciverId",
                table: "Request",
                column: "ReciverId",
                principalTable: "Reciver",
                principalColumn: "ReciverId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_CommodityOwner_CommodityOwnerId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Reciver_ReciverId",
                table: "Request");

            migrationBuilder.DropTable(
                name: "CommodityOwner");

            migrationBuilder.DropTable(
                name: "Reciver");

            migrationBuilder.CreateTable(
                name: "ShippingInf",
                columns: table => new
                {
                    ShippingInfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
