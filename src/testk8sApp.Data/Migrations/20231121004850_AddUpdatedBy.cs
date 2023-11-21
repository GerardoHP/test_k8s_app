using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testK8sApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UPDATED_BY",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "system");

            migrationBuilder.AddColumn<string>(
                name: "UPDATED_BY",
                table: "Authors",
                type: "text",
                nullable: false,
                defaultValue: "system");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UPDATED_BY",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY",
                table: "Authors");
        }
    }
}
