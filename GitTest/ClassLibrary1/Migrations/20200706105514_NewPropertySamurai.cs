using Microsoft.EntityFrameworkCore.Migrations;

namespace EFSamurai.Data.Migrations
{
    public partial class NewPropertySamurai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HairStyle",
                table: "Samurais",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HairStyle",
                table: "Samurais");
        }
    }
}
