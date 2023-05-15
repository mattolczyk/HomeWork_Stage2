using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.EntityFramework;

public class Suppliers
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int TotalBorrowedBooks { get; set; }

}