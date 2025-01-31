using ECommerce.Domain.Entites;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Abstracts;

public interface ICartService
{
    void AddToCart(Cart cart, Product product); 

    void RemoveFromCart(Cart cart, int productId);

    List<CartLine> GetList(Cart cart);
}
