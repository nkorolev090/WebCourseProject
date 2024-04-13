﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ModelAutoService))]
    partial class ModelAutoServiceModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DomainModel.Breakdown", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Info")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("info");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("title");

                    b.Property<int>("Warranty")
                        .HasColumnType("int")
                        .HasColumnName("warranty");

                    b.HasKey("Id");

                    b.ToTable("Breakdown", (string)null);
                });

            modelBuilder.Entity("DomainModel.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("brand");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("color");

                    b.Property<int>("Mileage")
                        .HasColumnType("int")
                        .HasColumnName("mileage");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("model");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int")
                        .HasColumnName("owner_id");

                    b.HasKey("Id")
                        .HasName("PK_CAR");

                    b.HasIndex("OwnerId");

                    b.ToTable("Car", (string)null);
                });

            modelBuilder.Entity("DomainModel.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int")
                        .HasColumnName("discount_id");

                    b.Property<int>("DiscountPoints")
                        .HasColumnType("int")
                        .HasColumnName("discount_points");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("DomainModel.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("Sale")
                        .HasColumnType("int")
                        .HasColumnName("sale");

                    b.HasKey("Id");

                    b.ToTable("Discount", (string)null);
                });

            modelBuilder.Entity("DomainModel.Mechanic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("full_name");

                    b.HasKey("Id");

                    b.ToTable("Mechanic", (string)null);
                });

            modelBuilder.Entity("DomainModel.MechanicBreakdown", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BreakdownId")
                        .HasColumnType("int")
                        .HasColumnName("breakdown_id");

                    b.Property<int>("MechanicId")
                        .HasColumnType("int")
                        .HasColumnName("mechanic_id");

                    b.HasKey("Id");

                    b.HasIndex("BreakdownId");

                    b.HasIndex("MechanicId");

                    b.ToTable("Mechanic-Breakdown", (string)null);
                });

            modelBuilder.Entity("DomainModel.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int")
                        .HasColumnName("car_id");

                    b.Property<string>("Info")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("info");

                    b.Property<DateTime?>("RegDate")
                        .HasColumnType("date")
                        .HasColumnName("reg_date");

                    b.Property<int?>("RegPrice")
                        .HasColumnType("int")
                        .HasColumnName("reg_price");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("Status");

                    b.ToTable("Registration", (string)null);
                });

            modelBuilder.Entity("DomainModel.Slot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BreakdownId")
                        .HasColumnType("int")
                        .HasColumnName("breakdown_id");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("date")
                        .HasColumnName("finish_date");

                    b.Property<TimeSpan>("FinishTime")
                        .HasPrecision(0)
                        .HasColumnType("time(0)")
                        .HasColumnName("finish_time");

                    b.Property<int>("MechanicId")
                        .HasColumnType("int")
                        .HasColumnName("mechanic_id");

                    b.Property<int?>("RegistrationId")
                        .HasColumnType("int")
                        .HasColumnName("registration_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.Property<TimeSpan>("StartTime")
                        .HasPrecision(0)
                        .HasColumnType("time(0)")
                        .HasColumnName("start_time");

                    b.HasKey("Id");

                    b.HasIndex("BreakdownId");

                    b.HasIndex("MechanicId");

                    b.HasIndex("RegistrationId");

                    b.ToTable("Slot", (string)null);
                });

            modelBuilder.Entity("DomainModel.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("DomainModel.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("MechanicId")
                        .HasColumnType("int");

                    b.Property<string>("Midname")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("midname");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

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

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("surname");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("MechanicId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DomainModel.Car", b =>
                {
                    b.HasOne("DomainModel.Client", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerId")
                        .IsRequired()
                        .HasConstraintName("FK_CAR_Client");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DomainModel.Client", b =>
                {
                    b.HasOne("DomainModel.Discount", "Discount")
                        .WithMany("Clients")
                        .HasForeignKey("DiscountId")
                        .IsRequired()
                        .HasConstraintName("FK_Client_Discount");

                    b.Navigation("Discount");
                });

            modelBuilder.Entity("DomainModel.MechanicBreakdown", b =>
                {
                    b.HasOne("DomainModel.Breakdown", "Breakdown")
                        .WithMany("MechanicBreakdowns")
                        .HasForeignKey("BreakdownId")
                        .IsRequired()
                        .HasConstraintName("FK_Mechanic-Breakdown_Breakdown");

                    b.HasOne("DomainModel.Mechanic", "Mechanic")
                        .WithMany("MechanicBreakdowns")
                        .HasForeignKey("MechanicId")
                        .IsRequired()
                        .HasConstraintName("FK_Mechanic-Breakdown_Mechanic");

                    b.Navigation("Breakdown");

                    b.Navigation("Mechanic");
                });

            modelBuilder.Entity("DomainModel.Registration", b =>
                {
                    b.HasOne("DomainModel.Car", "Car")
                        .WithMany("Registrations")
                        .HasForeignKey("CarId")
                        .IsRequired()
                        .HasConstraintName("FK_Registration_CAR");

                    b.HasOne("DomainModel.Status", "StatusNavigation")
                        .WithMany("Registrations")
                        .HasForeignKey("Status")
                        .IsRequired()
                        .HasConstraintName("FK_Registration_Status");

                    b.Navigation("Car");

                    b.Navigation("StatusNavigation");
                });

            modelBuilder.Entity("DomainModel.Slot", b =>
                {
                    b.HasOne("DomainModel.Breakdown", "Breakdown")
                        .WithMany("Slots")
                        .HasForeignKey("BreakdownId")
                        .HasConstraintName("FK_Slot_Breakdown");

                    b.HasOne("DomainModel.Mechanic", "Mechanic")
                        .WithMany("Slots")
                        .HasForeignKey("MechanicId")
                        .IsRequired()
                        .HasConstraintName("FK_Slot_Mechanic");

                    b.HasOne("DomainModel.Registration", "Registration")
                        .WithMany("Slots")
                        .HasForeignKey("RegistrationId")
                        .HasConstraintName("FK_Slot_Registration");

                    b.Navigation("Breakdown");

                    b.Navigation("Mechanic");

                    b.Navigation("Registration");
                });

            modelBuilder.Entity("DomainModel.User", b =>
                {
                    b.HasOne("DomainModel.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModel.Mechanic", "Mechanic")
                        .WithMany()
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Client");

                    b.Navigation("Mechanic");
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
                    b.HasOne("DomainModel.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DomainModel.User", null)
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

                    b.HasOne("DomainModel.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DomainModel.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomainModel.Breakdown", b =>
                {
                    b.Navigation("MechanicBreakdowns");

                    b.Navigation("Slots");
                });

            modelBuilder.Entity("DomainModel.Car", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("DomainModel.Client", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("DomainModel.Discount", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("DomainModel.Mechanic", b =>
                {
                    b.Navigation("MechanicBreakdowns");

                    b.Navigation("Slots");
                });

            modelBuilder.Entity("DomainModel.Registration", b =>
                {
                    b.Navigation("Slots");
                });

            modelBuilder.Entity("DomainModel.Status", b =>
                {
                    b.Navigation("Registrations");
                });
#pragma warning restore 612, 618
        }
    }
}
