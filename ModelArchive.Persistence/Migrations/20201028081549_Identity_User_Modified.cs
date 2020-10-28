using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelArchive.Persistence.Migrations
{
    public partial class Identity_User_Modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultLanguage",
                schema: "Security",
                table: "AspNetUsers",
                maxLength: 30,
                nullable: false,
                defaultValue: "en-US");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultLanguage",
                schema: "Security",
                table: "AspNetUsers");
        }
    }
}
