using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Premedia.Applications.Imaging.Dashboard.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DatatypeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_User_CustomerId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_CustomerId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Job");

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "NumberOfFiles",
                table: "Job",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "NumberOfFiles",
                table: "Job");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Job",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Job_CustomerId",
                table: "Job",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_User_CustomerId",
                table: "Job",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
