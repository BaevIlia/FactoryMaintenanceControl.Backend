using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestsService.Migrations
{
    /// <inheritdoc />
    public partial class AddNecessaryParams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_ResponsibleId",
                table: "Requests");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResponsibleId",
                table: "Requests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_Id_AuthorId",
                table: "Requests",
                columns: new[] { "Id", "AuthorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_ResponsibleId",
                table: "Requests",
                column: "ResponsibleId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_ResponsibleId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_Id_AuthorId",
                table: "Requests");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResponsibleId",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_ResponsibleId",
                table: "Requests",
                column: "ResponsibleId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
