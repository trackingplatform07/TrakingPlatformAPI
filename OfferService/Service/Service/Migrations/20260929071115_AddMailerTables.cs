using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddMailerTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailerLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdvertiserId = table.Column<long>(type: "bigint", nullable: true),
                    AffiliateId = table.Column<long>(type: "bigint", nullable: true),
                    BulkAdvertiserStatus = table.Column<string>(type: "text", nullable: true),
                    BulkAffiliateStatus = table.Column<string>(type: "text", nullable: true),
                    AdvertiserCountry = table.Column<string>(type: "text", nullable: true),
                    AffiliateCountry = table.Column<string>(type: "text", nullable: true),
                    Recipients = table.Column<string>(type: "text", nullable: true),
                    Cc = table.Column<string>(type: "text", nullable: true),
                    Bcc = table.Column<string>(type: "text", nullable: true),
                    Schedule = table.Column<string>(type: "text", nullable: true),
                    ScheduledOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TemplateId = table.Column<long>(type: "bigint", nullable: true),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    RecipientCount = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    SentOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailerLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailerTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailerTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmtpSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Host = table.Column<string>(type: "text", nullable: false),
                    Port = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    FromEmail = table.Column<string>(type: "text", nullable: true),
                    FromName = table.Column<string>(type: "text", nullable: true),
                    UseSsl = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmtpSettings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailerLogs");

            migrationBuilder.DropTable(
                name: "MailerTemplates");

            migrationBuilder.DropTable(
                name: "SmtpSettings");
        }
    }
}
