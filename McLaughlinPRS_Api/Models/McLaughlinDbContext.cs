using Microsoft.EntityFrameworkCore;
using McLaughlinPRS_Api.Models;

namespace McLaughlinPRS_Api.Models;

public class McLaughlinDbContext : DbContext
{
    public DbSet<User> Users { get; set;}
    public DbSet<Vendor> Vendors { get; set;}
    public DbSet<Product> Products { get; set;}
    public DbSet<Request> Requests { get; set;}


    public McLaughlinDbContext(DbContextOptions<McLaughlinDbContext> options): base(options) { }


    public DbSet<McLaughlinPRS_Api.Models.Requestline> Requestline { get; set; }
}
