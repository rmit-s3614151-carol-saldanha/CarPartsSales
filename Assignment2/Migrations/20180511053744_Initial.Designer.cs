﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OAuthExample.Data;
using System;

namespace Assignment2.Migrations
{
    [DbContext(typeof(Assignment2Context))]
    [Migration("20180511053744_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OAuthExample.Models.OwnerInventory", b =>
                {
                    b.Property<int>("ProductID");

                    b.Property<int>("StockLevel");

                    b.HasKey("ProductID");

                    b.ToTable("OwnerInventory");
                });

            modelBuilder.Entity("OAuthExample.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OAuthExample.Models.StockRequest", b =>
                {
                    b.Property<int>("StockRequestID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductID");

                    b.Property<int>("Quantity");

                    b.Property<int>("StoreID");

                    b.HasKey("StockRequestID");

                    b.HasIndex("ProductID");

                    b.HasIndex("StoreID");

                    b.ToTable("StockRequests");
                });

            modelBuilder.Entity("OAuthExample.Models.Store", b =>
                {
                    b.Property<int>("StoreID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("StoreID");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("OAuthExample.Models.StoreInventory", b =>
                {
                    b.Property<int>("StoreID");

                    b.Property<int>("ProductID");

                    b.Property<int>("StockLevel");

                    b.HasKey("StoreID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("StoreInventory");
                });

            modelBuilder.Entity("OAuthExample.Models.OwnerInventory", b =>
                {
                    b.HasOne("OAuthExample.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OAuthExample.Models.StockRequest", b =>
                {
                    b.HasOne("OAuthExample.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OAuthExample.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OAuthExample.Models.StoreInventory", b =>
                {
                    b.HasOne("OAuthExample.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OAuthExample.Models.Store", "Store")
                        .WithMany("StoreInventory")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}