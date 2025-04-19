using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OcuHubBackend.Migrations
{
    /// <inheritdoc />
    public partial class FinalSyncAndFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileCustoms_Users_UserId",
                table: "UserProfileCustoms");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileGenerateds_Users_UserId",
                table: "UserProfileGenerateds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfileGenerateds",
                table: "UserProfileGenerateds");

            migrationBuilder.DropIndex(
                name: "IX_UserProfileGenerateds_UserId",
                table: "UserProfileGenerateds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfileCustoms",
                table: "UserProfileCustoms");

            migrationBuilder.DropIndex(
                name: "IX_UserProfileCustoms_UserId",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserProfileGenerateds");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "City",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserProfileCustoms");

            migrationBuilder.RenameColumn(
                name: "Workplace",
                table: "UserProfileCustoms",
                newName: "WorkPlace");

            migrationBuilder.AddColumn<string>(
                name: "FirebaseUid",
                table: "UserProfileGenerateds",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "UserProfileCustoms",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "UserProfileCustoms",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DegreeId",
                table: "UserProfileCustoms",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirebaseUid",
                table: "UserProfileCustoms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "UserProfileCustoms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfessionTitle",
                table: "UserProfileCustoms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubspecialtyId",
                table: "UserProfileCustoms",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserAppSettings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfileGenerateds",
                table: "UserProfileGenerateds",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfileCustoms",
                table: "UserProfileCustoms",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "AppVersionRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Platform = table.Column<string>(type: "text", nullable: false),
                    MinimumVersion = table.Column<string>(type: "text", nullable: false),
                    ForceUpdate = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVersionRequirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ToolName = table.Column<string>(type: "text", nullable: false),
                    FeedbackText = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeedbacks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppVersionRequirements");

            migrationBuilder.DropTable(
                name: "UserFeedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfileGenerateds",
                table: "UserProfileGenerateds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfileCustoms",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "FirebaseUid",
                table: "UserProfileGenerateds");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "DegreeId",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "FirebaseUid",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "ProfessionTitle",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "SubspecialtyId",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserAppSettings");

            migrationBuilder.RenameColumn(
                name: "WorkPlace",
                table: "UserProfileCustoms",
                newName: "Workplace");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserProfileGenerateds",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserProfileCustoms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserProfileCustoms",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "UserProfileCustoms",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "UserProfileCustoms",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserProfileCustoms",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfileGenerateds",
                table: "UserProfileGenerateds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfileCustoms",
                table: "UserProfileCustoms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileGenerateds_UserId",
                table: "UserProfileGenerateds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileCustoms_UserId",
                table: "UserProfileCustoms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileCustoms_Users_UserId",
                table: "UserProfileCustoms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileGenerateds_Users_UserId",
                table: "UserProfileGenerateds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
