﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFGetstarted.Migrations
{
    [DbContext(typeof(BloggingContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("EFGetstarted.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("EFGetstarted.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("EFGetstarted.TeamWorker", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamId", "WorkerId");

                    b.ToTable("TeamsWorkers");
                });

            modelBuilder.Entity("EFGetstarted.ToDo", b =>
                {
                    b.Property<int>("ToDoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CurrentTodo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TaskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ToDoId");

                    b.HasIndex("TaskId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("EFGetstarted.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WorkerId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("TeamWorker", b =>
                {
                    b.Property<int>("TeamsTeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkersWorkerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamsTeamId", "WorkersWorkerId");

                    b.HasIndex("WorkersWorkerId");

                    b.ToTable("TeamWorker");
                });

            modelBuilder.Entity("EFGetstarted.ToDo", b =>
                {
                    b.HasOne("EFGetstarted.Task", null)
                        .WithMany("Todos")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("TeamWorker", b =>
                {
                    b.HasOne("EFGetstarted.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFGetstarted.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersWorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFGetstarted.Task", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
