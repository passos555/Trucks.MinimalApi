using Microsoft.EntityFrameworkCore;
using Minimal.Models;

namespace Minimal.Data;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options)
       : base(options) { }

    public DbSet<Truck> Trucks => Set<Truck>();
}
