using System;
using System.Collections.Generic;

namespace week11.Models.Entities;

public partial class InvoiceLineItem
{
    public int InvoiceId { get; set; }

    public string ProductCode { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public decimal ItemTotal { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual Product ProductCodeNavigation { get; set; } = null!;
}
