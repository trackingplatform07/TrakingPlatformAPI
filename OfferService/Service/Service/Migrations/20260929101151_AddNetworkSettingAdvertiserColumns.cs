using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddNetworkSettingAdvertiserColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdvertiserInvoiceCc",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdvertiserPaymentMethods",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdvertiserReportFieldsCustomization",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdvertiserSignUpApproval",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AdvertiserSignUpEnabled",
                table: "NetworkSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AdvertiserSignupFieldsCustomization",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdvertiserSignupMessengerTypes",
                table: "NetworkSettings",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvertiserInvoiceCc",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AdvertiserPaymentMethods",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AdvertiserReportFieldsCustomization",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AdvertiserSignUpApproval",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AdvertiserSignUpEnabled",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AdvertiserSignupFieldsCustomization",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AdvertiserSignupMessengerTypes",
                table: "NetworkSettings");
        }
    }
}
