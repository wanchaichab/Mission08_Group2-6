﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission08_Group2_6.Models;

namespace Mission08_Group2_6.Migrations
{
    [DbContext(typeof(TaskEntryContext))]
    [Migration("20230225060720_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("Mission08_Group2_6.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Home"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "School"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Work"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Church"
                        });
                });

            modelBuilder.Entity("Mission08_Group2_6.Models.TaskEntry", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quadrant")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("Mission08_Group2_6.Models.TaskEntry", b =>
                {
                    b.HasOne("Mission08_Group2_6.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
