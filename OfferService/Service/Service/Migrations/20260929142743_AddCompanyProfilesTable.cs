using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyProfilesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<string>(type: "text", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: true),
                    AccountEmail = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Zip = table.Column<string>(type: "text", nullable: true),
                    Contact = table.Column<string>(type: "text", nullable: true),
                    SocialContactPlatform = table.Column<string>(type: "text", nullable: true),
                    SocialContactValue = table.Column<string>(type: "text", nullable: true),
                    CustomProfileName = table.Column<string>(type: "text", nullable: true),
                    CustomProfileEmail = table.Column<string>(type: "text", nullable: true),
                    CustomProfileContact = table.Column<string>(type: "text", nullable: true),
                    CustomProfileSelect = table.Column<string>(type: "text", nullable: true),
                    CustomProfileExtra = table.Column<string>(type: "text", nullable: true),
                    TaxGstVat = table.Column<string>(type: "text", nullable: true),
                    TaxIgstVatType = table.Column<string>(type: "text", nullable: true),
                    TaxPan = table.Column<string>(type: "text", nullable: true),
                    TaxPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    AccountSecretKey = table.Column<string>(type: "text", nullable: false),
                    SecretKeyGeneratedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfiles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyProfiles");
        }
    }
}
