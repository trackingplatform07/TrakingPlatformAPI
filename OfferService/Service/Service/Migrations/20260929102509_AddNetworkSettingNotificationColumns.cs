using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class AddNetworkSettingNotificationColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotificationPrefix",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotificationSettingsJson",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlackWebhookUrl",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelegramBotToken",
                table: "NetworkSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelegramChatId",
                table: "NetworkSettings",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationPrefix",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "NotificationSettingsJson",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "SlackWebhookUrl",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "TelegramBotToken",
                table: "NetworkSettings");

            migrationBuilder.DropColumn(
                name: "TelegramChatId",
                table: "NetworkSettings");
        }
    }
}
