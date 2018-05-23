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
    partial class Assignment2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OAuthExample.Models.Cart", b =>
                {
                    b.Property<int>("ShoppingCartItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int?>("ProductID");

                    b.Property<string>("ShoppingCartID");

                    b.HasKey("ShoppingCartItemID");

                    b.HasIndex("ProductID");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("OAuthExample.Models.CustomerOrder", b =>
                {
                    b.Property<int>("ReceiptID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email");

                    b.HasKey("ReceiptID");

                    b.ToTable("CustomerOrder");
                });

            modelBuilder.Entity("OAuthExample.Models.OrderHistory", b =>
                {
                    b.Property<int>("ReceiptID");

                    b.Property<string>("ProductName");

                    b.Property<string>("StoreName");

                    b.Property<string>("Image");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("ReceiptID", "ProductName", "StoreName");

                    b.ToTable("OrderHistory");
                });

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

            modelBuilder.Entity("OAuthExample.Models.Cart", b =>
                {
                    b.HasOne("OAuthExample.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("OAuthExample.Models.OrderHistory", b =>
                {
                    b.HasOne("OAuthExample.Models.CustomerOrder", "CustomerOrder")
                        .WithMany("OrderHistories")
                        .HasForeignKey("ReceiptID")
                        .OnDelete(DeleteBehavior.Cascade);
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
