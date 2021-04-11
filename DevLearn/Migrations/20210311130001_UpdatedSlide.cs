using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestsData.Migrations
{
    public partial class UpdatedSlide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Variant");

            migrationBuilder.RenameColumn(
                name: "Information",
                table: "Slide",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Slide",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ItemInformation",
                table: "Items",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Items",
                nullable: true);

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
                name: "Variants",
                columns: table => new
                {
                    IdVariant = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VariantInformation = table.Column<string>(nullable: true),
                    ItemIdItem = table.Column<int>(nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Tests_ItemId",
                table: "Items",
                column: "ItemId",
                principalTable: "Tests",
                principalColumn: "IdTest",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Tests_ItemId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Slide");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Slide",
                newName: "Information");

            migrationBuilder.AlterColumn<string>(
                name: "ItemInformation",
                table: "Items",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Variant",
                columns: table => new
                {
                    IdVariant = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemIdItem = table.Column<int>(nullable: true),
                    VariantInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variant", x => x.IdVariant);
                    table.ForeignKey(
                        name: "FK_Variant_Items_ItemIdItem",
                        column: x => x.ItemIdItem,
                        principalTable: "Items",
                        principalColumn: "IdItem",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Variant_ItemIdItem",
                table: "Variant",
                column: "ItemIdItem");
        }
    }
}
