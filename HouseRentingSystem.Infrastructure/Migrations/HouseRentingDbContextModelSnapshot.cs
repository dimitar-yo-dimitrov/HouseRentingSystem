﻿// <auto-generated />
using System;
using HouseRentingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    [DbContext(typeof(HouseRentingDbContext))]
    partial class HouseRentingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HouseRentingSystem.Infrastructure.Data.Entities.Agent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Agents");

                    b.HasData(
                        new
                        {
                            Id = "D00DD0BB-783B-4766-AF26-5958608A96FE",
                            PhoneNumber = "+359888888888",
                            UserId = "E305205E-A570-40AE-9644-D4E173B05D0D"
                        });
                });

            modelBuilder.Entity("HouseRentingSystem.Infrastructure.Data.Entities.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = "B3D23CE7-7A38-4E00-91E3-BD446A6C1033",
                            Name = "Cottage"
                        },
                        new
                        {
                            Id = "4FDD33D0-218F-4094-B1D4-707403A8ADD4",
                            Name = "Single-Family"
                        },
                        new
                        {
                            Id = "B8B55D74-60EB-4ED7-AC6D-AC75F4B31179",
                            Name = "Duplex"
                        });
                });

            modelBuilder.Entity("HouseRentingSystem.Infrastructure.Data.Entities.House", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("AgentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("PricePerMonth")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RenterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RenterId");

                    b.ToTable("Houses");

                    b.HasData(
                        new
                        {
                            Id = "3C3A02DC-DF00-47DA-B053-FB81BB714A90",
                            Address = "North London, UK (near the border)",
                            AgentId = "D00DD0BB-783B-4766-AF26-5958608A96FE",
                            CategoryId = "B8B55D74-60EB-4ED7-AC6D-AC75F4B31179",
                            Description = "A big house for your whole family. Don't miss to buy a house with three bedrooms.",
                            ImageUrl = "https://www.luxury-architecture.net/wp-content/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg",
                            IsActive = true,
                            PricePerMonth = 2100.00m,
                            RenterId = "AF724889-F204-4573-8D65-ED50557A9B71",
                            Title = "Big House Marina"
                        },
                        new
                        {
                            Id = "1DFB745D-E948-4375-81AC-3A86EBBFC237",
                            Address = "Near the Sea Garden in Burgas, Bulgaria",
                            AgentId = "D00DD0BB-783B-4766-AF26-5958608A96FE",
                            CategoryId = "4FDD33D0-218F-4094-B1D4-707403A8ADD4",
                            Description = "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.",
                            ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1",
                            IsActive = true,
                            PricePerMonth = 1200.00m,
                            Title = "Family House Comfort"
                        },
                        new
                        {
                            Id = "BF445967-EF66-41CC-BA39-462CBC7D24DE",
                            Address = "Boyana Neighbourhood, Sofia, Bulgaria",
                            AgentId = "D00DD0BB-783B-4766-AF26-5958608A96FE",
                            CategoryId = "4FDD33D0-218F-4094-B1D4-707403A8ADD4",
                            Description = "This luxurious house is everything you will need. It is just excellent.",
                            ImageUrl = "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg",
                            IsActive = true,
                            PricePerMonth = 2000.00m,
                            Title = "Grand House"
                        });
                });

            modelBuilder.Entity("HouseRentingSystem.Infrastructure.Data.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "E305205E-A570-40AE-9644-D4E173B05D0D",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "61e5de36-9f72-4245-985f-9beec84d6219",
                            Email = "agent@mail.com",
                            EmailConfirmed = false,
                            IsActive = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "agent@mail.com",
                            NormalizedUserName = "agent@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEH6UdjC31egpPKEFrAuSLu1yOAUnCLaoddmuR7kPME7COa7sEtFqtUNRvabeVcaQQw==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "agent@mail.com"
                        },
                        new
                        {
                            Id = "AF724889-F204-4573-8D65-ED50557A9B71",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "18b14a1f-c929-4f11-af8a-c1a8f0fbf21d",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            IsActive = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@mail.com",
                            NormalizedUserName = "guest@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAENeyfrq+DZ3kmC7o5Dgqaau1az70azkIwNVYjnHA7HiWViwu0q7nTa2RWQGhnWcLJg==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "guest@mail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HouseRentingSystem.Infrastructure.Data.Entities.Agent", b =>
                {
                    b.HasOne("HouseRentingSystem.Infrastructure.Data.Identity.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HouseRentingSystem.Infrastructure.Data.Entities.House", b =>
                {
                    b.HasOne("HouseRentingSystem.Infrastructure.Data.Entities.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseRentingSystem.Infrastructure.Data.Entities.Category", "Category")
                        .WithMany("Houses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseRentingSystem.Infrastructure.Data.Identity.ApplicationUser", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId");

                    b.Navigation("Agent");

                    b.Navigation("Category");

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HouseRentingSystem.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HouseRentingSystem.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseRentingSystem.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HouseRentingSystem.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HouseRentingSystem.Infrastructure.Data.Entities.Category", b =>
                {
                    b.Navigation("Houses");
                });
#pragma warning restore 612, 618
        }
    }
}
