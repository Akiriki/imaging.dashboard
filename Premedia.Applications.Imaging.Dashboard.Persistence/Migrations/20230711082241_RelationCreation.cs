using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Premedia.Applications.Imaging.Dashboard.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RelationCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_AdditionalFile_AdditionalFileId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_History_HistoriesId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_JobFiles_JobFilesId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_TimeTracking_TimeTrackingId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_User_CreatedById",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_User_EditorId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_JobFiles_User_CreatedById",
                table: "JobFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTracking_User_CreatedById",
                table: "TimeTracking");

            migrationBuilder.DropIndex(
                name: "IX_Job_AdditionalFileId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_CreatedById",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_EditorId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_HistoriesId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_JobFilesId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "JobFiles");

            migrationBuilder.DropColumn(
                name: "AdditionalFileId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "EditorId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "HistoriesId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "JobFilesId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "Filepath",
                table: "AdditionalFile");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TimeTracking",
                newName: "JobId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeTracking_CreatedById",
                table: "TimeTracking",
                newName: "IX_TimeTracking_JobId");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "JobFiles",
                newName: "JobId");

            migrationBuilder.RenameIndex(
                name: "IX_JobFiles_CreatedById",
                table: "JobFiles",
                newName: "IX_JobFiles_JobId");

            migrationBuilder.RenameColumn(
                name: "TimeTrackingId",
                table: "Job",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_TimeTrackingId",
                table: "Job",
                newName: "IX_Job_ClientId");

            migrationBuilder.AddColumn<Guid>(
                name: "FilePathId",
                table: "JobFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "JobId",
                table: "History",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdditionalFileId",
                table: "FilePath",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "JobFileId",
                table: "FilePath",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "JobId",
                table: "AdditionalFile",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_History_JobId",
                table: "History",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_FilePath_AdditionalFileId",
                table: "FilePath",
                column: "AdditionalFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilePath_JobFileId",
                table: "FilePath",
                column: "JobFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFile_JobId",
                table: "AdditionalFile",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFile_Job_JobId",
                table: "AdditionalFile",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilePath_AdditionalFile_AdditionalFileId",
                table: "FilePath",
                column: "AdditionalFileId",
                principalTable: "AdditionalFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilePath_JobFiles_JobFileId",
                table: "FilePath",
                column: "JobFileId",
                principalTable: "JobFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_History_Job_JobId",
                table: "History",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Client_ClientId",
                table: "Job",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobFiles_Job_JobId",
                table: "JobFiles",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTracking_Job_JobId",
                table: "TimeTracking",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFile_Job_JobId",
                table: "AdditionalFile");

            migrationBuilder.DropForeignKey(
                name: "FK_FilePath_AdditionalFile_AdditionalFileId",
                table: "FilePath");

            migrationBuilder.DropForeignKey(
                name: "FK_FilePath_JobFiles_JobFileId",
                table: "FilePath");

            migrationBuilder.DropForeignKey(
                name: "FK_History_Job_JobId",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Client_ClientId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_JobFiles_Job_JobId",
                table: "JobFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTracking_Job_JobId",
                table: "TimeTracking");

            migrationBuilder.DropIndex(
                name: "IX_History_JobId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_FilePath_AdditionalFileId",
                table: "FilePath");

            migrationBuilder.DropIndex(
                name: "IX_FilePath_JobFileId",
                table: "FilePath");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalFile_JobId",
                table: "AdditionalFile");

            migrationBuilder.DropColumn(
                name: "FilePathId",
                table: "JobFiles");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "AdditionalFileId",
                table: "FilePath");

            migrationBuilder.DropColumn(
                name: "JobFileId",
                table: "FilePath");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "AdditionalFile");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "TimeTracking",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TimeTracking_JobId",
                table: "TimeTracking",
                newName: "IX_TimeTracking_CreatedById");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "JobFiles",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_JobFiles_JobId",
                table: "JobFiles",
                newName: "IX_JobFiles_CreatedById");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Job",
                newName: "TimeTrackingId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_ClientId",
                table: "Job",
                newName: "IX_Job_TimeTrackingId");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "JobFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "AdditionalFileId",
                table: "Job",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Job",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EditorId",
                table: "Job",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HistoriesId",
                table: "Job",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "JobFilesId",
                table: "Job",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Filepath",
                table: "AdditionalFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Job_AdditionalFileId",
                table: "Job",
                column: "AdditionalFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CreatedById",
                table: "Job",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Job_EditorId",
                table: "Job",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_HistoriesId",
                table: "Job",
                column: "HistoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobFilesId",
                table: "Job",
                column: "JobFilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_AdditionalFile_AdditionalFileId",
                table: "Job",
                column: "AdditionalFileId",
                principalTable: "AdditionalFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_History_HistoriesId",
                table: "Job",
                column: "HistoriesId",
                principalTable: "History",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_JobFiles_JobFilesId",
                table: "Job",
                column: "JobFilesId",
                principalTable: "JobFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_TimeTracking_TimeTrackingId",
                table: "Job",
                column: "TimeTrackingId",
                principalTable: "TimeTracking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_User_CreatedById",
                table: "Job",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_User_EditorId",
                table: "Job",
                column: "EditorId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobFiles_User_CreatedById",
                table: "JobFiles",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTracking_User_CreatedById",
                table: "TimeTracking",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
