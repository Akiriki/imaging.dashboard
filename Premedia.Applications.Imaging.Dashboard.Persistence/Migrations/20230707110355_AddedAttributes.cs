using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Premedia.Applications.Imaging.Dashboard.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "TimeTracking",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EditorId",
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
                name: "CreatedById",
                table: "JobFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "TimeTrackingId",
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

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_CreatedById",
                table: "TimeTracking",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_EditorId",
                table: "TimeTracking",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_JobFiles_CreatedById",
                table: "JobFiles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Job_AdditionalFileId",
                table: "Job",
                column: "AdditionalFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CreatedById",
                table: "Job",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CustomerId",
                table: "Job",
                column: "CustomerId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Job_TimeTrackingId",
                table: "Job",
                column: "TimeTrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_History_EditorId",
                table: "History",
                column: "EditorId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_User_EditorId",
                table: "History",
                column: "EditorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Job_User_CustomerId",
                table: "Job",
                column: "CustomerId",
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
                name: "FK_History_User_EditorId",
                table: "History");

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
                name: "FK_Job_User_CustomerId",
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

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTracking_User_EditorId",
                table: "TimeTracking");

            migrationBuilder.DropIndex(
                name: "IX_TimeTracking_CreatedById",
                table: "TimeTracking");

            migrationBuilder.DropIndex(
                name: "IX_TimeTracking_EditorId",
                table: "TimeTracking");

            migrationBuilder.DropIndex(
                name: "IX_JobFiles_CreatedById",
                table: "JobFiles");

            migrationBuilder.DropIndex(
                name: "IX_Job_AdditionalFileId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_CreatedById",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_CustomerId",
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

            migrationBuilder.DropIndex(
                name: "IX_Job_TimeTrackingId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_History_EditorId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "TimeTracking");

            migrationBuilder.DropColumn(
                name: "EditorId",
                table: "TimeTracking");

            migrationBuilder.DropColumn(
                name: "WorkingDuration",
                table: "TimeTracking");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "JobFiles");

            migrationBuilder.DropColumn(
                name: "AdditionalFileId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "CreatedById",
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
                name: "EditorId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "HistoriesId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "JobFilesId",
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
                name: "TimeTrackingId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "EditorId",
                table: "History");
        }
    }
}
