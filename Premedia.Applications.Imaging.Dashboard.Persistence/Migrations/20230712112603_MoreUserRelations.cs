using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Premedia.Applications.Imaging.Dashboard.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MoreUserRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTracking_User_EditorId",
                table: "TimeTracking");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "TimeTracking",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Job",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EditorId",
                table: "Job",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_CreatorId",
                table: "TimeTracking",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CreatorId",
                table: "Job",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_EditorId",
                table: "Job",
                column: "EditorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_User_CreatorId",
                table: "Job",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_User_EditorId",
                table: "Job",
                column: "EditorId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTracking_User_CreatorId",
                table: "TimeTracking",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTracking_User_EditorId",
                table: "TimeTracking",
                column: "EditorId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_User_CreatorId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_User_EditorId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTracking_User_CreatorId",
                table: "TimeTracking");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTracking_User_EditorId",
                table: "TimeTracking");

            migrationBuilder.DropIndex(
                name: "IX_TimeTracking_CreatorId",
                table: "TimeTracking");

            migrationBuilder.DropIndex(
                name: "IX_Job_CreatorId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_EditorId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "TimeTracking");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "EditorId",
                table: "Job");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTracking_User_EditorId",
                table: "TimeTracking",
                column: "EditorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
