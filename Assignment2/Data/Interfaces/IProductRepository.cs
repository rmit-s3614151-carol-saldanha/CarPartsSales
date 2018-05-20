using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OAuthExample.Models;
namespace Assignment2.Data.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        Product GetProductById(int drinkId);

    }
}
