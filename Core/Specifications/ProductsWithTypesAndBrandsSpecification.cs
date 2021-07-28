using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(p => p.Type);
            AddInclude(p => p.Brand);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) 
        : base(p => p.Id == id)
        {
            AddInclude(p => p.Type);
            AddInclude(p => p.Brand);
        }
    }
}