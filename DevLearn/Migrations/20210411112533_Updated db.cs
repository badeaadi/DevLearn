using Microsoft.EntityFrameworkCore.Migrations;

namespace TestsData.Migrations
{
    public partial class Updateddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Lectures_ProblemLectureIdLecture",
                table: "Problems");

            migrationBuilder.RenameColumn(
                name: "ProblemLectureIdLecture",
                table: "Problems",
                newName: "LectureIdLecture");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_ProblemLectureIdLecture",
                table: "Problems",
                newName: "IX_Problems_LectureIdLecture");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Lectures_LectureIdLecture",
                table: "Problems",
                column: "LectureIdLecture",
                principalTable: "Lectures",
                principalColumn: "IdLecture",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Lectures_LectureIdLecture",
                table: "Problems");

            migrationBuilder.RenameColumn(
                name: "LectureIdLecture",
                table: "Problems",
                newName: "ProblemLectureIdLecture");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_LectureIdLecture",
                table: "Problems",
                newName: "IX_Problems_ProblemLectureIdLecture");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Lectures_ProblemLectureIdLecture",
                table: "Problems",
                column: "ProblemLectureIdLecture",
                principalTable: "Lectures",
                principalColumn: "IdLecture",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
