﻿// <auto-generated />
using System;
using ExampleTest2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExampleTest2.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExampleTest2.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FirstName = "Louis",
                            LastName = "Armstrong"
                        });
                });

            modelBuilder.Entity("ExampleTest2.Models.Client2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Client2s");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "FirstName",
                            LastName = "LastName"
                        });
                });

            modelBuilder.Entity("ExampleTest2.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FirstName = "Louis",
                            LastName = "Armstrong"
                        });
                });

            modelBuilder.Entity("ExampleTest2.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("AcceptedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FulfilledAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AcceptedAt = new DateTime(2025, 6, 9, 20, 38, 15, 714, DateTimeKind.Local).AddTicks(810),
                            ClientID = 1,
                            Comments = "Comment",
                            EmployeeID = 1,
                            FulfilledAt = new DateTime(2025, 6, 9, 20, 38, 15, 714, DateTimeKind.Local).AddTicks(812)
                        });
                });

            modelBuilder.Entity("ExampleTest2.Models.Order2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FulfilledAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("StatusId");

                    b.ToTable("Order2s");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            CreatedAt = new DateTime(2025, 6, 9, 20, 38, 15, 714, DateTimeKind.Local).AddTicks(628),
                            FulfilledAt = new DateTime(2025, 6, 9, 20, 38, 15, 714, DateTimeKind.Local).AddTicks(693),
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("ExampleTest2.Models.OrderPastry", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("PastryID")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Comme")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("OrderID", "PastryID");

                    b.HasIndex("PastryID");

                    b.ToTable("Order_Pastry");

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            PastryID = 1,
                            Amount = 10,
                            Comme = "Comme"
                        });
                });

            modelBuilder.Entity("ExampleTest2.Models.Pastry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("ID");

                    b.ToTable("Pastries");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Pastry",
                            Price = 10m,
                            Type = "type"
                        });
                });

            modelBuilder.Entity("ExampleTest2.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Product",
                            Price = 10m
                        });
                });

            modelBuilder.Entity("ExampleTest2.Models.ProductOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("Product_Order");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ProductId = 1,
                            Amount = 10
                        });
                });

            modelBuilder.Entity("ExampleTest2.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nam = "Name"
                        });
                });

            modelBuilder.Entity("ExampleTest2.Models.Order", b =>
                {
                    b.HasOne("ExampleTest2.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExampleTest2.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ExampleTest2.Models.Order2", b =>
                {
                    b.HasOne("ExampleTest2.Models.Client2", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExampleTest2.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ExampleTest2.Models.OrderPastry", b =>
                {
                    b.HasOne("ExampleTest2.Models.Order", "Order")
                        .WithMany("OrderPastries")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExampleTest2.Models.Pastry", "Pastry")
                        .WithMany("OrderPastries")
                        .HasForeignKey("PastryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pastry");
                });

            modelBuilder.Entity("ExampleTest2.Models.ProductOrder", b =>
                {
                    b.HasOne("ExampleTest2.Models.Order2", "Order")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExampleTest2.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ExampleTest2.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ExampleTest2.Models.Client2", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ExampleTest2.Models.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ExampleTest2.Models.Order", b =>
                {
                    b.Navigation("OrderPastries");
                });

            modelBuilder.Entity("ExampleTest2.Models.Order2", b =>
                {
                    b.Navigation("ProductOrders");
                });

            modelBuilder.Entity("ExampleTest2.Models.Pastry", b =>
                {
                    b.Navigation("OrderPastries");
                });
#pragma warning restore 612, 618
        }
    }
}
