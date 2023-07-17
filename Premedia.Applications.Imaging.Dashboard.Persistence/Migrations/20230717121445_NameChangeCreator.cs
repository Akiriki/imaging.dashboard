using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Premedia.Applications.Imaging.Dashboard.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NameChangeCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilePath_JobFiles_JobFileId",
                table: "FilePath");

            migrationBuilder.DropTable(
                name: "JobFiles");

            migrationBuilder.CreateTable(
                name: "UpdateJobFilesCommand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SwitchJobField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalFilename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedFilename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FileProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateJobFilesCommand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpdateJobFilesCommand_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UpdateJobFilesCommand_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpdateJobFilesCommand_CreatorId",
                table: "UpdateJobFilesCommand",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_UpdateJobFilesCommand_JobId",
                table: "UpdateJobFilesCommand",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilePath_UpdateJobFilesCommand_JobFileId",
                table: "FilePath",
                column: "JobFileId",
                principalTable: "UpdateJobFilesCommand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilePath_UpdateJobFilesCommand_JobFileId",
                table: "FilePath");

            migrationBuilder.DropTable(
                name: "UpdateJobFilesCommand");

            migrationBuilder.CreateTable(
                name: "JobFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedFilename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalFilename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StorageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SwitchJobField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobFiles_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobFiles_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobFiles_CreatorId",
                table: "JobFiles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_JobFiles_JobId",
                table: "JobFiles",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilePath_JobFiles_JobFileId",
                table: "FilePath",
                column: "JobFileId",
                principalTable: "JobFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
