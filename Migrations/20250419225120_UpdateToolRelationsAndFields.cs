using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcuHubBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToolRelationsAndFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOffline",
                table: "ToolFeedbacks");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "ToolFeedbacks");

            migrationBuilder.DropColumn(
                name: "SyncedAt",
                table: "ToolFeedbacks");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ToolFeedbacks",
                newName: "FeedbackText");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeedbackText",
                table: "ToolFeedbacks",
                newName: "Type");

            migrationBuilder.AddColumn<bool>(
                name: "IsOffline",
                table: "ToolFeedbacks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ToolFeedbacks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SyncedAt",
                table: "ToolFeedbacks",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
