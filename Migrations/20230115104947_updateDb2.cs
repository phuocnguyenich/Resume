using Microsoft.EntityFrameworkCore.Migrations;

namespace Resume.Migrations
{
    public partial class updateDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "University",
                table: "Resumes");
        }
    }
}
