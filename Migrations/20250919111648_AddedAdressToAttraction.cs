using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdressToAttraction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Attractions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Attractions");
        }
    }
}
