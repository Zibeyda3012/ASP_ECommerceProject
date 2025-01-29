using ECommerce.Domain.Entites;

namespace ECommerce.Application.Abstract;

public interface ICategoryService
{
    List<Category> GetAll();
}