using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Models.Command.Category;

namespace ProductManagementAndFinanceApi.Application.Commands.Concrete
{
    public class CategoryCommandBusiness : ICategoryCommandBusiness
    {
        private readonly ICategoryCommandBusiness _categoryBusiness;

        public CategoryCommandBusiness(ICategoryCommandBusiness categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }

        public AddCategoryCommandOutputModel AddCategory(AddCategoryModel model)
        {



            throw new NotImplementedException();
        }

        public DeleteCategoryCommandOutputModel DeleteCategory(DeleteCategoryModel model)
        {
            throw new NotImplementedException();
        }

        public UpdateCategoryOutputModel UpdateCategory(UpdateCategoryModel model)
        {
            throw new NotImplementedException();
        }
    }
}