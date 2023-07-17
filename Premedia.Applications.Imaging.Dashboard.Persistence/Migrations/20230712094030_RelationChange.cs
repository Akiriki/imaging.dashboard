using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Premedia.Applications.Imaging.Dashboard.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RelationChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "JobFiles");

            migrationBuilder.DropColumn(
                name: "Filepath",
                table: "AdditionalFile");

            migrationBuilder.AddColumn<Guid>(
                name: "EditorId",
                table: "TimeTracking",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "JobId",
                table: "TimeTracking",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "WorkingDuration",
                table: "TimeTracking",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<Guid>(
                name: "FilePathId",
                table: "JobFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "JobId",
                table: "JobFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Job",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Job",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Job",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "EasyJob",
                table: "Job",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JobInfo",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Job",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Project",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SwitchJobId",
                table: "Job",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EditorId",
                table: "History",
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
                name: "IX_TimeTracking_EditorId",
                table: "TimeTracking",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_JobId",
                table: "TimeTracking",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobFiles_JobId",
                table: "JobFiles",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_ClientId",
                table: "Job",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CustomerId",
                table: "Job",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_History_EditorId",
                table: "History",
                column: "EditorId");

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
                name: "FK_History_User_EditorId",
                table: "History",
                column: "EditorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Client_ClientId",
                table: "Job",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_User_CustomerId",
                table: "Job",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobFiles_Job_JobId",
                table: "JobFiles",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTracking_Job_JobId",
                table: "TimeTracking",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTracking_User_EditorId",
                table: "TimeTracking",
                column: "EditorId",
                principalTable: "User",
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
                name: "FK_History_User_EditorId",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Client_ClientId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_User_CustomerId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_JobFiles_Job_JobId",
                table: "JobFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTracking_Job_JobId",
                table: "TimeTracking");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTracking_User_EditorId",
                table: "TimeTracking");

            migrationBuilder.DropIndex(
                name: "IX_TimeTracking_EditorId",
                table: "TimeTracking");

            migrationBuilder.DropIndex(
                name: "IX_TimeTracking_JobId",
                table: "TimeTracking");

            migrationBuilder.DropIndex(
                name: "IX_JobFiles_JobId",
                table: "JobFiles");

            migrationBuilder.DropIndex(
                name: "IX_Job_ClientId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_CustomerId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_History_EditorId",
                table: "History");

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
                name: "EditorId",
                table: "TimeTracking");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "TimeTracking");

            migrationBuilder.DropColumn(
                name: "WorkingDuration",
                table: "TimeTracking");

            migrationBuilder.DropColumn(
                name: "FilePathId",
                table: "JobFiles");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "JobFiles");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "EasyJob",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "JobInfo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "Project",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "SwitchJobId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "EditorId",
                table: "History");

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

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "JobFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Filepath",
                table: "AdditionalFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
