using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcuHubBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationFlagsToAppVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MigrationNotes",
                table: "AppVersionRequirements",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MigrationRequired",
                table: "AppVersionRequirements",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MigrationNotes",
                table: "AppVersionRequirements");

            migrationBuilder.DropColumn(
                name: "MigrationRequired",
                table: "AppVersionRequirements");
        }
    }
}
