﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SlimFormaturas.Infra.Data.Context;

namespace SlimFormaturas.Infra.Data.Migrations
{
    [DbContext(typeof(MssqlContext))]
    [Migration("20191222133435_7")]
    partial class _7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SlimFormaturas.Domain.Entities.Address", b =>
                {
                    b.Property<string>("AddressId")
                        .HasColumnName("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Complement")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("GraduateId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("TypeGenericId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("AddressId");

                    b.HasIndex("GraduateId");

                    b.HasIndex("TypeGenericId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SlimFormaturas.Domain.Entities.Graduate", b =>
                {
                    b.Property<string>("GraduateId")
                        .HasColumnName("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Agency")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CheckingAccount")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("Committee")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("DadName")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("MotherName")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Photo")
                        .HasColumnType("varchar")
                        .HasMaxLength(255);

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.HasKey("GraduateId");

                    b.HasIndex("UserId");

                    b.ToTable("Graduate");
                });

            modelBuilder.Entity("SlimFormaturas.Domain.Entities.Phone", b =>
                {
                    b.Property<string>("PhoneId")
                        .HasColumnName("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ddd")
                        .IsRequired()
                        .HasColumnName("DDD")
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("GraduateId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnName("PhoneNumber")
                        .HasColumnType("varchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("TypeGenericId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PhoneId");

                    b.HasIndex("GraduateId");

                    b.HasIndex("TypeGenericId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("SlimFormaturas.Domain.Entities.TypeGeneric", b =>
                {
                    b.Property<string>("TypeGenericId")
                        .HasColumnName("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<int>("Localization")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TypeGenericId");

                    b.ToTable("TypeGeneric");
                });

            modelBuilder.Entity("SlimFormaturas.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("datetime2");

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
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SlimFormaturas.Domain.Entities.Address", b =>
                {
                    b.HasOne("SlimFormaturas.Domain.Entities.Graduate", "Graduate")
                        .WithMany("Address")
                        .HasForeignKey("GraduateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SlimFormaturas.Domain.Entities.TypeGeneric", "TypeGeneric")
                        .WithMany()
                        .HasForeignKey("TypeGenericId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SlimFormaturas.Domain.Entities.Graduate", b =>
                {
                    b.HasOne("SlimFormaturas.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SlimFormaturas.Domain.Entities.Phone", b =>
                {
                    b.HasOne("SlimFormaturas.Domain.Entities.Graduate", "Graduate")
                        .WithMany("Phone")
                        .HasForeignKey("GraduateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SlimFormaturas.Domain.Entities.TypeGeneric", "TypeGeneric")
                        .WithMany()
                        .HasForeignKey("TypeGenericId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
