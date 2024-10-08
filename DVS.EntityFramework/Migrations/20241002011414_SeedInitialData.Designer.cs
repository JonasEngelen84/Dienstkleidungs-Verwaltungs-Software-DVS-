﻿// <auto-generated />
using System;
using DVS.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DVS.EntityFramework.Migrations
{
    [DbContext(typeof(DVSDbContext))]
    [Migration("20241002011414_SeedInitialData")]
    partial class SeedInitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            GuidID = new Guid("1f3d145f-a59d-4976-adfa-8f1691855035"),
                            Name = "Kategorielos"
                        },
                        new
                        {
                            GuidID = new Guid("0f16b995-1a67-449d-bc1d-c52fef0a9bd3"),
                            Name = "Hose"
                        },
                        new
                        {
                            GuidID = new Guid("b8f64a16-9ce5-45e4-9b17-5e28b6455cdd"),
                            Name = "Shirt"
                        },
                        new
                        {
                            GuidID = new Guid("0b1154bb-6cf3-4e5c-a1ec-7584695239ed"),
                            Name = "Hemd"
                        },
                        new
                        {
                            GuidID = new Guid("86f81a83-b27d-4355-986a-8dd92558be9c"),
                            Name = "Pullover"
                        },
                        new
                        {
                            GuidID = new Guid("6d50c10c-5b2d-4084-b0a6-65b9202bb0ab"),
                            Name = "Jacke"
                        },
                        new
                        {
                            GuidID = new Guid("bdbe22ef-3dd4-47e8-92d0-de539e458a60"),
                            Name = "Schuhe"
                        },
                        new
                        {
                            GuidID = new Guid("4fca12e3-24aa-49b6-8212-28740aeb71d3"),
                            Name = "Handschuhe"
                        },
                        new
                        {
                            GuidID = new Guid("46a321a2-42d0-45ef-8517-dd4f682469a2"),
                            Name = "Kopbedeckung"
                        });
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

                    b.HasData(
                        new
                        {
                            GuidID = new Guid("aa3a10cf-d490-4f6b-af90-db911216c1b1"),
                            Name = "Saisonlos"
                        },
                        new
                        {
                            GuidID = new Guid("bf06d31e-d6c6-40aa-8f05-4dc86d073d2a"),
                            Name = "Sommer"
                        },
                        new
                        {
                            GuidID = new Guid("93851660-0139-4756-9a37-129b22647992"),
                            Name = "Winter"
                        });
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

                    b.HasData(
                        new
                        {
                            GuidID = new Guid("8e9d5411-3a73-4d52-9f62-7a5c8d329126"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "44"
                        },
                        new
                        {
                            GuidID = new Guid("600d98f2-213f-4771-86a7-4f9428c3f8c7"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "46"
                        },
                        new
                        {
                            GuidID = new Guid("f062f06d-981d-4947-879a-644aa17cbe89"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "48"
                        },
                        new
                        {
                            GuidID = new Guid("2bdca90f-8850-4693-b5c6-d323e5fe1ab6"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "50"
                        },
                        new
                        {
                            GuidID = new Guid("0e22ef86-0e65-4fa0-a703-caa50cd1c9ed"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "52"
                        },
                        new
                        {
                            GuidID = new Guid("2c636d16-c18a-4d87-bf0c-c840024bf29e"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "54"
                        },
                        new
                        {
                            GuidID = new Guid("264b7fc2-080e-4337-8aa9-6d271a8b3f83"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "56"
                        },
                        new
                        {
                            GuidID = new Guid("0c936ca8-a6c0-44ee-92d8-9c3806292ba1"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "58"
                        },
                        new
                        {
                            GuidID = new Guid("91213878-8115-4236-b771-a019b107382a"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "60"
                        },
                        new
                        {
                            GuidID = new Guid("588319aa-0238-4dfc-a43c-32c002a00dd4"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "62"
                        },
                        new
                        {
                            GuidID = new Guid("76032b2b-dc06-4015-84ed-127c63949ab6"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "XS"
                        },
                        new
                        {
                            GuidID = new Guid("55e16509-6b5b-4458-8e6a-e2019b9c1747"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "S"
                        },
                        new
                        {
                            GuidID = new Guid("1846e7a5-5a61-4cb6-9189-39388c331e51"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "M"
                        },
                        new
                        {
                            GuidID = new Guid("13184e9c-4e62-4357-8622-557dae0609c8"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "L"
                        },
                        new
                        {
                            GuidID = new Guid("9d6996dd-94b0-4566-a883-678e393e2ecc"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "XL"
                        },
                        new
                        {
                            GuidID = new Guid("353cd701-422d-4b47-bc60-01d639a6463b"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "XLL"
                        },
                        new
                        {
                            GuidID = new Guid("61818548-e475-49e9-9d19-20ad36152307"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "3XL"
                        },
                        new
                        {
                            GuidID = new Guid("a0895bed-f36f-4a17-9245-793ad846035e"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "4XL"
                        },
                        new
                        {
                            GuidID = new Guid("29cd869f-ee39-4078-8d7a-86761ede436d"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "5XL"
                        },
                        new
                        {
                            GuidID = new Guid("a021d9a8-c62c-4660-a28c-5e5108573ec3"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "6XL"
                        });
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
