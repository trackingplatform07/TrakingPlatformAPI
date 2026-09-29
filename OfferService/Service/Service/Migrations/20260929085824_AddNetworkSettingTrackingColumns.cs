using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddNetworkSettingTrackingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppsFlyerAccessKey",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppsFlyerClickSigningMode",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClickIpv4FilterMode",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClickIpv4FilterRanges",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ClickSigningAdvertiserId",
                table: "NetworkSettings",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConversionsOutOfAllowedCountries",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomTrackingDomain",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DataMaskingDeviceId",
                table: "NetworkSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DataMaskingIpAddress",
                table: "NetworkSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DefaultTrackingDomain",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultTrackingLinkTokens",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultTrackingProtocol",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultUniqueIdFields",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GlobalFallbackUrl",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpSource",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LandingPageMismatch",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostbackErrorAlertEmail",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostbackErrorThreshold",
                table: "NetworkSettings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TestAffiliateId",
                table: "NetworkSettings",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestIps",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrackingDomain",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TrackingLinkPreviewEnabled",
                table: "NetworkSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppsFlyerAccessKey",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AppsFlyerClickSigningMode",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ClickIpv4FilterMode",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ClickIpv4FilterRanges",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ClickSigningAdvertiserId",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ConversionsOutOfAllowedCountries",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "CustomTrackingDomain",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "DataMaskingDeviceId",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "DataMaskingIpAddress",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "DefaultTrackingDomain",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "DefaultTrackingLinkTokens",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "DefaultTrackingProtocol",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "DefaultUniqueIdFields",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "GlobalFallbackUrl",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "IpSource",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "LandingPageMismatch",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "PostbackErrorAlertEmail",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "PostbackErrorThreshold",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "TestAffiliateId",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "TestIps",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "TrackingDomain",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "TrackingLinkPreviewEnabled",
                table: "NetworkSettings");
        }
    }
}
