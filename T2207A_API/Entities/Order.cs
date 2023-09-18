using System;
using System.Collections.Generic;

namespace T2207A_API.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedId { get; set; }

    public decimal GrandTotal { get; set; }

    public string? ShippingAddress { get; set; }

    public string? Telephone { get; set; }

    public string? PaymentMethod { get; set; }

    public string InvoiceId { get; set; } = null!;

    public int Status { get; set; }

    public virtual User User { get; set; } = null!;
}
