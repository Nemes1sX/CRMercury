﻿// <auto-generated />
using System;
using CRMercury;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using CRMercury.Models;

namespace megaprojektas.Migrations
{
    [DbContext(typeof(CRMercuryContext))]
    [Migration("20190922164119_CRMercury")]
    partial class CRMercury
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRMercury.Company", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ceoname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("phone")
                        .IsRequired();

                    b.Property<bool>("status");

                    b.Property<string>("website")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("CRMercury.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("fullname")
                        .IsRequired();

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<bool>("status");

                    b.HasKey("id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("CRMercury.Task", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<string>("state");

                    b.Property<bool>("status");

                    b.Property<DateTime>("taskdate");

                    b.HasKey("id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("CRMercury.Task", b =>
                {
                    b.HasOne("CRMercury.Company", "Company")
                        .WithMany("Tasks")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRMercury.Employee", "Employee")
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
