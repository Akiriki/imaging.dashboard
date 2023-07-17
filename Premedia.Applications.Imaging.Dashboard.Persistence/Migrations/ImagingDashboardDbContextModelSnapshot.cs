﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Premedia.Applications.Imaging.Dashboard.Persistence;

#nullable disable

namespace Premedia.Applications.Imaging.Dashboard.Persistence.Migrations
{
    [DbContext(typeof(ImagingDashboardDbContext))]
    partial class ImagingDashboardDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.AdditionalFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("JobId");

                    b.ToTable("AdditionalFile");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shortcut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.FilePath", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdditionalFileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EbvFileaction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("JobFileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MacPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WindowsPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalFileId")
                        .IsUnique();

                    b.HasIndex("JobFileId")
                        .IsUnique();

                    b.ToTable("FilePath");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.History", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ChangeTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EditorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ErrorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NewValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EditorId");

                    b.HasIndex("JobId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BillingOption")
                        .HasColumnType("int");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ConsecutiveNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EasyJob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EditorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JobInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderType")
                        .HasColumnType("int");

                    b.Property<string>("Project")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SwitchJobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EditorId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.JobFiles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Activity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditedFilename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileProperties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OriginalFilename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StorageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SwitchJobField")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("JobId");

                    b.ToTable("JobFiles");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.TimeTracking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EditorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartedOn")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("WorkingDuration")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("EditorId");

                    b.HasIndex("JobId");

                    b.ToTable("TimeTracking");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.AdditionalFile", b =>
                {
                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.User", "Creator")
                        .WithMany("AdditionalFile")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.Job", "Job")
                        .WithMany("AdditionalFile")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.FilePath", b =>
                {
                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.AdditionalFile", "AdditionalFile")
                        .WithOne("FilePath")
                        .HasForeignKey("Premedia.Applications.Imaging.Dashboard.Core.Entities.FilePath", "AdditionalFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.JobFiles", "JobFiles")
                        .WithOne("FilePath")
                        .HasForeignKey("Premedia.Applications.Imaging.Dashboard.Core.Entities.FilePath", "JobFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalFile");

                    b.Navigation("JobFiles");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.History", b =>
                {
                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.User", "Editor")
                        .WithMany("History")
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.Job", "Job")
                        .WithMany("History")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editor");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.Job", b =>
                {
                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.Client", "Client")
                        .WithMany("Job")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.User", "Creator")
                        .WithMany("JobsAsCreator")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.User", "Customer")
                        .WithMany("JobsAsCustomer")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.User", "Editor")
                        .WithMany("JobsAsEditor")
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Client");

                    b.Navigation("Creator");

                    b.Navigation("Customer");

                    b.Navigation("Editor");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.JobFiles", b =>
                {
                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.User", "Creator")
                        .WithMany("JobFiles")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.Job", "Job")
                        .WithMany("JobFiles")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.TimeTracking", b =>
                {
                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.User", "Creator")
                        .WithMany("TimeTrackingCreator")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.User", "Editor")
                        .WithMany("TimeTrackingEditor")
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Premedia.Applications.Imaging.Dashboard.Core.Entities.Job", "Job")
                        .WithMany("TimeTracking")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Editor");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.AdditionalFile", b =>
                {
                    b.Navigation("FilePath")
                        .IsRequired();
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.Client", b =>
                {
                    b.Navigation("Job");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.Job", b =>
                {
                    b.Navigation("AdditionalFile");

                    b.Navigation("History");

                    b.Navigation("JobFiles");

                    b.Navigation("TimeTracking");
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.JobFiles", b =>
                {
                    b.Navigation("FilePath")
                        .IsRequired();
                });

            modelBuilder.Entity("Premedia.Applications.Imaging.Dashboard.Core.Entities.User", b =>
                {
                    b.Navigation("AdditionalFile");

                    b.Navigation("History");

                    b.Navigation("JobFiles");

                    b.Navigation("JobsAsCreator");

                    b.Navigation("JobsAsCustomer");

                    b.Navigation("JobsAsEditor");

                    b.Navigation("TimeTrackingCreator");

                    b.Navigation("TimeTrackingEditor");
                });
#pragma warning restore 612, 618
        }
    }
}
