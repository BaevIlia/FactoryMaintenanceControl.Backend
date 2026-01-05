using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RequestsService.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Requests",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Requests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    JobTitle = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "CreatedAt", "ManagerId", "Status" },
                values: new object[] { new Guid("c5209f70-7106-4166-b1c1-36a07693129f"), new DateTime(2026, 1, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 0 });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "CreatedAt", "ManagerId", "Status" },
                values: new object[] { new Guid("c5209f70-7106-4166-b1c1-36a07693129f"), new DateTime(2026, 1, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f4c3952d-d633-4850-9042-8af385ef2253"), 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "JobTitle", "Phone" },
                values: new object[,]
                {
                    { new Guid("c5209f70-7106-4166-b1c1-36a07693129f"), "engineer@job.ru", "Иванов Иван Иванович", 0, "+79999999999" },
                    { new Guid("f4c3952d-d633-4850-9042-8af385ef2253"), "manager@job.ru", "Петров Петр Петрович", 1, "+78888888888" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Requests");
        }
    }
}
