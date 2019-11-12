﻿// <auto-generated />
using System;
using Bigoton.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bigoton.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191111230533_ChangeRelation6")]
    partial class ChangeRelation6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bigoton.Web.Data.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("CutStyleId");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("PaymentId");

                    b.Property<int?>("ReservationId");

                    b.HasKey("Id");

                    b.HasIndex("CutStyleId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Bigoton.Web.Data.Entities.CutStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Remarks");

                    b.HasKey("Id");

                    b.ToTable("CutStyles");
                });

            modelBuilder.Entity("Bigoton.Web.Data.Entities.DiscountVoucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discount")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("DiscountVouchers");
                });

            modelBuilder.Entity("Bigoton.Web.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Bigoton.Web.Data.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("DiscountCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int?>("DiscountVoucherId");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("TotalPayment")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("DiscountVoucherId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Bigoton.Web.Data.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("EmployeeCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("EmployeeId");

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Remarks");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Bigoton.Web.Data.Entities.Client", b =>
                {
                    b.HasOne("Bigoton.Web.Data.Entities.CutStyle", "CutStyle")
                        .WithMany("Clients")
                        .HasForeignKey("CutStyleId");

                    b.HasOne("Bigoton.Web.Data.Entities.Payment", "Payment")
                        .WithMany("Clients")
                        .HasForeignKey("PaymentId");

                    b.HasOne("Bigoton.Web.Data.Entities.Reservation", "Reservation")
                        .WithMany("Clients")
                        .HasForeignKey("ReservationId");
                });

            modelBuilder.Entity("Bigoton.Web.Data.Entities.Payment", b =>
                {
                    b.HasOne("Bigoton.Web.Data.Entities.DiscountVoucher", "DiscountVoucher")
                        .WithMany("Payments")
                        .HasForeignKey("DiscountVoucherId");
                });

            modelBuilder.Entity("Bigoton.Web.Data.Entities.Reservation", b =>
                {
                    b.HasOne("Bigoton.Web.Data.Entities.Employee", "Employee")
                        .WithMany("Reservations")
                        .HasForeignKey("EmployeeId");
                });
#pragma warning restore 612, 618
        }
    }
}