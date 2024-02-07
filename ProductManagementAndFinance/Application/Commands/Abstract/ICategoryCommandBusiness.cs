using ProductManagementAndFinanceApi.Models.Command.Category;

namespace ProductManagementAndFinanceApi.Application.Commands.Abstract
{
    public interface ICategoryCommandBusiness
    {
        /// <summary>
        /// Adds category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AddCategoryCommandOutputModel AddCategory(AddCategoryModel model);

        /// <summary>
        /// Updates Category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        UpdateCategoryOutputModel UpdateCategory(UpdateCategoryModel model);

        /// <summary>
        /// Deletes Category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DeleteCategoryCommandOutputModel DeleteCategory(DeleteCategoryModel model);
    }
}