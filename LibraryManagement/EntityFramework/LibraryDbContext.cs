using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.EntityFramework;

public class LibraryDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=LibraryManagement;Trusted_Connection=True;TrustServerCertificate=true;");
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=LibraryManagement; Integrated Security = True; ");
    }
    
    public DbSet<Books> Books { get; set; }
    public DbSet<Borrowers> Borrowers { get; set; }
}