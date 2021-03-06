﻿// <auto-generated />
using JobSeekers.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace JobSeekers.Data.Migrations
{
    [DbContext(typeof(JobSeekersContext))]
    [Migration("20171113095659_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("JobSeekers.Data.Models.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("JobSeekers.Data.Models.Position", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("EmployerName");

                    b.Property<string>("EndDate");

                    b.Property<long>("LocationId");

                    b.Property<long?>("ProfileId");

                    b.Property<string>("StartDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("JobSeekers.Data.Models.Profile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Skills");

                    b.HasKey("Id");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("JobSeekers.Data.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<long>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JobSeekers.Data.Models.Position", b =>
                {
                    b.HasOne("JobSeekers.Data.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobSeekers.Data.Models.Profile")
                        .WithMany("WorkHistory")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("JobSeekers.Data.Models.User", b =>
                {
                    b.HasOne("JobSeekers.Data.Models.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
