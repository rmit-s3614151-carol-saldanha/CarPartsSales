using System;
using OAuthExample.Data;
using Microsoft.EntityFrameworkCore;
namespace Assignment2.Data.DatabaseContext
{
    public class DatabaseContext : ApplicationDbContext
    {
        public DatabaseContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
    }
}
