using Entities.ConcreteEntity;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Models.Command.Category;
using ProductManagementAndFinanceApi.Validation.InputModelValidation.Category;
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

        public async Task<AddCategoryCommandOutputModel> AddCategory(AddCategoryModel inputModel)
        {
            var validation = new AddCategoryModelValidator();
            var validationResult = validation.Validate(inputModel);

            if (validationResult.IsValid)
            {
                try
                {
                    await _categoryRepository.Add(new Category(inputModel.Name, inputModel.Description));
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
            else
            {
                return new AddCategoryCommandOutputModel
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
        }

        public async Task<DeleteCategoryCommandOutputModel> DeleteCategory(DeleteCategoryModel inputModel)
        {
            var validation = new DeleteCategoryModelValidator();
            var validationResult = validation.Validate(inputModel);

            if (validationResult.IsValid)
            {
                try
                {
                    await _categoryRepository.Delete(inputModel.Id);
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
            else
            {
                return new DeleteCategoryCommandOutputModel
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
        }

        public async Task<UpdateCategoryOutputModel> UpdateCategory(UpdateCategoryModel inputModel)
        {
            var validation = new UpdateCategoryModelValidator();
            var validationResult = validation.Validate(inputModel);

            if (validationResult.IsValid)
            {
                try
                {
                    var categoryModel = await _categoryRepository.GetById(inputModel.Id);
                    categoryModel.UpdateCategory(inputModel.Name, inputModel.Description);
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
                        IsSuccess = false,
                        Message = ex.Message
                    };
                }
            }
            else
            {
                return new UpdateCategoryOutputModel
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
        }
    }
}