using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeniusChuck.NewsletterExample.Migrations
{
    /// <inheritdoc />
    public partial class AjoutCategorySubscriberAvecDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategorySubscriber_Categories_CategoriesId",
                table: "CategorySubscriber");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorySubscriber_Subscribers_SubscribersId",
                table: "CategorySubscriber");

            migrationBuilder.RenameColumn(
                name: "SubscribersId",
                table: "CategorySubscriber",
                newName: "SubscriberId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "CategorySubscriber",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategorySubscriber_SubscribersId",
                table: "CategorySubscriber",
                newName: "IX_CategorySubscriber_SubscriberId");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubscriptionDate",
                table: "CategorySubscriber",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySubscriber_Categories_CategoryId",
                table: "CategorySubscriber",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySubscriber_Subscribers_SubscriberId",
                table: "CategorySubscriber",
                column: "SubscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategorySubscriber_Categories_CategoryId",
                table: "CategorySubscriber");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorySubscriber_Subscribers_SubscriberId",
                table: "CategorySubscriber");

            migrationBuilder.DropColumn(
                name: "SubscriptionDate",
                table: "CategorySubscriber");

            migrationBuilder.RenameColumn(
                name: "SubscriberId",
                table: "CategorySubscriber",
                newName: "SubscribersId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategorySubscriber",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_CategorySubscriber_SubscriberId",
                table: "CategorySubscriber",
                newName: "IX_CategorySubscriber_SubscribersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySubscriber_Categories_CategoriesId",
                table: "CategorySubscriber",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySubscriber_Subscribers_SubscribersId",
                table: "CategorySubscriber",
                column: "SubscribersId",
                principalTable: "Subscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
