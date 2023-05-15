﻿using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.EntityFramework;

public class Suppliers
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactPerson { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

}