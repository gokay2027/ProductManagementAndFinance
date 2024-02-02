using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Models.Query.Category;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinance.Application.Queries.Concrete
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryQuery(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryListOutputModel> GetAllCategories()
        {
            var output = new CategoryListOutputModel();
            try
            {
                var allCategories = await _categoryRepository.GetAll();

                foreach (var category in allCategories)
                {
                    output.List.Add(new CategoryListModel
                    {
                        Id = category.Id,
                        Description = category.Description,
                        Name = category.Name,
                    });
                }

                output.ItemCount = allCategories.Count();
                output.Message = "Categories Queried Successfully";
                output.IsSuccess = true;
                return output;
            }
            catch (Exception ex)
            {
                output.IsSuccess = false;
                output.Message = ex.Message;
                return output;
            }
        }
    }
}