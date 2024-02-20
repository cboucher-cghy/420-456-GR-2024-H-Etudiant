using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeniusChuck.Newsletter.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Subscribers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_CategoryId",
                table: "Subscribers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_Category_CategoryId",
                table: "Subscribers",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Category_CategoryId",
                table: "Subscribers");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_CategoryId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Subscribers");
        }
    }
}
