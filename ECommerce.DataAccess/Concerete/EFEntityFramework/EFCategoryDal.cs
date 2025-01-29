using ECommerce.DataAccess.Abstact;
using ECommerce.DataAccess.Context;
using ECommerce.Domain.Entites;
using ECommerce.Repository.DataAccess.EntityFrameworkAccess;

namespace ECommerce.DataAccess.Concerete.EFEntityFramework;

public class EFCategoryDal : EFEntityRepositoryBase<Category , NorthWindDbContext>, ICategoryDal
{

}
