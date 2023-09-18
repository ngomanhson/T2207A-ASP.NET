using System;
using System.Collections.Generic;

namespace T2207A_API.Entities;

public partial class Cart
{
    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int BuyQty { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
