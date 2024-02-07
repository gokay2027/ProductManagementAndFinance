using Entities.ConcreteEntity;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Models.Command.Category;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinanceApi.Application.Commands.Concrete
{
    public class CategoryCommandBusiness : ICategoryCommandBusiness
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryCommandBusiness(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<AddCategoryCommandOutputModel> AddCategory(AddCategoryModel model)
        {
            try
            {
                await _categoryRepository.Add(new Category(model.Name, model.Description));
                return new AddCategoryCommandOutputModel
                {
                    IsSuccess = true,
                    Message = "Category has been added successfully"
                };
            }
            catch (Exception ex)
            {
                return new AddCategoryCommandOutputModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<DeleteCategoryCommandOutputModel> DeleteCategory(DeleteCategoryModel model)
        {
            try
            {
                await _categoryRepository.Delete(model.Id);
                return new DeleteCategoryCommandOutputModel
                {
                    IsSuccess = true,
                    Message = "Category Deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new DeleteCategoryCommandOutputModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<UpdateCategoryOutputModel> UpdateCategory(UpdateCategoryModel model)
        {
            try
            {
                var categoryModel = await _categoryRepository.GetById(model.Id);
                categoryModel.UpdateCategory(model.Name, model.Description);
                await _categoryRepository.Update(categoryModel);
                return new UpdateCategoryOutputModel
                {
                    IsSuccess = true,
                    Message = "Category has been updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new UpdateCategoryOutputModel
                {
                    IsSuccess = true,
                    Message = ex.Message
                };
            }
        }
    }
}