using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddAutomationRulesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutomationRules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfferId = table.Column<long>(type: "bigint", nullable: true),
                    RuleName = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    BlockLevel = table.Column<string>(type: "text", nullable: true),
                    Advertiser = table.Column<string>(type: "text", nullable: true),
                    OffersJson = table.Column<string>(type: "text", nullable: true),
                    Conversion = table.Column<string>(type: "text", nullable: true),
                    Clicks = table.Column<string>(type: "text", nullable: true),
                    Impressions = table.Column<string>(type: "text", nullable: true),
                    Field = table.Column<string>(type: "text", nullable: true),
                    CompareType = table.Column<string>(type: "text", nullable: true),
                    MinValue = table.Column<string>(type: "text", nullable: true),
                    MaxValue = table.Column<string>(type: "text", nullable: true),
                    ReportStatus = table.Column<string>(type: "text", nullable: true),
                    DataLookBack = table.Column<string>(type: "text", nullable: true),
                    Schedule = table.Column<string>(type: "text", nullable: true),
                    DateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WhitelistOffers = table.Column<string>(type: "text", nullable: true),
                    ResumeAfter = table.Column<string>(type: "text", nullable: true),
                    AlertEnabled = table.Column<bool>(type: "boolean", nullable: true),
                    LastCheck = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Alarm = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomationRules", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutomationRules");
        }
    }
}
