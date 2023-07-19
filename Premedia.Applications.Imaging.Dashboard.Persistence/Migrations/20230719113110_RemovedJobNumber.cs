using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Premedia.Applications.Imaging.Dashboard.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedJobNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobNumber",
                table: "JobFiles");

            migrationBuilder.DropColumn(
                name: "JobNumber",
                table: "Job");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobNumber",
                table: "JobFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobNumber",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
