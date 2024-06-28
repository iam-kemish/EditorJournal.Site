using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EditorJournal.data.Migrations
{
    /// <inheritdoc />
    public partial class changesMadeToModelAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellNumber",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CellNumber",
                table: "OrderHeaders",
                newName: "PhoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "OrderHeaders",
                newName: "CellNumber");

            migrationBuilder.AddColumn<string>(
                name: "CellNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
