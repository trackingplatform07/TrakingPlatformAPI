using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddNetworkSettingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NetworkSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NetworkName = table.Column<string>(type: "text", nullable: false),
                    LoginPlatformDomain = table.Column<string>(type: "text", nullable: true),
                    CustomLoginPlatformDomain = table.Column<string>(type: "text", nullable: true),
                    LoginAccessTypes = table.Column<string>(type: "text", nullable: true),
                    Timezone = table.Column<string>(type: "text", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    Language = table.Column<string>(type: "text", nullable: true),
                    DefaultAffiliateManagerUserId = table.Column<long>(type: "bigint", nullable: true),
                    DefaultAdvertiserManagerUserId = table.Column<long>(type: "bigint", nullable: true),
                    EmployeeDashboardCustomization = table.Column<string>(type: "text", nullable: true),
                    CustomPrivacyPolicy = table.Column<string>(type: "text", nullable: true),
                    TermsAndConditions = table.Column<string>(type: "text", nullable: true),
                    CustomTermsAndConditionsTitle = table.Column<string>(type: "text", nullable: true),
                    CustomTermsAndConditionsBody = table.Column<string>(type: "text", nullable: true),
                    OfferDefaultTermsAndConditions = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkSettings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetworkSettings");
        }
    }
}
