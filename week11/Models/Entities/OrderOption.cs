using System;
using System.Collections.Generic;

namespace week11.Models.Entities;

public partial class OrderOption
{
    public decimal SalesTaxRate { get; set; }

    public decimal FirstBookShipCharge { get; set; }

    public decimal AdditionalBookShipCharge { get; set; }
}
