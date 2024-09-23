using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineNow.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v0001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "RatingAsNumber",
                table: "Movies",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingAsNumber",
                table: "Movies");
        }
    }
}
