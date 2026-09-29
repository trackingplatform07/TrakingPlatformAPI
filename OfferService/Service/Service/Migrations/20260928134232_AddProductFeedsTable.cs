using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddProductFeedsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OfferIds",
                table: "TopOfferMailerLogs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "TopOfferMailerLogs",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductFeeds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeedName = table.Column<string>(type: "text", nullable: false),
                    FeedType = table.Column<string>(type: "text", nullable: false),
                    OfferId = table.Column<long>(type: "bigint", nullable: true),
                    AdvertiserId = table.Column<long>(type: "bigint", nullable: true),
                    AffiliateMode = table.Column<string>(type: "text", nullable: false),
                    AffiliateIds = table.Column<string>(type: "text", nullable: true),
                    AppendTokens = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    SyncFrequency = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeeds", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeeds");

            migrationBuilder.DropColumn(
                name: "OfferIds",
                table: "TopOfferMailerLogs");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "TopOfferMailerLogs");
        }
    }
}
