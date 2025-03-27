using Microsoft.EntityFrameworkCore;
using Module32._2.Models;

namespace Module32._2.Context;

public class BlogDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserPost> UserPosts { get; set; }
    public DbSet<Request> Requests { get; set; }

    public BlogDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("DbConnect.json")
            .SetBasePath(Directory.GetCurrentDirectory())
            .Build();
        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
    }
}