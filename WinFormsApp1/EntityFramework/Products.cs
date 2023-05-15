using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.EntityFramework;

public class Products
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool Availability { get; set; }
}