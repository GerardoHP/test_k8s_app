using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testK8sApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ProofOfLifeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "proof",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proof", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "proof", 
                columns: new[]{ "Id" },
                values:new object[,]
                {
                    {Guid.NewGuid()}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "proof");
        }
    }
}
