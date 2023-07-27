﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoveYourBumAPI.Data;

#nullable disable

namespace MoveYourBumAPI.Migrations
{
    [DbContext(typeof(MoveYourBumContext))]
    [Migration("20230624095453_M6")]
    partial class M6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MoveYourBumAPI.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Day");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.DaySchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDay")
                        .HasColumnType("int");

                    b.Property<int>("IdSchedule")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdDay");

                    b.HasIndex("IdSchedule");

                    b.ToTable("DaySchedule");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdExerciseType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MuscleInvolvedDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProperTechniqueDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdExerciseType");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.ExercisePhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdExercise")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdExercise");

                    b.ToTable("ExercisePhoto");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.ExerciseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExerciseType");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.ScheduleExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Annotation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdExercise")
                        .HasColumnType("int");

                    b.Property<int>("IdSchedule")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdExercise");

                    b.HasIndex("IdSchedule");

                    b.ToTable("ScheduleExercise");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.ScheduleExerciseSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ActualReps")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdDaySchedule")
                        .HasColumnType("int");

                    b.Property<int>("IdScheduleExercise")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlannedReps")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeightUsed")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDaySchedule");

                    b.HasIndex("IdScheduleExercise");

                    b.ToTable("ScheduleExerciseSet");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.DaySchedule", b =>
                {
                    b.HasOne("MoveYourBumAPI.Models.Day", "Day")
                        .WithMany("DaySchedules")
                        .HasForeignKey("IdDay")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoveYourBumAPI.Models.Schedule", "Schedule")
                        .WithMany("DaySchedules")
                        .HasForeignKey("IdSchedule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.Exercise", b =>
                {
                    b.HasOne("MoveYourBumAPI.Models.ExerciseType", "ExerciseType")
                        .WithMany("Exercises")
                        .HasForeignKey("IdExerciseType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseType");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.ExercisePhoto", b =>
                {
                    b.HasOne("MoveYourBumAPI.Models.Exercise", "Exercise")
                        .WithMany("Photos")
                        .HasForeignKey("IdExercise")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.ScheduleExercise", b =>
                {
                    b.HasOne("MoveYourBumAPI.Models.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("IdExercise")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoveYourBumAPI.Models.Schedule", "Schedule")
                        .WithMany("ScheduleExercises")
                        .HasForeignKey("IdSchedule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.ScheduleExerciseSet", b =>
                {
                    b.HasOne("MoveYourBumAPI.Models.DaySchedule", "DaySchedule")
                        .WithMany()
                        .HasForeignKey("IdDaySchedule");

                    b.HasOne("MoveYourBumAPI.Models.ScheduleExercise", "ScheduleExercise")
                        .WithMany("Sets")
                        .HasForeignKey("IdScheduleExercise")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DaySchedule");

                    b.Navigation("ScheduleExercise");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.Day", b =>
                {
                    b.Navigation("DaySchedules");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.Exercise", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.ExerciseType", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.Schedule", b =>
                {
                    b.Navigation("DaySchedules");

                    b.Navigation("ScheduleExercises");
                });

            modelBuilder.Entity("MoveYourBumAPI.Models.ScheduleExercise", b =>
                {
                    b.Navigation("Sets");
                });
#pragma warning restore 612, 618
        }
    }
}
