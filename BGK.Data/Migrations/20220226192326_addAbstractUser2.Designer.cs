﻿// <auto-generated />
using System;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BearGoodbyeKolkhozProject.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220226192326_addAbstractUser2")]
    partial class addAbstractUser2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MembersCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Classroom");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "ул. Вавилова дом 5",
                            City = "Санкт-Петербург",
                            IsDeleted = false,
                            MembersCount = 25
                        },
                        new
                        {
                            Id = 2,
                            Address = "пр. Ветеранов дом 8",
                            City = "Санкт-Петербург",
                            IsDeleted = false,
                            MembersCount = 25
                        },
                        new
                        {
                            Id = 3,
                            Address = "ул. Пушкина дом 27",
                            City = "Санкт-Петербург",
                            IsDeleted = false,
                            MembersCount = 40
                        });
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

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

                    b.Property<int?>("ClassroomId")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LecturerId")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LecturerId");

                    b.HasIndex("TrainingId");

                    b.ToTable("Event");
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

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

                    b.Property<int>("MembersCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

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

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BirthDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ClientEvent", b =>
                {
                    b.Property<int>("ClientsId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("ClientsId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("ClientEvent");
                });

            modelBuilder.Entity("ClientTopic", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("ClientId", "TopicId");

                    b.HasIndex("TopicId");

                    b.ToTable("ClientTopic");
                });

            modelBuilder.Entity("LecturerTraining", b =>
                {
                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingsId")
                        .HasColumnType("int");

                    b.HasKey("LecturerId", "TrainingsId");

                    b.HasIndex("TrainingsId");

                    b.ToTable("LecturerTraining");
                });

            modelBuilder.Entity("TopicTraining", b =>
                {
                    b.Property<int>("TopicsId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("TopicsId", "TrainingId");

                    b.HasIndex("TrainingId");

                    b.ToTable("TopicTraining");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Admin", b =>
                {
                    b.HasBaseType("BearGoodbyeKolkhozProject.Data.Entities.User");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDay = "01.01.2000",
                            Email = "Admin@mail.ru",
                            Gender = 1,
                            IsDeleted = false,
                            LastName = "Admin",
                            Name = "Admin",
                            Password = "1000:WvGHoK1WF2vO/ZkCz8FcmEdWsULri96e:oYQNDwkRfTN2Sm1fY56gS/5esvc=",
                            Role = 1
                        });
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Client", b =>
                {
                    b.HasBaseType("BearGoodbyeKolkhozProject.Data.Entities.User");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Lecturer", b =>
                {
                    b.HasBaseType("BearGoodbyeKolkhozProject.Data.Entities.User");

                    b.ToTable("Lecturer");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.ContactLecturer", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Lecturer", "Lecturer")
                        .WithMany("ContactLecturer")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Event", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Classroom", "Classroom")
                        .WithMany()
                        .HasForeignKey("ClassroomId");

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Lecturer", "Lecturer")
                        .WithMany("Events")
                        .HasForeignKey("LecturerId");

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Training", "Training")
                        .WithMany("Event")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Company");

                    b.Navigation("Lecturer");

                    b.Navigation("Training");
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

            modelBuilder.Entity("ClientEvent", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Event", null)
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClientTopic", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Topic", null)
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LecturerTraining", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Lecturer", null)
                        .WithMany()
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Training", null)
                        .WithMany()
                        .HasForeignKey("TrainingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TopicTraining", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Topic", null)
                        .WithMany()
                        .HasForeignKey("TopicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.Training", null)
                        .WithMany()
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Admin", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("BearGoodbyeKolkhozProject.Data.Entities.Admin", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Client", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("BearGoodbyeKolkhozProject.Data.Entities.Client", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Lecturer", b =>
                {
                    b.HasOne("BearGoodbyeKolkhozProject.Data.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("BearGoodbyeKolkhozProject.Data.Entities.Lecturer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Company", b =>
                {
                    b.Navigation("LecturerReviews");

                    b.Navigation("TrainingReviews");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Training", b =>
                {
                    b.Navigation("Event");

                    b.Navigation("TrainingReviews");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Client", b =>
                {
                    b.Navigation("LecturerReviews");

                    b.Navigation("TrainingReviews");
                });

            modelBuilder.Entity("BearGoodbyeKolkhozProject.Data.Entities.Lecturer", b =>
                {
                    b.Navigation("ContactLecturer");

                    b.Navigation("Events");

                    b.Navigation("LecturerReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
