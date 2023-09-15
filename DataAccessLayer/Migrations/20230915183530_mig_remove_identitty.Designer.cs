﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230915183530_mig_remove_identitty")]
    partial class mig_remove_identitty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntitiyLayer.Concrete.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandID"), 1L, 1);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("BrandStatus")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("BrandID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CategoryStatus")
                        .HasColumnType("bit");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Manager", b =>
                {
                    b.Property<int>("ManagerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManagerID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManagerID");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageID"), 1L, 1);

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MessageStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Message2", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageID"), 1L, 1);

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MessageStatus")
                        .HasColumnType("bit");

                    b.Property<int?>("ReceiverID")
                        .HasColumnType("int");

                    b.Property<int?>("SenderID")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageID");

                    b.HasIndex("ReceiverID");

                    b.HasIndex("SenderID");

                    b.ToTable("Message2s");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Model", b =>
                {
                    b.Property<int>("ModelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModelID"), 1L, 1);

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ModelStatus")
                        .HasColumnType("bit");

                    b.Property<int>("SeriesID")
                        .HasColumnType("int");

                    b.HasKey("ModelID");

                    b.HasIndex("SeriesID");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Notification", b =>
                {
                    b.Property<int>("NotificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationID"), 1L, 1);

                    b.Property<string>("NotificationColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NotificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NotificationDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NotificationStatus")
                        .HasColumnType("bit");

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotificationTypeSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificationID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Series", b =>
                {
                    b.Property<int>("SeriesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeriesID"), 1L, 1);

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<string>("SeriesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SeriesStatus")
                        .HasColumnType("bit");

                    b.HasKey("SeriesID");

                    b.HasIndex("BrandID");

                    b.ToTable("Seriess");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("UserMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UserStatus")
                        .HasColumnType("bit");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Vehicle", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleID"), 1L, 1);

                    b.Property<int>("ModelID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("VehicleAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VehicleAdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleBodyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleDistrict")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleEngineCapacity")
                        .HasColumnType("int");

                    b.Property<int>("VehicleEnginePower")
                        .HasColumnType("int");

                    b.Property<string>("VehicleExcangeable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleFuel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleGear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleKm")
                        .HasColumnType("int");

                    b.Property<decimal>("VehiclePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("VehicleStatus")
                        .HasColumnType("bit");

                    b.Property<string>("VehicleThumbnailImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleWarranty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleWheelDrive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleYear")
                        .HasColumnType("int");

                    b.HasKey("VehicleID");

                    b.HasIndex("ModelID");

                    b.HasIndex("UserID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Brand", b =>
                {
                    b.HasOne("EntitiyLayer.Concrete.Category", "Category")
                        .WithMany("Brands")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Message2", b =>
                {
                    b.HasOne("EntitiyLayer.Concrete.User", "ReceiverUser")
                        .WithMany("UserReceiver")
                        .HasForeignKey("ReceiverID");

                    b.HasOne("EntitiyLayer.Concrete.User", "SenderUser")
                        .WithMany("UserSender")
                        .HasForeignKey("SenderID");

                    b.Navigation("ReceiverUser");

                    b.Navigation("SenderUser");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Model", b =>
                {
                    b.HasOne("EntitiyLayer.Concrete.Series", "Series")
                        .WithMany("Models")
                        .HasForeignKey("SeriesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Series");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Series", b =>
                {
                    b.HasOne("EntitiyLayer.Concrete.Brand", "Brand")
                        .WithMany("Series")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Vehicle", b =>
                {
                    b.HasOne("EntitiyLayer.Concrete.Model", "Model")
                        .WithMany("Vehicles")
                        .HasForeignKey("ModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntitiyLayer.Concrete.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Brand", b =>
                {
                    b.Navigation("Series");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Category", b =>
                {
                    b.Navigation("Brands");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Model", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.Series", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("EntitiyLayer.Concrete.User", b =>
                {
                    b.Navigation("UserReceiver");

                    b.Navigation("UserSender");

                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}