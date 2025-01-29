using ECommerce.Application.Abstract;
using ECommerce.DataAccess.Abstact;
using ECommerce.Domain.Entites;

namespace ECommerce.Application.Concrete;

public class CategoryService(ICategoryDal categoryDal) : ICategoryService
{
    private readonly ICategoryDal _categoryDal = categoryDal;

    public List<Category> GetAll()
    {
        return _categoryDal.GetList();
    }
}
