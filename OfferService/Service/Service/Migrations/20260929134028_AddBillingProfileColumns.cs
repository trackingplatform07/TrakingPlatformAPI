using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddBillingProfileColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "BillingSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                table: "BillingSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "BillingSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "BillingSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GstVatNumber",
                table: "BillingSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotificationEmails",
                table: "BillingSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "BillingSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "BillingSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateCode",
                table: "BillingSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxNumberPan",
                table: "BillingSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "BillingSubscriptions",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "BillingSubscriptions");

            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                table: "BillingSubscriptions");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "BillingSubscriptions");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "BillingSubscriptions");

            migrationBuilder.DropColumn(
                name: "GstVatNumber",
                table: "BillingSubscriptions");

            migrationBuilder.DropColumn(
                name: "NotificationEmails",
                table: "BillingSubscriptions");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "BillingSubscriptions");

            migrationBuilder.DropColumn(
                name: "State",
                table: "BillingSubscriptions");

            migrationBuilder.DropColumn(
                name: "StateCode",
                table: "BillingSubscriptions");

            migrationBuilder.DropColumn(
                name: "TaxNumberPan",
                table: "BillingSubscriptions");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "BillingSubscriptions");
        }
    }
}
