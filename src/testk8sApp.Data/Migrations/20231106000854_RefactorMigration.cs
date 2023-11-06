using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testK8sApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class RefactorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "proof",
                column: "Id",
                value: new Guid("00000000-0000-0000-0000-000000000001"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "proof",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));
        }
    }
}
