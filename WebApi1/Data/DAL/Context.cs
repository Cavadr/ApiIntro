using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Data.Entity;

namespace WebApi1.Data.DAL
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
              
        }
        public DbSet<Product> Products { get; set; }
    }
}
