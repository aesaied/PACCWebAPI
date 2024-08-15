﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreAPI.Entities;

#nullable disable

namespace StoreAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240814084352_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreAPI.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CatId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CatId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CatId = 1,
                            Name = "Samsung S24 Ultra"
                        },
                        new
                        {
                            Id = 2,
                            CatId = 2,
                            Name = "HP Laserjet 3025"
                        },
                        new
                        {
                            Id = 3,
                            CatId = 3,
                            Name = "HP ProBook 15588"
                        });
                });

            modelBuilder.Entity("StoreAPI.Entities.ProductCategory", b =>
                {
                    b.Property<int>("PCId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PCId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PCId");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            PCId = 1,
                            Name = "Mobiles"
                        },
                        new
                        {
                            PCId = 2,
                            Name = "Printers"
                        },
                        new
                        {
                            PCId = 3,
                            Name = "Computers"
                        });
                });

            modelBuilder.Entity("StoreAPI.Entities.Product", b =>
                {
                    b.HasOne("StoreAPI.Entities.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("StoreAPI.Entities.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}