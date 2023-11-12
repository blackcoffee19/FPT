﻿// <auto-generated />
using System;
using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeApi.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeApi.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
