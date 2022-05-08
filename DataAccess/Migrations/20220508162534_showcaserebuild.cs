using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class showcaserebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url1",
                table: "ShowCases");

            migrationBuilder.DropColumn(
                name: "Url2",
                table: "ShowCases");

            migrationBuilder.DropColumn(
                name: "Url3",
                table: "ShowCases");

            migrationBuilder.DropColumn(
                name: "Url4",
                table: "ShowCases");

            migrationBuilder.RenameColumn(
                name: "Url5",
                table: "ShowCases",
                newName: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "ShowCases",
                newName: "Url5");

            migrationBuilder.AddColumn<string>(
                name: "Url1",
                table: "ShowCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url2",
                table: "ShowCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url3",
                table: "ShowCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url4",
                table: "ShowCases",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
