using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RequestsService.Migrations
{
    /// <inheritdoc />
    public partial class RequestsRework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Requests",
                newName: "ResponsibleId");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Requests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Requests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_AuthorId",
                table: "Requests",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ResponsibleId",
                table: "Requests",
                column: "ResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_AuthorId",
                table: "Requests",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_ResponsibleId",
                table: "Requests",
                column: "ResponsibleId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_AuthorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_ResponsibleId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_AuthorId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ResponsibleId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "ResponsibleId",
                table: "Requests",
                newName: "ManagerId");

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Description", "ManagerId", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new Guid("c5209f70-7106-4166-b1c1-36a07693129f"), new DateTime(2026, 1, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "Тестовое описание 1", new Guid("00000000-0000-0000-0000-000000000000"), 0, "Тестовая заявка 1" },
                    { 2, new Guid("c5209f70-7106-4166-b1c1-36a07693129f"), new DateTime(2026, 1, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Тестовое описание 2", new Guid("f4c3952d-d633-4850-9042-8af385ef2253"), 3, "Тестовая заявка 2" }
                });
        }
    }
}
