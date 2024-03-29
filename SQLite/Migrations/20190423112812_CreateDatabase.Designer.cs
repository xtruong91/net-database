﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SQLite.Data;
using System;

namespace SQLite.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190423112812_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("SQLite.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseID");

                    b.Property<int>("PlayerID");

                    b.Property<int?>("TournamentID");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("TournamentID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("SQLite.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("Tag");

                    b.HasKey("ID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SQLite.Models.Tournament", b =>
                {
                    b.Property<int>("TournamentID");

                    b.Property<int>("Credits");

                    b.Property<string>("Title");

                    b.HasKey("TournamentID");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("SQLite.Models.Enrollment", b =>
                {
                    b.HasOne("SQLite.Models.Player", "Player")
                        .WithMany("Enrollments")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SQLite.Models.Tournament", "Tournament")
                        .WithMany("Enrollments")
                        .HasForeignKey("TournamentID");
                });
#pragma warning restore 612, 618
        }
    }
}
