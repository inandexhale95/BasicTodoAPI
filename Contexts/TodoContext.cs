using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Contexts;

public class TodoContext : DbContext
{
    public IConfiguration Configuration { get; }
    
    public DbSet<Todo> Todos { get; set; }

    public TodoContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}