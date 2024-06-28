using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EditorJournal.data.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_companies_CompanyID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_AspNetUsers_AppUserId",
                table: "shoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_Items_ItemId",
                table: "shoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shoppingCarts",
                table: "shoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companies",
                table: "companies");

            migrationBuilder.RenameTable(
                name: "shoppingCarts",
                newName: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "companies",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCarts_ItemId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCarts_AppUserId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDeu = table.Column<DateOnly>(type: "date", nullable: false),
                    paymentIntentDeu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ItemId",
                table: "OrderDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_AppUserId",
                table: "OrderHeaders",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyID",
                table: "AspNetUsers",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_AppUserId",
                table: "ShoppingCarts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Items_ItemId",
                table: "ShoppingCarts",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_AppUserId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Items_ItemId",
                table: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "shoppingCarts");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "companies");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_ItemId",
                table: "shoppingCarts",
                newName: "IX_shoppingCarts_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_AppUserId",
                table: "shoppingCarts",
                newName: "IX_shoppingCarts_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shoppingCarts",
                table: "shoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companies",
                table: "companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_companies_CompanyID",
                table: "AspNetUsers",
                column: "CompanyID",
                principalTable: "companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_AspNetUsers_AppUserId",
                table: "shoppingCarts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_Items_ItemId",
                table: "shoppingCarts",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
