﻿using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Abstract;

namespace ProductManagementAndFinanceData.Repository.EntityRepository.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}