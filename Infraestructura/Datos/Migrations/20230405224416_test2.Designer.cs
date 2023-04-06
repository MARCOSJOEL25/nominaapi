﻿// <auto-generated />
using System;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructura.Datos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230405224416_test2")]
    partial class test2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.models.adicción", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<double>("adicciónSalary")
                        .HasColumnType("double");

                    b.Property<string>("motivo")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeId");

                    b.ToTable("adicción");
                });

            modelBuilder.Entity("Core.models.user", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("core.models.employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Adiccion")
                        .HasColumnType("double");

                    b.Property<DateTime>("DataIn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Idjob")
                        .HasColumnType("int");

                    b.Property<string>("ImagesUrl")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("birdDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("netSalary")
                        .HasColumnType("double");

                    b.Property<double>("salaryFinal")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("Idjob");

                    b.HasIndex("createAt");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("core.models.job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nameJob")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("job");
                });

            modelBuilder.Entity("Core.models.adicción", b =>
                {
                    b.HasOne("core.models.employees", "employees")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employees");
                });

            modelBuilder.Entity("core.models.employees", b =>
                {
                    b.HasOne("core.models.job", "job")
                        .WithMany()
                        .HasForeignKey("Idjob")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.models.user", "user")
                        .WithMany()
                        .HasForeignKey("createAt")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("job");

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}