using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EditorJournal.dataSet.Migrations
{
    /// <inheritdoc />
    public partial class ChangesAppliedInItemModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Genre", "ImageUrl" },
                values: new object[] { "Thriller", "hhtps//:Image1234" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 27, 17, 27, 32, 3, DateTimeKind.Local).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 27, 17, 27, 32, 3, DateTimeKind.Local).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 27, 17, 27, 32, 3, DateTimeKind.Local).AddTicks(8488));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 27, 17, 27, 32, 3, DateTimeKind.Local).AddTicks(8489));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Genre", "ImageUrl" },
                values: new object[] { "", "" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "AuthorEmail", "AuthorName", "Description", "Genre", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "ProductId", "Title" },
                values: new object[,]
                {
                    { 2, "author2@example.com", "Author 2", "Description for Item 2", "", "", 60.0, 45.0, 35.0, 40.0, 1, "Item 2" },
                    { 3, "author3@example.com", "Author 3", "Description for Item 3", "", "", 70.0, 50.0, 40.0, 45.0, 1, "Item 3" },
                    { 4, "author4@example.com", "Author 4", "Description for Item 4", "", "", 80.0, 55.0, 45.0, 50.0, 2, "Item 4" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 27, 14, 49, 29, 190, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 27, 14, 49, 29, 190, DateTimeKind.Local).AddTicks(3865));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 27, 14, 49, 29, 190, DateTimeKind.Local).AddTicks(3868));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 27, 14, 49, 29, 190, DateTimeKind.Local).AddTicks(3869));
        }
    }
}
