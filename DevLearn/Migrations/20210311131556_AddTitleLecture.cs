using Microsoft.EntityFrameworkCore.Migrations;

namespace TestsData.Migrations
{
    public partial class AddTitleLecture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LectureTitle",
                table: "Lectures",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LectureTitle",
                table: "Lectures",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
