using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddCouponDetailColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AffiliateIds",
                table: "Coupons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AffiliateMode",
                table: "Coupons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Coupons",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AffiliateIds",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "AffiliateMode",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Coupons");
        }
    }
}
