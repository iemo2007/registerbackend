﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registration.Persistence;

#nullable disable

namespace Registration.Persistence.Migrations
{
    [DbContext(typeof(RegistrationContext))]
    partial class RegistrationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Registration.Domain.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id")
                        .HasName("PK_Account_Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("UQ_Account_Email");

                    b.HasIndex("MobileNumber")
                        .IsUnique()
                        .HasDatabaseName("UQ_Account_MobileNumber");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Registration.Domain.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlatNumber")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id")
                        .HasName("PK_Address_Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CityId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("Registration.Domain.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GovernateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_City_Id");

                    b.HasIndex("GovernateId");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("Registration.Domain.Governate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Governate_Id");

                    b.ToTable("Governate", (string)null);
                });

            modelBuilder.Entity("Registration.Domain.GovernateCount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GovernateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_GovernateCount_Id");

                    b.HasIndex("GovernateId")
                        .IsUnique();

                    b.ToTable("GovernateCount", (string)null);
                });

            modelBuilder.Entity("Registration.Domain.Address", b =>
                {
                    b.HasOne("Registration.Domain.Account", "Account")
                        .WithMany("Addresses")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Address_AccountId");

                    b.HasOne("Registration.Domain.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Registration.Domain.City", b =>
                {
                    b.HasOne("Registration.Domain.Governate", "Governate")
                        .WithMany("Cities")
                        .HasForeignKey("GovernateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_City_GovernateId");

                    b.Navigation("Governate");
                });

            modelBuilder.Entity("Registration.Domain.GovernateCount", b =>
                {
                    b.HasOne("Registration.Domain.Governate", "Governate")
                        .WithOne()
                        .HasForeignKey("Registration.Domain.GovernateCount", "GovernateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_GovernateCount_GovernateId");

                    b.Navigation("Governate");
                });

            modelBuilder.Entity("Registration.Domain.Account", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Registration.Domain.Governate", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
