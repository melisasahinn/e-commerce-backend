using Business.Generics;
using Core.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService : IGenericCrudOperationService<Product>
    {
        IDataResult<int> GetByIdAdd(Product product);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<List<ProductDetailDto>> GetProductDetailsByMinPriceAndMaxPrice(decimal minPrice, decimal maxPrice);
        IDataResult<List<ProductDetailDto>> GetProductDetailsFilteredDesc();
        IDataResult<List<ProductDetailDto>> GetProductDetailsFilteredAsc();
        IDataResult<List<ProductDetailDto>> GetProductDetailsEvaluation();
        IDataResult<List<ProductDetailDto>> GetProductDetailByCategoryId(int categoryId);
        IDataResult<List<ProductDetailDto>> GetProductDetailByProductId(int productId);
        IDataResult<List<ProductDetailDto>> GetProductDetailByBrandId(int brandId);
        IDataResult<List<ProductDetailDto>> GetLimitedProductDetailsByProduct(int limit);
        IDataResult<List<ProductDetailDto>> GetAllProductDetailsByProductWithPage(int page, int pageSize);
        IDataResult<List<Product>> GetAllByCategory(int categoryId);

    }
}
