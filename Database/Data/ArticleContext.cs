using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Data;

public class ArticleContext : DbContext
{
    public DbSet<Article> Articles { get; set; } = null!;
    public DbSet<Topic> Topics { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString = "server=localhost;database=c#_articles;uid=root;password=;";
        optionsBuilder.UseMySql("server=localhost;user=root;password=;database=c#_articles",
            new MySqlServerVersion(new Version(10, 4, 28)));
    }
}