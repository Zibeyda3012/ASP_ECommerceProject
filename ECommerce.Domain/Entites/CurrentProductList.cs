using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entites;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
