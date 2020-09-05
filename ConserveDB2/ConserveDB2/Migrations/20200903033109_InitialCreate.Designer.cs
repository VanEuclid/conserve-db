﻿// <auto-generated />
using System;
using ConserveDB2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConserveDB2.Migrations
{
    [DbContext(typeof(ConserveContext))]
    [Migration("20200903033109_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("ConserveDB2.Models.Department", b =>
                {
                    b.Property<int>("DId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("departmentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ConserveDB2.Models.Member", b =>
                {
                    b.Property<int>("Mid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("DId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmploymentStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FavoriteColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PreferredContactPhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Shift")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamMemberPhoto")
                        .HasColumnType("TEXT");

                    b.HasKey("Mid");

                    b.ToTable("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
