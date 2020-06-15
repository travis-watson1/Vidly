using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class AddDataAnnotationToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movies",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movies",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);
        }
    }
}
