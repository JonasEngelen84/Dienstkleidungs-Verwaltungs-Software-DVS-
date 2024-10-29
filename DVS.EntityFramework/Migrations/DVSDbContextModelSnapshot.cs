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

                    b.HasData(
                        new
                        {
                            GuidID = new Guid("8fa99cb7-2768-4425-a867-8e5f9af2c0a7"),
                            Name = "-Kategorielos-"
                        },
                        new
                        {
                            GuidID = new Guid("f18ffeef-f865-4b96-8a54-700668e3231f"),
                            Name = "Handschuhe"
                        },
                        new
                        {
                            GuidID = new Guid("6d99df2f-ae25-453e-9ddc-db137ba355ef"),
                            Name = "Hemd"
                        },
                        new
                        {
                            GuidID = new Guid("d312da04-7adb-43b3-b06d-666d365378e2"),
                            Name = "Hose"
                        },
                        new
                        {
                            GuidID = new Guid("41950fdb-c8d8-4212-bc19-c8a2db1947c8"),
                            Name = "Jacke"
                        },
                        new
                        {
                            GuidID = new Guid("e15ed144-3a26-47f7-8e37-cef2b6c0af02"),
                            Name = "Kopfbedeckung"
                        },
                        new
                        {
                            GuidID = new Guid("f503e475-ecfe-41d8-a428-e50d95e6c020"),
                            Name = "Pullover"
                        },
                        new
                        {
                            GuidID = new Guid("a5590588-b87a-4097-8882-3839e3c9a33e"),
                            Name = "Schuhwerk"
                        },
                        new
                        {
                            GuidID = new Guid("cde7cce7-0f42-4a71-aa08-ff081caaff66"),
                            Name = "Shirt"
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
                            GuidID = new Guid("f880adef-9443-4267-a481-0a508832337d"),
                            Name = "-Saisonlos-"
                        },
                        new
                        {
                            GuidID = new Guid("f6935950-0bef-4b65-97e7-d0be6d211bda"),
                            Name = "Sommer"
                        },
                        new
                        {
                            GuidID = new Guid("8b7bcb99-e930-4b87-9f22-c95851768b0d"),
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
                            GuidID = new Guid("7f3c5678-d81b-4c24-a4ed-42f49276980c"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "44"
                        },
                        new
                        {
                            GuidID = new Guid("9ac6bccc-d7ac-4065-b7bc-7221cc3c4a6b"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "46"
                        },
                        new
                        {
                            GuidID = new Guid("069fc08a-7fb5-4186-a354-ae04ba323c5f"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "48"
                        },
                        new
                        {
                            GuidID = new Guid("8bea5e4c-f6a5-4155-b444-36e54132c9d0"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "50"
                        },
                        new
                        {
                            GuidID = new Guid("ce89381f-4962-4747-aad7-148acd1b7e91"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "52"
                        },
                        new
                        {
                            GuidID = new Guid("a4af240f-2ba9-48c7-9f6a-2f4b717e5bd5"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "54"
                        },
                        new
                        {
                            GuidID = new Guid("fb444f83-9105-4581-adb1-473e7b002ea8"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "56"
                        },
                        new
                        {
                            GuidID = new Guid("5d707730-97c8-4ebd-abd4-98e6d01378ee"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "58"
                        },
                        new
                        {
                            GuidID = new Guid("a107cb86-c893-46b0-a777-49ec49583e1f"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "60"
                        },
                        new
                        {
                            GuidID = new Guid("4a4da98c-e5e9-4a54-ae56-ddaa70b45fa9"),
                            IsSelected = false,
                            IsSizeSystemEU = true,
                            Quantity = 0,
                            Size = "62"
                        },
                        new
                        {
                            GuidID = new Guid("4dd5978d-f378-40c9-8570-3750c300f565"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "XS"
                        },
                        new
                        {
                            GuidID = new Guid("8b956627-e921-40dd-bf0a-7aa9e447583c"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "S"
                        },
                        new
                        {
                            GuidID = new Guid("80dcb7af-117b-44dd-b9f6-30c3f4683337"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "M"
                        },
                        new
                        {
                            GuidID = new Guid("e6616e1e-4d8a-4c8a-bba1-f07fb2f46e9d"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "L"
                        },
                        new
                        {
                            GuidID = new Guid("354871e6-787b-47a6-9bf3-13b8a5279274"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "XL"
                        },
                        new
                        {
                            GuidID = new Guid("a981d7ba-afa8-4b86-8b16-1b897936b1fe"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "XLL"
                        },
                        new
                        {
                            GuidID = new Guid("c889d6e8-cf43-4441-aa0d-92cac46d3a57"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "3XL"
                        },
                        new
                        {
                            GuidID = new Guid("9fe7bed4-5536-46eb-9354-8b7f91d7fea6"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "4XL"
                        },
                        new
                        {
                            GuidID = new Guid("b79dfe44-f682-48b9-a595-916e7376829d"),
                            IsSelected = false,
                            IsSizeSystemEU = false,
                            Quantity = 0,
                            Size = "5XL"
                        },
                        new
                        {
                            GuidID = new Guid("211c1c92-80c2-4797-9bf0-dda630ade611"),
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
