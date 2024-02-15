using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeniusChuck.NewsletterExample.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSubscribersRelationToM2M : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CategorySubscriber",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    SubscribersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySubscriber", x => new { x.CategoriesId, x.SubscribersId });
                    table.ForeignKey(
                        name: "FK_CategorySubscriber_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySubscriber_Subscribers_SubscribersId",
                        column: x => x.SubscribersId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorySubscriber_SubscribersId",
                table: "CategorySubscriber",
                column: "SubscribersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorySubscriber");

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
    }
}
