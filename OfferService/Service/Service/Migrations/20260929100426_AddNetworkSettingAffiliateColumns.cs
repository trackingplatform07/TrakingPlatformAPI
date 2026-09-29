using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddNetworkSettingAffiliateColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AffiliateDefaultLanguage",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AffiliateImpressionUrlEnabled",
                table: "NetworkSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AffiliateInvoiceCc",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AffiliatePaymentMethods",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AffiliatePayoutDisplay",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AffiliatePlatformTheme",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AffiliateReportsDisplay",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AffiliateSignUpEnabled",
                table: "NetworkSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "HttpReferral",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostbackTokenCustomization",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReferralCommissionDays",
                table: "NetworkSettings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReferralCommissionEnabled",
                table: "NetworkSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReferralCommissionType",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferralCommissionValue",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferralTerms",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportFieldsCustomization",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignUpApproval",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignupFieldsCustomization",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignupMessengerTypes",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SignupQuestionsAllowMultiple",
                table: "NetworkSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SignupQuestionsEnabled",
                table: "NetworkSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SignupQuestionsJson",
                table: "NetworkSettings",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AffiliateDefaultLanguage",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AffiliateImpressionUrlEnabled",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AffiliateInvoiceCc",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AffiliatePaymentMethods",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AffiliatePayoutDisplay",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AffiliatePlatformTheme",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AffiliateReportsDisplay",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "AffiliateSignUpEnabled",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "HttpReferral",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "PostbackTokenCustomization",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ReferralCommissionDays",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ReferralCommissionEnabled",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ReferralCommissionType",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ReferralCommissionValue",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ReferralTerms",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "ReportFieldsCustomization",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "SignUpApproval",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "SignupFieldsCustomization",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "SignupMessengerTypes",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "SignupQuestionsAllowMultiple",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "SignupQuestionsEnabled",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "SignupQuestionsJson",
                table: "NetworkSettings");
        }
    }
}
