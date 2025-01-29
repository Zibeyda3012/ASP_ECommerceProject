using ECommerce.Domain.Entites;

namespace ECommerce.Application.Abstract;

public interface IProductService
{
    List<Product> GetAll();
    List<Product> GetAllByCategory(int categoryId);
    Product GetById(int id);

    void Add(Product product);
    
    void Update(Product product);

    void Delete(int id);

}
