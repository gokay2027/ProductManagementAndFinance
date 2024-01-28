using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementAndFinanceData.Repository.EntityRepository.Abstract
{
    public interface IProductRepository: IGenericRepository<Product>
    {
    }
}
