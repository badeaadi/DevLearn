using Microsoft.EntityFrameworkCore.Migrations;

namespace TestsData.Migrations
{
    public partial class SlideMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Author_AuthorIdAuthor",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Problem_Lectures_ProblemLectureIdLecture",
                table: "Problem");

            migrationBuilder.DropForeignKey(
                name: "FK_Slide_Lectures_LectureIdLecture",
                table: "Slide");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slide",
                table: "Slide");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pupil",
                table: "Pupil");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Problem",
                table: "Problem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Slide",
                newName: "Slides");

            migrationBuilder.RenameTable(
                name: "Pupil",
                newName: "Pupils");

            migrationBuilder.RenameTable(
                name: "Problem",
                newName: "Problems");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_Slide_LectureIdLecture",
                table: "Slides",
                newName: "IX_Slides_LectureIdLecture");

            migrationBuilder.RenameIndex(
                name: "IX_Pupil_Username",
                table: "Pupils",
                newName: "IX_Pupils_Username");

            migrationBuilder.RenameIndex(
                name: "IX_Problem_ProblemLectureIdLecture",
                table: "Problems",
                newName: "IX_Problems_ProblemLectureIdLecture");

            migrationBuilder.AlterColumn<int>(
                name: "LectureIdLecture",
                table: "Slides",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slides",
                table: "Slides",
                column: "IdSlide");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pupils",
                table: "Pupils",
                column: "IdPupil");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Problems",
                table: "Problems",
                column: "IdProblem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "IdAuthor");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Authors_AuthorIdAuthor",
                table: "Lectures",
                column: "AuthorIdAuthor",
                principalTable: "Authors",
                principalColumn: "IdAuthor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Lectures_ProblemLectureIdLecture",
                table: "Problems",
                column: "ProblemLectureIdLecture",
                principalTable: "Lectures",
                principalColumn: "IdLecture",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slides_Lectures_LectureIdLecture",
                table: "Slides",
                column: "LectureIdLecture",
                principalTable: "Lectures",
                principalColumn: "IdLecture",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Authors_AuthorIdAuthor",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Lectures_ProblemLectureIdLecture",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_Slides_Lectures_LectureIdLecture",
                table: "Slides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slides",
                table: "Slides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pupils",
                table: "Pupils");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Problems",
                table: "Problems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Slides",
                newName: "Slide");

            migrationBuilder.RenameTable(
                name: "Pupils",
                newName: "Pupil");

            migrationBuilder.RenameTable(
                name: "Problems",
                newName: "Problem");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Slides_LectureIdLecture",
                table: "Slide",
                newName: "IX_Slide_LectureIdLecture");

            migrationBuilder.RenameIndex(
                name: "IX_Pupils_Username",
                table: "Pupil",
                newName: "IX_Pupil_Username");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_ProblemLectureIdLecture",
                table: "Problem",
                newName: "IX_Problem_ProblemLectureIdLecture");

            migrationBuilder.AlterColumn<int>(
                name: "LectureIdLecture",
                table: "Slide",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slide",
                table: "Slide",
                column: "IdSlide");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pupil",
                table: "Pupil",
                column: "IdPupil");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Problem",
                table: "Problem",
                column: "IdProblem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "IdAuthor");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Author_AuthorIdAuthor",
                table: "Lectures",
                column: "AuthorIdAuthor",
                principalTable: "Author",
                principalColumn: "IdAuthor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Problem_Lectures_ProblemLectureIdLecture",
                table: "Problem",
                column: "ProblemLectureIdLecture",
                principalTable: "Lectures",
                principalColumn: "IdLecture",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slide_Lectures_LectureIdLecture",
                table: "Slide",
                column: "LectureIdLecture",
                principalTable: "Lectures",
                principalColumn: "IdLecture",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
