using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace truckapi.Migrations
{
    public partial class _1stCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
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
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommodityOwner",
                columns: table => new
                {
                    CommodityOwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityOwner", x => x.CommodityOwnerId);
                    table.ForeignKey(
                        name: "FK_CommodityOwner_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommodityOwner_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
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
                    IsDefault = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reciver", x => x.ReciverId);
                    table.ForeignKey(
                        name: "FK_Reciver_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reciver_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityOwnerId = table.Column<int>(nullable: false),
                    ReciverId = table.Column<int>(nullable: false),
                    CommodityName = table.Column<string>(nullable: true),
                    Weight = table.Column<float>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    ValidDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    DriverId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Request_CommodityOwner_CommodityOwnerId",
                        column: x => x.CommodityOwnerId,
                        principalTable: "CommodityOwner",
                        principalColumn: "CommodityOwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Reciver_ReciverId",
                        column: x => x.ReciverId,
                        principalTable: "Reciver",
                        principalColumn: "ReciverId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Request_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quotation",
                columns: table => new
                {
                    QuotationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DriverId = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotation", x => x.QuotationId);
                    table.ForeignKey(
                        name: "FK_Quotation_User_DriverId",
                        column: x => x.DriverId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotation_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "Color", "Value" },
                values: new object[,]
                {
                    { 1, "0xffffeb3b", "Chờ báo giá" },
                    { 2, "0xff2196f3", "Đang vận chuyển" },
                    { 3, "0xff66bb6a", "Hoàn thành" },
                    { 4, "0xfff44336", "Đã hủy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommodityOwner_AddressId",
                table: "CommodityOwner",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CommodityOwner_UserId",
                table: "CommodityOwner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_AddressId",
                table: "Place",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_DriverId",
                table: "Quotation",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_RequestId",
                table: "Quotation",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Reciver_AddressId",
                table: "Reciver",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Reciver_UserId",
                table: "Reciver",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_CommodityOwnerId",
                table: "Request",
                column: "CommodityOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ReciverId",
                table: "Request",
                column: "ReciverId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_StatusId",
                table: "Request",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_UserId",
                table: "Request",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "Quotation");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "CommodityOwner");

            migrationBuilder.DropTable(
                name: "Reciver");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
