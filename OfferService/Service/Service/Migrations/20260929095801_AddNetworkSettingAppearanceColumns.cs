using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddNetworkSettingAppearanceColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminProfileImageDataUrl",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChatTicketAccessKey1",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChatTicketAccessKey2",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChatTicketAccessKey3",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChatTicketProvider",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteIconDataUrl",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FontStyle",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceSignatureDataUrl",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoSmallDataUrl",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TerminologyAdvertiser",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TerminologyAffiliate",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TerminologyConversion",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TerminologyIGamingUser",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TerminologyOffer",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TerminologyReport",
                table: "NetworkSettings",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminProfileImageDataUrl",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ChatTicketAccessKey1",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ChatTicketAccessKey2",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ChatTicketAccessKey3",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ChatTicketProvider",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "FavoriteIconDataUrl",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "FontStyle",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "InvoiceSignatureDataUrl",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "LogoSmallDataUrl",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "TerminologyAdvertiser",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "TerminologyAffiliate",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "TerminologyConversion",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "TerminologyIGamingUser",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "TerminologyOffer",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "TerminologyReport",
                table: "NetworkSettings");
        }
    }
}
