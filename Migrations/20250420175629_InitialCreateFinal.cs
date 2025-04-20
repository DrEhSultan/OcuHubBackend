using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcuHubBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAppSettings_Users_UserId1",
                table: "UserAppSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlaces_Places_PlaceId",
                table: "UserPlaces");

            migrationBuilder.DropIndex(
                name: "IX_UserAppSettings_UserId1",
                table: "UserAppSettings");

            migrationBuilder.DropColumn(
                name: "WorkPlace",
                table: "UserProfileCustoms");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserAppSettings");

            migrationBuilder.RenameColumn(
                name: "RelationType",
                table: "UserPlaces",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "CityOverride",
                table: "UserPlaces",
                newName: "Location");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlaceId",
                table: "UserPlaces",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "CustomPlaceName",
                table: "UserPlaces",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "UserPlaces",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "UserPlaces",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserAppSettings",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Places",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LocationOverride",
                table: "Places",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAppSettings_UserId",
                table: "UserAppSettings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAppSettings_Users_UserId",
                table: "UserAppSettings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlaces_Places_PlaceId",
                table: "UserPlaces",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAppSettings_Users_UserId",
                table: "UserAppSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlaces_Places_PlaceId",
                table: "UserPlaces");

            migrationBuilder.DropIndex(
                name: "IX_UserAppSettings_UserId",
                table: "UserAppSettings");

            migrationBuilder.DropColumn(
                name: "CustomPlaceName",
                table: "UserPlaces");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "UserPlaces");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "UserPlaces");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "LocationOverride",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "UserPlaces",
                newName: "RelationType");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "UserPlaces",
                newName: "CityOverride");

            migrationBuilder.AddColumn<string>(
                name: "WorkPlace",
                table: "UserProfileCustoms",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PlaceId",
                table: "UserPlaces",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserAppSettings",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UserAppSettings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserAppSettings_UserId1",
                table: "UserAppSettings",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAppSettings_Users_UserId1",
                table: "UserAppSettings",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlaces_Places_PlaceId",
                table: "UserPlaces",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
