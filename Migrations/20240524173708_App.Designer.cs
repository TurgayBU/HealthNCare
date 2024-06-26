﻿// <auto-generated />
using System;
using HealthNCare.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthNCare.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240524173708_App")]
    partial class App
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("HealthNCare.Areas.Identity.Data.Patients1", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("HealthNCare.Models.AppointmentDate", b =>
                {
                    b.Property<string>("AppointmentDateId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AppointmentDateId");

                    b.HasIndex("DoctorId");

                    b.ToTable("AppointmentDates");
                });

            modelBuilder.Entity("HealthNCare.Models.AppointmentRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AppointmentDateId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AppointmentTimeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HospitalId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Patients1Id")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentDateId");

                    b.HasIndex("AppointmentTimeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("HospitalId");

                    b.HasIndex("LocationId");

                    b.HasIndex("Patients1Id");

                    b.ToTable("AppointmentRecords");
                });

            modelBuilder.Entity("HealthNCare.Models.AppointmentTime", b =>
                {
                    b.Property<string>("AppointmentTimeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("AppointmentDateId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("AppointmentTimeId");

                    b.HasIndex("AppointmentDateId");

                    b.ToTable("AppointmentTimes");
                });

            modelBuilder.Entity("HealthNCare.Models.Department", b =>
                {
                    b.Property<string>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("HospitalId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DepartmentId");

                    b.HasIndex("HospitalId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HealthNCare.Models.Doctor", b =>
                {
                    b.Property<string>("DoctorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DoctorId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HealthNCare.Models.Hospital", b =>
                {
                    b.Property<string>("HospitalId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("HospitalId");

                    b.HasIndex("LocationId");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("HealthNCare.Models.Location", b =>
                {
                    b.Property<string>("LocationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HealthNCare.Models.AppointmentDate", b =>
                {
                    b.HasOne("HealthNCare.Models.Doctor", "Doctor")
                        .WithMany("AppointmentDates")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("HealthNCare.Models.AppointmentRecord", b =>
                {
                    b.HasOne("HealthNCare.Models.AppointmentDate", "AppointmentDate")
                        .WithMany("AppointmentRecords")
                        .HasForeignKey("AppointmentDateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthNCare.Models.AppointmentTime", "AppointmentTime")
                        .WithMany("AppointmentRecords")
                        .HasForeignKey("AppointmentTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthNCare.Models.Department", "Department")
                        .WithMany("AppointmentRecords")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthNCare.Models.Doctor", "Doctor")
                        .WithMany("AppointmentRecords")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthNCare.Models.Hospital", "Hospital")
                        .WithMany("AppointmentRecords")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthNCare.Models.Location", "Location")
                        .WithMany("AppointmentRecords")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthNCare.Areas.Identity.Data.Patients1", "Patients1")
                        .WithMany()
                        .HasForeignKey("Patients1Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AppointmentDate");

                    b.Navigation("AppointmentTime");

                    b.Navigation("Department");

                    b.Navigation("Doctor");

                    b.Navigation("Hospital");

                    b.Navigation("Location");

                    b.Navigation("Patients1");
                });

            modelBuilder.Entity("HealthNCare.Models.AppointmentTime", b =>
                {
                    b.HasOne("HealthNCare.Models.AppointmentDate", "AppointmentDate")
                        .WithMany("AppointmentTimes")
                        .HasForeignKey("AppointmentDateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentDate");
                });

            modelBuilder.Entity("HealthNCare.Models.Department", b =>
                {
                    b.HasOne("HealthNCare.Models.Hospital", "Hospital")
                        .WithMany("Departments")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("HealthNCare.Models.Doctor", b =>
                {
                    b.HasOne("HealthNCare.Models.Department", "Department")
                        .WithMany("Doctors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HealthNCare.Models.Hospital", b =>
                {
                    b.HasOne("HealthNCare.Models.Location", "Location")
                        .WithMany("Hospitals")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
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
                    b.HasOne("HealthNCare.Areas.Identity.Data.Patients1", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HealthNCare.Areas.Identity.Data.Patients1", null)
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

                    b.HasOne("HealthNCare.Areas.Identity.Data.Patients1", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HealthNCare.Areas.Identity.Data.Patients1", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthNCare.Models.AppointmentDate", b =>
                {
                    b.Navigation("AppointmentRecords");

                    b.Navigation("AppointmentTimes");
                });

            modelBuilder.Entity("HealthNCare.Models.AppointmentTime", b =>
                {
                    b.Navigation("AppointmentRecords");
                });

            modelBuilder.Entity("HealthNCare.Models.Department", b =>
                {
                    b.Navigation("AppointmentRecords");

                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("HealthNCare.Models.Doctor", b =>
                {
                    b.Navigation("AppointmentDates");

                    b.Navigation("AppointmentRecords");
                });

            modelBuilder.Entity("HealthNCare.Models.Hospital", b =>
                {
                    b.Navigation("AppointmentRecords");

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("HealthNCare.Models.Location", b =>
                {
                    b.Navigation("AppointmentRecords");

                    b.Navigation("Hospitals");
                });
#pragma warning restore 612, 618
        }
    }
}
