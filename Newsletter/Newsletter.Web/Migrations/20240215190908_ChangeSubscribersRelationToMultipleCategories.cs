using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeniusChuck.Newsletter.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSubscribersRelationToMultipleCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Categories_CategoryId",
                table: "Subscribers");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_CategoryId",
                table: "Subscribers");

            migrationBuilder.AddColumn<int>(
                name: "SubscriberId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubscriberId",
                table: "Categories",
                column: "SubscriberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Subscribers_SubscriberId",
                table: "Categories",
                column: "SubscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Subscribers_SubscriberId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SubscriberId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SubscriberId",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_CategoryId",
                table: "Subscribers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_Categories_CategoryId",
                table: "Subscribers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
