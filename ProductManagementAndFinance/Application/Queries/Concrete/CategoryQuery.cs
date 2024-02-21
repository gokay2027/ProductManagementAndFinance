using Entities.ConcreteEntity;
using LinqKit;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<CategoryListOutputModel> GetCategoriesByFilter(CategorySearchModel searchModel)
        {
            var output = new CategoryListOutputModel();
            if (searchModel.Name.IsNullOrEmpty() && searchModel.Description.IsNullOrEmpty())
            {
                return await GetAllCategories();
            }
            else
            {
                try
                {
                    var predicate = FilterBuilderForCategory(searchModel);
                    var categoriesList = await _categoryRepository.GetByFilter(predicate);

                    foreach (var category in categoriesList)
                    {
                        output.List.Add(new CategoryListModel
                        {
                            Id = category.Id,
                            Description = category.Description,
                            Name = category.Name,
                        });
                    }
                    output.ItemCount = categoriesList.Count();
                    output.Message = "Categories Queried Successfully";
                    output.IsSuccess = true;
                    return output;
                }
                catch (Exception ex)
                {
                    output.ItemCount = 0;
                    output.IsSuccess = false;
                    output.Message = ex.Message;
                    return output;
                }
            }
        }

        private static ExpressionStarter<Category> FilterBuilderForCategory(CategorySearchModel searchModel)
        {
            var predicate = PredicateBuilder.New<Category>();

            if (!searchModel.Name.IsNullOrEmpty())
            {
                predicate.And(a => a.Name.Contains(searchModel.Name));
            }

            if (!searchModel.Description.IsNullOrEmpty())
            {
                predicate.And(a => a.Description.Contains(searchModel.Description));
            }
            return predicate;
        }
    }
}