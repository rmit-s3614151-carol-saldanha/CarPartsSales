using Microsoft.EntityFrameworkCore;
using OAuthExample.Models;
using OAuthExample.Models.ShoppingCartViewModels;

namespace OAuthExample.Data
{
    public class Assignment2Context : DbContext
    {
      
        public DbSet<Cart> ShoppingCartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<OwnerInventory> OwnerInventory { get; set; }
        public DbSet<StockRequest> StockRequests { get; set; }
        public DbSet<StoreInventory> StoreInventory { get; set; }
        public DbSet<CustomerOrder> CustomerOrder { get; set; }
        public DbSet<OrderHistory> OrderHistory { get; set; }


        public Assignment2Context(DbContextOptions<Assignment2Context> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreInventory>().HasKey(x => new { x.StoreID, x.ProductID });
            modelBuilder.Entity<OrderHistory>().HasKey(x => new { x.ReceiptID, x.ProductName, x.StoreName });

        }
    }
}
