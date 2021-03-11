using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestsData.Migrations
{
    public partial class ChangedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Tests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    IdTest = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorIdAuthor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.IdTest);
                    table.ForeignKey(
                        name: "FK_Tests_Author_AuthorIdAuthor",
                        column: x => x.AuthorIdAuthor,
                        principalTable: "Author",
                        principalColumn: "IdAuthor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    IdItem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: true),
                    ItemInformation = table.Column<string>(maxLength: 250, nullable: true),
                    RightVariant = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_Items_Tests_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Tests",
                        principalColumn: "IdTest",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    IdVariant = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemIdItem = table.Column<int>(nullable: true),
                    VariantInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.IdVariant);
                    table.ForeignKey(
                        name: "FK_Variants_Items_ItemIdItem",
                        column: x => x.ItemIdItem,
                        principalTable: "Items",
                        principalColumn: "IdItem",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemId",
                table: "Items",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_AuthorIdAuthor",
                table: "Tests",
                column: "AuthorIdAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ItemIdItem",
                table: "Variants",
                column: "ItemIdItem");
        }
    }
}
