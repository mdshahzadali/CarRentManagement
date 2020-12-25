using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentManagement.Models.Context
{
    public class CarRentDbContext : DbContext
    {
        public CarRentDbContext(DbContextOptions<CarRentDbContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
    }
}
