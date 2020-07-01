﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using truckapi;

namespace truckapi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200701160417_7thCreate")]
    partial class _7thCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("truckapi.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("truckapi.Models.CommodityOwner", b =>
                {
                    b.Property<int>("CommodityOwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommodityOwnerId");

                    b.HasIndex("AddressId");

                    b.ToTable("CommodityOwner");
                });

            modelBuilder.Entity("truckapi.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("PlaceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlaceId");

                    b.HasIndex("AddressId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("truckapi.Models.Quotation", b =>
                {
                    b.Property<int>("QuotationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.HasKey("QuotationId");

                    b.HasIndex("DriverId");

                    b.HasIndex("RequestId");

                    b.ToTable("Quotation");
                });

            modelBuilder.Entity("truckapi.Models.Reciver", b =>
                {
                    b.Property<int>("ReciverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReciverId");

                    b.HasIndex("AddressId");

                    b.ToTable("Reciver");
                });

            modelBuilder.Entity("truckapi.Models.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommodityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CommodityOwnerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReciverId")
                        .HasColumnType("int");

                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusId1")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ValidDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("RequestId");

                    b.HasIndex("CommodityOwnerId");

                    b.HasIndex("ReciverId");

                    b.HasIndex("StatusId1");

                    b.HasIndex("UserId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("truckapi.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("truckapi.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Color = "0xffffeb3b",
                            Value = "Chờ báo giá"
                        },
                        new
                        {
                            StatusId = 2,
                            Color = "0xff2196f3",
                            Value = "Đang vận chuyển"
                        },
                        new
                        {
                            StatusId = 3,
                            Color = "0xff66bb6a",
                            Value = "Hoàn thành"
                        },
                        new
                        {
                            StatusId = 4,
                            Color = "0xfff44336",
                            Value = "Đã hủy"
                        });
                });

            modelBuilder.Entity("truckapi.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("truckapi.Models.CommodityOwner", b =>
                {
                    b.HasOne("truckapi.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("truckapi.Models.Place", b =>
                {
                    b.HasOne("truckapi.Models.Address", "Address")
                        .WithMany("Places")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("truckapi.Models.Quotation", b =>
                {
                    b.HasOne("truckapi.Models.User", "Driver")
                        .WithMany("Quotations")
                        .HasForeignKey("DriverId");

                    b.HasOne("truckapi.Models.Request", "Request")
                        .WithMany("Quotations")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("truckapi.Models.Reciver", b =>
                {
                    b.HasOne("truckapi.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("truckapi.Models.Request", b =>
                {
                    b.HasOne("truckapi.Models.CommodityOwner", "CommodityOwner")
                        .WithMany("Requests")
                        .HasForeignKey("CommodityOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("truckapi.Models.Reciver", "Reciver")
                        .WithMany("Requests")
                        .HasForeignKey("ReciverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("truckapi.Models.Status", "Status")
                        .WithMany("Requests")
                        .HasForeignKey("StatusId1");

                    b.HasOne("truckapi.Models.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("truckapi.Models.User", b =>
                {
                    b.HasOne("truckapi.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
