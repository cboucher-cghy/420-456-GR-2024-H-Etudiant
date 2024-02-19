using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeniusChuck.Newsletter.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Category_CategoryId",
                table: "Subscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Cates_CategoryId",
                table: "Subscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cates",
                table: "Cates");

            migrationBuilder.RenameTable(
                name: "Cates",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_Category_CategoryId",
                table: "Subscribers",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
