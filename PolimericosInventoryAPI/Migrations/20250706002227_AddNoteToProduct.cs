using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PolimericosInventoryAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNoteToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Products",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Products");
        }
    }
}
