using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddAntiFraudSettingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AntiFraudSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfferId = table.Column<long>(type: "bigint", nullable: true),
                    ClickSpammingDefender = table.Column<string>(type: "text", nullable: true),
                    UniqueClickLimit = table.Column<string>(type: "text", nullable: true),
                    ProxyBotBlock = table.Column<string>(type: "text", nullable: true),
                    BrowserBlankReferral = table.Column<string>(type: "text", nullable: true),
                    DefaultIpSource = table.Column<string>(type: "text", nullable: true),
                    ClickIpv4RangeFilter = table.Column<string>(type: "text", nullable: true),
                    ClickIpv4RangeValues = table.Column<string>(type: "text", nullable: true),
                    HtmlRedirectHttpReferral = table.Column<string>(type: "text", nullable: true),
                    ClickBlockFiltersJson = table.Column<string>(type: "text", nullable: true),
                    ConversionValidateFiltersJson = table.Column<string>(type: "text", nullable: true),
                    CtitRulesJson = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntiFraudSettings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AntiFraudSettings");
        }
    }
}
