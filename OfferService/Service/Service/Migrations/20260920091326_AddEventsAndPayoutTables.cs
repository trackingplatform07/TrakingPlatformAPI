using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddEventsAndPayoutTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventGoals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfferId = table.Column<long>(type: "bigint", nullable: true),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: true),
                    MultiConversion = table.Column<string>(type: "text", nullable: true),
                    MultiConversionIp = table.Column<string>(type: "text", nullable: true),
                    Approval = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGoals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfferId = table.Column<long>(type: "bigint", nullable: true),
                    ConversionWaitingTime = table.Column<string>(type: "text", nullable: true),
                    MultiConversion = table.Column<string>(type: "text", nullable: true),
                    ConversionApproval = table.Column<string>(type: "text", nullable: true),
                    MultiConversionIp = table.Column<string>(type: "text", nullable: true),
                    DefaultPostbackEvent = table.Column<string>(type: "text", nullable: true),
                    EventMismatchAction = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayoutRules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfferId = table.Column<long>(type: "bigint", nullable: true),
                    RuleName = table.Column<string>(type: "text", nullable: true),
                    RevenueModel = table.Column<string>(type: "text", nullable: true),
                    RevenueValue = table.Column<decimal>(type: "numeric", nullable: true),
                    PayoutModel = table.Column<string>(type: "text", nullable: true),
                    PayoutValue = table.Column<decimal>(type: "numeric", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    ConditionsJson = table.Column<string>(type: "text", nullable: true),
                    AffiliateVisibility = table.Column<string>(type: "text", nullable: true),
                    RulePriority = table.Column<string>(type: "text", nullable: true),
                    EnableRule = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutRules", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventGoals");

            migrationBuilder.DropTable(
                name: "EventSettings");

            migrationBuilder.DropTable(
                name: "PayoutRules");
        }
    }
}
