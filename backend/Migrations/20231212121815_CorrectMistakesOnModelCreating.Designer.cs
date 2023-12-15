﻿// <auto-generated />
using System;
using CarServiceWebConsole.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarServiceWebConsole.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231212121815_CorrectMistakesOnModelCreating")]
    partial class CorrectMistakesOnModelCreating
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("CarServiceWebConsole.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("ManufactureYear")
                        .HasColumnType("integer");

                    b.Property<int>("Mileage")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("StateNumber")
                        .IsRequired()
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasColumnType("char(17)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StateNumber")
                        .IsUnique();

                    b.HasIndex("Vin")
                        .IsUnique();

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("TelegramAlias")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("VkAlias")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("TelegramAlias")
                        .IsUnique();

                    b.HasIndex("VkAlias")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.MaterialPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<bool>("ClientHas")
                        .HasColumnType("boolean");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("WorkerParticipationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkerParticipationId");

                    b.ToTable("MaterialPositions");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("CompletionDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date");

                    b.Property<string>("ProblemDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SiteId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.ProductPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("ProductPositions");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Record", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("BoxId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("OrderId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.ServicePosition", b =>
                {
                    b.Property<int>("WorkerParticipationId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("WorkerParticipationId");

                    b.ToTable("ServicePositions");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Worker", b =>
                {
                    b.Property<int>("MobileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("MobileId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("MobileId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.WorkerParticipation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RecordId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WorkerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecordId");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerParticipations");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Car", b =>
                {
                    b.HasOne("CarServiceWebConsole.Models.Customer", "Customer")
                        .WithMany("Cars")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.MaterialPosition", b =>
                {
                    b.HasOne("CarServiceWebConsole.Models.WorkerParticipation", "WorkerParticipation")
                        .WithMany("MaterialPositions")
                        .HasForeignKey("WorkerParticipationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkerParticipation");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Order", b =>
                {
                    b.HasOne("CarServiceWebConsole.Models.Car", "Car")
                        .WithMany("Orders")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.ProductPosition", b =>
                {
                    b.HasOne("CarServiceWebConsole.Models.Order", "Order")
                        .WithMany("ProductPositions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Record", b =>
                {
                    b.HasOne("CarServiceWebConsole.Models.Order", "Order")
                        .WithOne("Record")
                        .HasForeignKey("CarServiceWebConsole.Models.Record", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.ServicePosition", b =>
                {
                    b.HasOne("CarServiceWebConsole.Models.WorkerParticipation", "WorkerParticipation")
                        .WithOne("ServicePosition")
                        .HasForeignKey("CarServiceWebConsole.Models.ServicePosition", "WorkerParticipationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkerParticipation");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.WorkerParticipation", b =>
                {
                    b.HasOne("CarServiceWebConsole.Models.Record", "Record")
                        .WithMany("WorkerParticipations")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarServiceWebConsole.Models.Worker", "Worker")
                        .WithMany("WorkerParticipations")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Record");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Car", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Customer", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Order", b =>
                {
                    b.Navigation("ProductPositions");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Record", b =>
                {
                    b.Navigation("WorkerParticipations");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.Worker", b =>
                {
                    b.Navigation("WorkerParticipations");
                });

            modelBuilder.Entity("CarServiceWebConsole.Models.WorkerParticipation", b =>
                {
                    b.Navigation("MaterialPositions");

                    b.Navigation("ServicePosition")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
