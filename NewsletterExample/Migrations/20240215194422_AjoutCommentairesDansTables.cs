using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeniusChuck.NewsletterExample.Migrations
{
    /// <inheritdoc />
    public partial class AjoutCommentairesDansTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "Subscribers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Indique la date/heure de son inscription",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionDate",
                table: "CategorySubscriber",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Indique la date/heure de son inscription pour une catégorie donnée!",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "Subscribers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Indique la date/heure de son inscription");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionDate",
                table: "CategorySubscriber",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Indique la date/heure de son inscription pour une catégorie donnée!");
        }
    }
}
