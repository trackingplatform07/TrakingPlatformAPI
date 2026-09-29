using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddCappingRulesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CappingRules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfferId = table.Column<long>(type: "bigint", nullable: true),
                    RuleName = table.Column<string>(type: "text", nullable: true),
                    RuleType = table.Column<string>(type: "text", nullable: true),
                    CappingType = table.Column<string>(type: "text", nullable: true),
                    Period = table.Column<string>(type: "text", nullable: true),
                    CappingValue = table.Column<decimal>(type: "numeric", nullable: true),
                    OverCappingAction = table.Column<string>(type: "text", nullable: true),
                    CappingTimezoneEnabled = table.Column<bool>(type: "boolean", nullable: true),
                    Events = table.Column<string>(type: "text", nullable: true),
                    AffiliateVisibility = table.Column<string>(type: "text", nullable: true),
                    EnableRule = table.Column<bool>(type: "boolean", nullable: true),
                    NotificationEmail = table.Column<string>(type: "text", nullable: true),
                    EarlierNotificationThreshold = table.Column<decimal>(type: "numeric", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CappingRules", x => x.Id);
                });

            // Creative, LandingPage, Offer, OfferCategory and TargetingRules already exist in the
            // Offer18DevDB database (created outside of EF migrations). This migration only adds the
            // new CappingRules table and must not touch those existing tables.
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CappingRules");
        }
    }
}
