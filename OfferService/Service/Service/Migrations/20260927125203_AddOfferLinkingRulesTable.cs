using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddOfferLinkingRulesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfferLinkingRules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RuleName = table.Column<string>(type: "text", nullable: true),
                    AdvertiserId = table.Column<long>(type: "bigint", nullable: true),
                    OffersMode = table.Column<string>(type: "text", nullable: true),
                    OfferIds = table.Column<string>(type: "text", nullable: true),
                    AffiliatesMode = table.Column<string>(type: "text", nullable: true),
                    AffiliateIds = table.Column<string>(type: "text", nullable: true),
                    PayoutCurrency = table.Column<string>(type: "text", nullable: true),
                    PayoutModel = table.Column<string>(type: "text", nullable: true),
                    MinPayout = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxPayout = table.Column<decimal>(type: "numeric", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    LastChecked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferLinkingRules", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferLinkingRules");
        }
    }
}
