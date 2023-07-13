using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Premedia.Applications.Imaging.Dashboard.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DataTypeChangeEasyJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePathId",
                table: "JobFiles");

            migrationBuilder.AlterColumn<string>(
                name: "EasyJob",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FilePathId",
                table: "JobFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<bool>(
                name: "EasyJob",
                table: "Job",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
