using OAuthExample.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OAuthExample.Models;
using Microsoft.EntityFrameworkCore;
using OAuthExample.Data;

namespace OAuthExample.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Assignment2Context _appDbContext;
        public ProductRepository(Assignment2Context appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> Products => _appDbContext.Products.Include(c => c.ProductID);


        public Product GetProductById(int productId) => _appDbContext.Products.FirstOrDefault(p => p.ProductID == productId);
    }
}
