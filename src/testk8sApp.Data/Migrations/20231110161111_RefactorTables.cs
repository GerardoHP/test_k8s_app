using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testK8sApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProofOfLives");

            migrationBuilder.AddColumn<DateTime>(
                name: "DELETED_AT",
                table: "Books",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IS_DELETED",
                table: "Books",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_AT",
                table: "Books",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DELETED_AT",
                table: "Authors",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IS_DELETED",
                table: "Authors",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_AT",
                table: "Authors",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DELETED_AT",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IS_DELETED",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UPDATED_AT",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DELETED_AT",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "IS_DELETED",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "UPDATED_AT",
                table: "Authors");

            migrationBuilder.CreateTable(
                name: "ProofOfLives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProofOfLives", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProofOfLives",
                column: "Id",
                value: new Guid("00000000-0000-0000-0000-000000000001"));
        }
    }
}
