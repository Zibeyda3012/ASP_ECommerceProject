using ECommerce.Domain.Entites;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ECommerce.WebUI;

public class ProductListViewModel
{
    public List<Product> Products { get; set; }

    public int PageSize { get; set; }

    public int PageCount { get; set; }

    public int CurrentCategory { get; set; } // current category id 

    public int CurrentPage { get; set; }
}