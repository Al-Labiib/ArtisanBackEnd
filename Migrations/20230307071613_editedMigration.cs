using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtisanBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class editedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobName",
                table: "Artisans");

            migrationBuilder.AddColumn<int>(
                name: "JobCategory",
                table: "Artisans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobCategory",
                table: "Artisans");

            migrationBuilder.AddColumn<string>(
                name: "JobName",
                table: "Artisans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
