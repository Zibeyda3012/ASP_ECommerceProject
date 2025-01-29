using ECommerce.Domain.Entites;
using ECommerce.Repository.DataAccess;

namespace ECommerce.DataAccess.Abstact;

public interface IProductDal : IEntityRepository<Product>
{
}