using ECommerce.Application.Abstract;
using ECommerce.Application.Abstracts;
using ECommerce.Domain.Models;
using ECommerce.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ECommerce.WebUI.Controllers;

public class CartController(ICartSessionService sessionService, IProductService productService, ICartService cartService) : Controller
{
    private readonly ICartSessionService _sessionService = sessionService;
    private readonly IProductService _productService = productService;
    private readonly ICartService _cartService = cartService;

    public IActionResult AddToCart(int productId)
    {
        var productToBeAdded = _productService.GetById(productId);
        var cart = _sessionService.GetCart();
        _cartService.AddToCart(cart, productToBeAdded);
        _sessionService.SetCart(cart);

        TempData["message"] = string.Format("Your product {0} was added successfully yo cart", productToBeAdded.ProductName);
        return RedirectToAction("Index", "Product");
    }

    public IActionResult List()
    {
        var cart = _sessionService.GetCart();
        var model = new CartListViewModel
        {
            Cart = cart
        };

        return View(model);
    }

    public IActionResult Remove(int productId)
    {
        var cart = _sessionService.GetCart();
        _cartService.RemoveFromCart(cart, productId);
        _sessionService.SetCart(cart);
        TempData["message"] = string.Format("Your product was successfully deleted from cart");

        return RedirectToAction("List");

    }

    [HttpGet]
    public IActionResult Complete()
    {
        var shippingDetailtsViewModel = new ShippingDetailsViewModel
        {
            ShippingDetails = new ShippingDetails()
            {
                Firstname = string.Empty,
                Lastname = string.Empty,
                Email = string.Empty,
                City = string.Empty,
                Address = string.Empty,
                Age = 0
            }

        };
        return View(shippingDetailtsViewModel);

    }

    [HttpPost]

    public IActionResult Complete(ShippingDetailsViewModel model)
    {
        if (!ModelState.IsValid) return View();
        TempData.Add("message", string.Format("Thank you {0}, your order is in progress ", model.ShippingDetails.Firstname));
        Thread.Sleep(1000);
        return RedirectToAction("Index","Product"); 
    }
}
