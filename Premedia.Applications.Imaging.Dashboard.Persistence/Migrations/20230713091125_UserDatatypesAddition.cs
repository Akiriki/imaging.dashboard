using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Premedia.Applications.Imaging.Dashboard.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserDatatypesAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "JobFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AdditionalFile",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_JobFiles_CreatorId",
                table: "JobFiles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFile_CreatorId",
                table: "AdditionalFile",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFile_User_CreatorId",
                table: "AdditionalFile",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobFiles_User_CreatorId",
                table: "JobFiles",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFile_User_CreatorId",
                table: "AdditionalFile");

            migrationBuilder.DropForeignKey(
                name: "FK_JobFiles_User_CreatorId",
                table: "JobFiles");

            migrationBuilder.DropIndex(
                name: "IX_JobFiles_CreatorId",
                table: "JobFiles");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalFile_CreatorId",
                table: "AdditionalFile");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "JobFiles");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AdditionalFile");
        }
    }
}
