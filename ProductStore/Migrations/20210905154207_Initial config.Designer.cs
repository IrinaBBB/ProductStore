﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductStore.Data;

namespace ProductStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210905154207_Initial config")]
    partial class Initialconfig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductStore.Models.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Category = "Verktøy",
                            Name = "Hammer",
                            Price = 121.50m
                        },
                        new
                        {
                            ProductId = 2,
                            Category = "Verktøy",
                            Name = "Vinkelsliper",
                            Price = 1520.00m
                        },
                        new
                        {
                            ProductId = 3,
                            Category = "Dagligvarer",
                            Name = "Melk",
                            Price = 14.50m
                        },
                        new
                        {
                            ProductId = 4,
                            Category = "Dagligvarer",
                            Name = "Kjøttkaker",
                            Price = 32.00m
                        },
                        new
                        {
                            ProductId = 5,
                            Category = "Dagligvarer",
                            Name = "Brød",
                            Price = 25.50m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
