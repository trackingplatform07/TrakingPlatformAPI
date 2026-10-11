using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAgentSourceToLinkTestResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "LinkTestResults",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAgent",
                table: "LinkTestResults",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "LinkTestResults");

            migrationBuilder.DropColumn(
                name: "UserAgent",
                table: "LinkTestResults");
        }
    }
}
