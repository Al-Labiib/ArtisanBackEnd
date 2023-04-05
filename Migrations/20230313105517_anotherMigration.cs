using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtisanBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class anotherMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WalletId",
                table: "Artisans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Artisans_WalletId",
                table: "Artisans",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artisans_Wallets_WalletId",
                table: "Artisans",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artisans_Wallets_WalletId",
                table: "Artisans");

            migrationBuilder.DropIndex(
                name: "IX_Artisans_WalletId",
                table: "Artisans");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "Artisans");
        }
    }
}
