using HBO.Models;
using Microsoft.EntityFrameworkCore;

namespace HBO.Data;

public class ApplicationDbContextEF : DbContext
{

    public DbSet<Movie>? Movies { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public ApplicationDbContextEF(DbContextOptions<ApplicationDbContextEF> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TCI");

        modelBuilder.Entity<Movie>();
        modelBuilder.Entity<Customer>();
    }
}
