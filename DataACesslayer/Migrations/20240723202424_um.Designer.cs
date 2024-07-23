﻿// <auto-generated />
using System;
using DataACesslayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataACesslayer.Migrations
{
    [DbContext(typeof(ApplicationDBcontext))]
    [Migration("20240723202424_um")]
    partial class um
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataACesslayer.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"));

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentDepartmentID")
                        .HasColumnType("int");

                    b.HasKey("DepartmentID");

                    b.HasIndex("ParentDepartmentID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentID = 1,
                            Logo = "hr-logo.png",
                            Name = "HR"
                        },
                        new
                        {
                            DepartmentID = 2,
                            Logo = "it-logo.png",
                            Name = "IT"
                        },
                        new
                        {
                            DepartmentID = 3,
                            Logo = "finance-logo.png",
                            Name = "Finance"
                        });
                });

            modelBuilder.Entity("DataACesslayer.SubDepartment", b =>
                {
                    b.Property<int>("SubDepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubDepartmentID"));

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.HasKey("SubDepartmentID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("ParentID");

                    b.ToTable("SubDepartments");

                    b.HasData(
                        new
                        {
                            SubDepartmentID = 1,
                            DepartmentID = 1,
                            Logo = "recruitment-logo.png",
                            Name = "Recruitment"
                        },
                        new
                        {
                            SubDepartmentID = 2,
                            DepartmentID = 1,
                            Logo = "employee-relations-logo.png",
                            Name = "Employee Relations"
                        },
                        new
                        {
                            SubDepartmentID = 3,
                            DepartmentID = 2,
                            Logo = "software-development-logo.png",
                            Name = "Software Development"
                        },
                        new
                        {
                            SubDepartmentID = 4,
                            DepartmentID = 2,
                            Logo = "it-support-logo.png",
                            Name = "IT Support"
                        },
                        new
                        {
                            SubDepartmentID = 5,
                            DepartmentID = 3,
                            Logo = "accounting-logo.png",
                            Name = "Accounting"
                        },
                        new
                        {
                            SubDepartmentID = 6,
                            DepartmentID = 3,
                            Logo = "budgeting-logo.png",
                            Name = "Budgeting"
                        });
                });

            modelBuilder.Entity("DataACesslayer.Department", b =>
                {
                    b.HasOne("DataACesslayer.Department", "ParentDepartment")
                        .WithMany("ChildDepartments")
                        .HasForeignKey("ParentDepartmentID");

                    b.Navigation("ParentDepartment");
                });

            modelBuilder.Entity("DataACesslayer.SubDepartment", b =>
                {
                    b.HasOne("DataACesslayer.Department", "Department")
                        .WithMany("SubDepartments")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataACesslayer.SubDepartment", "Parent")
                        .WithMany("SubDepartments")
                        .HasForeignKey("ParentID");

                    b.Navigation("Department");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("DataACesslayer.Department", b =>
                {
                    b.Navigation("ChildDepartments");

                    b.Navigation("SubDepartments");
                });

            modelBuilder.Entity("DataACesslayer.SubDepartment", b =>
                {
                    b.Navigation("SubDepartments");
                });
#pragma warning restore 612, 618
        }
    }
}
