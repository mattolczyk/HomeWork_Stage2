using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.EntityFramework;

public class Products
{
    public int  Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public int SupplierId { get; set; }
}