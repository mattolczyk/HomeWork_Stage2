using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.EntityFramework;

public class InventoryDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=LibraryManagement;Trusted_Connection=True;TrustServerCertificate=true;");
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=InventoryManagement; Integrated Security = True; ");
    }
    
    public DbSet<Products> Products { get; set; }
    public DbSet<Suppliers> Suppliers { get; set; }
}