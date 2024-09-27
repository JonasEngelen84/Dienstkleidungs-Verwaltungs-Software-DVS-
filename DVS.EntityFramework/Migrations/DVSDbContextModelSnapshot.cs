﻿// <auto-generated />
using System;
using DVS.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DVS.EntityFramework.Migrations
{
    [DbContext(typeof(DVSDbContext))]
    partial class DVSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("DVS.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("GuidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GuidID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DVS.Domain.Models.Clothes", b =>
                {
                    b.Property<Guid>("GuidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CategoryGuidID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SeasonGuidID")
                        .HasColumnType("TEXT");

                    b.HasKey("GuidID");

                    b.HasIndex("CategoryGuidID");

                    b.HasIndex("SeasonGuidID");

                    b.ToTable("Clothes");
                });

            modelBuilder.Entity("DVS.Domain.Models.ClothesSize", b =>
                {
                    b.Property<Guid>("GuidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClothesGuidID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SizeGuidID")
                        .HasColumnType("TEXT");

                    b.HasKey("GuidID");

                    b.HasIndex("ClothesGuidID");

                    b.HasIndex("SizeGuidID");

                    b.ToTable("ClothesSizes");
                });

            modelBuilder.Entity("DVS.Domain.Models.Employee", b =>
                {
                    b.Property<Guid>("GuidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GuidID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DVS.Domain.Models.EmployeeClothesSize", b =>
                {
                    b.Property<Guid>("GuidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClothesSizeGuidID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmployeeGuidID")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("GuidID");

                    b.HasIndex("ClothesSizeGuidID");

                    b.HasIndex("EmployeeGuidID");

                    b.ToTable("EmployeeClothesSizes");
                });

            modelBuilder.Entity("DVS.Domain.Models.Season", b =>
                {
                    b.Property<Guid>("GuidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GuidID");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("DVS.Domain.Models.SizeModel", b =>
                {
                    b.Property<Guid>("GuidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSizeSystemEU")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GuidID");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("DVS.Domain.Models.Clothes", b =>
                {
                    b.HasOne("DVS.Domain.Models.Category", "Category")
                        .WithMany("Clothes")
                        .HasForeignKey("CategoryGuidID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DVS.Domain.Models.Season", "Season")
                        .WithMany("Clothes")
                        .HasForeignKey("SeasonGuidID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("DVS.Domain.Models.ClothesSize", b =>
                {
                    b.HasOne("DVS.Domain.Models.Clothes", "Clothes")
                        .WithMany("Sizes")
                        .HasForeignKey("ClothesGuidID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DVS.Domain.Models.SizeModel", "Size")
                        .WithMany("ClothesSizes")
                        .HasForeignKey("SizeGuidID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clothes");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("DVS.Domain.Models.EmployeeClothesSize", b =>
                {
                    b.HasOne("DVS.Domain.Models.ClothesSize", "ClothesSize")
                        .WithMany("EmployeeClothesSizes")
                        .HasForeignKey("ClothesSizeGuidID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DVS.Domain.Models.Employee", "Employee")
                        .WithMany("Clothes")
                        .HasForeignKey("EmployeeGuidID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClothesSize");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DVS.Domain.Models.Category", b =>
                {
                    b.Navigation("Clothes");
                });

            modelBuilder.Entity("DVS.Domain.Models.Clothes", b =>
                {
                    b.Navigation("Sizes");
                });

            modelBuilder.Entity("DVS.Domain.Models.ClothesSize", b =>
                {
                    b.Navigation("EmployeeClothesSizes");
                });

            modelBuilder.Entity("DVS.Domain.Models.Employee", b =>
                {
                    b.Navigation("Clothes");
                });

            modelBuilder.Entity("DVS.Domain.Models.Season", b =>
                {
                    b.Navigation("Clothes");
                });

            modelBuilder.Entity("DVS.Domain.Models.SizeModel", b =>
                {
                    b.Navigation("ClothesSizes");
                });
#pragma warning restore 612, 618
        }
    }
}
