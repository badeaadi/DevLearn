using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestsData.Migrations
{
    public partial class ProblemEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Problem",
                columns: table => new
                {
                    IdProblem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProblemLectureIdLecture = table.Column<int>(nullable: true),
                    Link = table.Column<string>(maxLength: 250, nullable: false),
                    Dificultate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problem", x => x.IdProblem);
                    table.ForeignKey(
                        name: "FK_Problem_Lectures_ProblemLectureIdLecture",
                        column: x => x.ProblemLectureIdLecture,
                        principalTable: "Lectures",
                        principalColumn: "IdLecture",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Problem_ProblemLectureIdLecture",
                table: "Problem",
                column: "ProblemLectureIdLecture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problem");
        }
    }
}
