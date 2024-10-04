using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaDB_Preview.Migrations
{
    /// <inheritdoc />
    public partial class InitialSponsor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_SponsorId",
                table: "Sponsors",
                column: "SponsorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsors_Users_SponsorId",
                table: "Sponsors",
                column: "SponsorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sponsors_Users_SponsorId",
                table: "Sponsors");

            migrationBuilder.DropIndex(
                name: "IX_Sponsors_SponsorId",
                table: "Sponsors");
        }
    }
}
