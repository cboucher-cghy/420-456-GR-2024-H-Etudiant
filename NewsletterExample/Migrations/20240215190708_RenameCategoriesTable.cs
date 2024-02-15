using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeniusChuck.NewsletterExample.Migrations
{
    /// <inheritdoc />
    public partial class RenameCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Cates_CategoryId",
                table: "Subscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cates",
                table: "Cates");

            migrationBuilder.RenameTable(
                name: "Cates",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_Categories_CategoryId",
                table: "Subscribers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Categories_CategoryId",
                table: "Subscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Cates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cates",
                table: "Cates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_Cates_CategoryId",
                table: "Subscribers",
                column: "CategoryId",
                principalTable: "Cates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
