using System;
using System.Collections.Generic;

namespace T2207A_API.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string? Thumbnail { get; set; }

    public int Qty { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
