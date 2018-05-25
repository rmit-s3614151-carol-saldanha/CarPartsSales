using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OAuthExample.Models;
using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace OAuthExample.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { Constants.CustomerRole, Constants.FranchiseRole };
            foreach(var role in roles)
            {
                if(!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            await EnsureUserHasRole(userManager, "carolsaldanha26@gmail.com", Constants.CustomerRole);
            await EnsureUserHasRole(userManager, "s3614151@student.rmit.edu.au", Constants.FranchiseRole);
            await EnsureUserHasRole(userManager, "CSaldanha@Panviva.com", Constants.Owner);

            using (var context = new Assignment2Context(
                serviceProvider.GetRequiredService<DbContextOptions<Assignment2Context>>()))
            {
                // Look for any products.
                if (context.Products.Any())
                {
                    return; // DB has been seeded.
                }

                var products = new[]
                {
                    new Product
                    {
                        Name = "Volkswagen",
                        Image = "~/images/Volkswagen.jpg",
                        Price = 1.00
                    },
                    new Product
                    {
                        Name = "Ford",
                        Image = "~/images/Ford.jpg",
                        Price = 150.00
                    },
                    new Product
                    {
                        Name = "Mitsubishi",
                        Image = "~/images/Mitsubishi.jpg",
                        Price = 1.50
                    },
                    new Product
                    {
                        Name = "Toyota",
                        Image = "~/images/Toyota.png",
                        Price = 180.60
                    },
                    new Product
                    {
                        Name = "Mazda",

                        Image = "~/images/Mazda.jpg",
                        Price = 0.80
                    },
                    new Product
                    {
                        Name = "Nissan",
                        Image = "~/images/Nissan.jpg",
                        Price = 450.57
                    },
                    new Product
                    {
                        Name = "Hyundai",
                        Image = "~/images/Hyundai.jpg",
                        Price = 1.60
                    },
                    new Product
                    {
                        Name = "Audi",
                        Image = "~/images/Audi.jpg",
                        Price = 560.96
                    },
                    new Product
                    {
                        Name = "Holden",
                        Image = "~/images/Holden.jpg",
                        Price = 867.50
                    },
                    new Product
                    {
                        Name = "Porsche",
                        Image = "~/images/Porsche.jpg",
                        Price = 2.30
                    }
                };

                context.Products.AddRange(products);

                var i = 0;
                context.OwnerInventory.AddRange(
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 20
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 50
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 100
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 150
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 40
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 10
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 5
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 0
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 0
                    },
                    new OwnerInventory
                    {
                        Product = products[i],
                        StockLevel = 0
                    }
                );

                i = 0;
                var stores = new[]
                {
                    new Store
                    {
                        Name = "Melbourne CBD",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 15
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 10
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 1
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 1
                            },
                            new StoreInventory
                            {
                                Product = products[i],
                                StockLevel = 1
                            },
                        }
                    },
                    new Store
                    {
                        Name = "North Melbourne",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[0],
                                StockLevel = 5
                            }
                        }
                    },
                    new Store
                    {
                        Name = "East Melbourne",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[1],
                                StockLevel = 5
                            }
                        }
                    },
                    new Store
                    {
                        Name = "South Melbourne",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[2],
                                StockLevel = 5
                            }
                        }
                    },
                    new Store
                    {
                        Name = "West Melbourne"
                    }
                };

                context.Stores.AddRange(stores);

                context.SaveChanges();
            }
        }

        private static async Task EnsureUserHasRole(
            UserManager<ApplicationUser> userManager, string userName, string role)
        {
            var user = await userManager.FindByNameAsync(userName);
            if(user != null && !await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
