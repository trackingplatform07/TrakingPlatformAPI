using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkTesterTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkTesterRules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RuleName = table.Column<string>(type: "text", nullable: false),
                    AdvertiserId = table.Column<long>(type: "bigint", nullable: true),
                    OfferId = table.Column<long>(type: "bigint", nullable: true),
                    CustomUrl = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Schedule = table.Column<string>(type: "text", nullable: true),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    TestCountry = table.Column<string>(type: "text", nullable: true),
                    HealthyCheckThreshold = table.Column<string>(type: "text", nullable: true),
                    AllowedRedirection = table.Column<string>(type: "text", nullable: true),
                    ResaleDetection = table.Column<string>(type: "text", nullable: true),
                    AdvertiserAppId = table.Column<string>(type: "text", nullable: true),
                    AppIdMatch = table.Column<string>(type: "text", nullable: true),
                    AllowedHttpStatuses = table.Column<string>(type: "text", nullable: true),
                    StopOffer = table.Column<bool>(type: "boolean", nullable: false),
                    MinimumOneRedirect = table.Column<bool>(type: "boolean", nullable: false),
                    LastCheck = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Health = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkTesterRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkTestResults",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RuleId = table.Column<long>(type: "bigint", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false),
                    OsDevice = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    FinalStatusCode = table.Column<int>(type: "integer", nullable: true),
                    RedirectCount = table.Column<int>(type: "integer", nullable: false),
                    ResultText = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    StartedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinishedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkTestResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkTesterRules");

            migrationBuilder.DropTable(
                name: "LinkTestResults");
        }
    }
}
