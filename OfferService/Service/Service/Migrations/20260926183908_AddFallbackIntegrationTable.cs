using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddFallbackIntegrationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FallbackIntegrations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfferId = table.Column<long>(type: "bigint", nullable: true),
                    PostbackType = table.Column<string>(type: "text", nullable: true),
                    EnableFallback = table.Column<string>(type: "text", nullable: true),
                    FallbackUrl = table.Column<string>(type: "text", nullable: true),
                    FallbackOfferId = table.Column<long>(type: "bigint", nullable: true),
                    FallbackOfferReportsAffiliates = table.Column<string>(type: "text", nullable: true),
                    HtmlJsCode = table.Column<string>(type: "text", nullable: true),
                    UrlToReplace = table.Column<string>(type: "text", nullable: true),
                    Erid = table.Column<string>(type: "text", nullable: true),
                    ForceAffiliateLandingRedirect = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FallbackIntegrations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FallbackIntegrations");
        }
    }
}
