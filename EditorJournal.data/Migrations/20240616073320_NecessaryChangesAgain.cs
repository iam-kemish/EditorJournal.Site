using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EditorJournal.data.Migrations
{
    /// <inheritdoc />
    public partial class NecessaryChangesAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CellNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellNumber",
                table: "AspNetUsers");
        }
    }
}
