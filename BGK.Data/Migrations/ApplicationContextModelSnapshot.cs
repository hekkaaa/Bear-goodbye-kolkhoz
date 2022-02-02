﻿// <auto-generated />
using System;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BearGoodbyeKolkhozProject.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BirthDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MembersCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Classroom");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BirthDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.ContactLecturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.ToTable("ContactLecturer");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassroomId")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LecturerId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Lecturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BirthDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Lecturer");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.LecturerReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LecturerId");

                    b.ToTable("LecturerReview");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("TrainingId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("MembersCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.TrainingReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("TrainingId");

                    b.ToTable("TrainingReview");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Client", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Event", null)
                        .WithMany("Clients")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.ContactLecturer", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Lecturer", "Lecturer")
                        .WithMany()
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Event", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Classroom", "Classroom")
                        .WithMany()
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Lecturer", "Lecturer")
                        .WithMany("Events")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Company");

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.LecturerReview", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Client", "Client")
                        .WithMany("LecturerReviews")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Company", null)
                        .WithMany("LecturerReviews")
                        .HasForeignKey("CompanyId");

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Lecturer", "Lecturer")
                        .WithMany("LecturerReviews")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Topic", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Client", null)
                        .WithMany("Topic")
                        .HasForeignKey("ClientId");

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Training", null)
                        .WithMany("Topic")
                        .HasForeignKey("TrainingId");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Training", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Lecturer", null)
                        .WithMany("Trainings")
                        .HasForeignKey("LecturerId");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.TrainingReview", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Client", "Client")
                        .WithMany("TrainingReviews")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Company", null)
                        .WithMany("TrainingReviews")
                        .HasForeignKey("CompanyId");

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Training", "Training")
                        .WithMany("TrainingReviews")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Client", b =>
                {
                    b.Navigation("LecturerReviews");

                    b.Navigation("Topic");

                    b.Navigation("TrainingReviews");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Company", b =>
                {
                    b.Navigation("LecturerReviews");

                    b.Navigation("TrainingReviews");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Event", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Lecturer", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("LecturerReviews");

                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Training", b =>
                {
                    b.Navigation("Topic");

                    b.Navigation("TrainingReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
