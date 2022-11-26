
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
       

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
          

        }
        [LogAspect(typeof(DatabaseLogger))]
        [SecuredOperation("admin,product.add")]
        [CacheRemoveAspect("IProductService.Get")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }


        [LogAspect(typeof(DatabaseLogger))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        [LogAspect(typeof(DatabaseLogger))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IProductService.Get")]
        //[ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
             _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        [LogAspect(typeof(FileLogger))]
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<int> GetByIdAdd(Product product)
        {
            _productDal.Add(product);
            return new SuccessDataResult<int>(product.Id);
        }

        [CacheAspect]
        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailsByMinPriceAndMaxPrice(decimal minPrice, decimal maxPrice)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(c => c.Price >= minPrice && c.Price <= maxPrice));
        }


        public IDataResult<List<ProductDetailDto>> GetProductDetailsFilteredAsc()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails()
                .OrderBy(c => c.Price).ToList());
        }
        public IDataResult<List<ProductDetailDto>> GetProductDetailsEvaluation()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails()
                .OrderByDescending(c => c.Rating).ToList());
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailsFilteredDesc()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails()
                .OrderByDescending(c => c.Price).ToList());
        }

        [CacheAspect]
        public IDataResult<List<ProductDetailDto>> GetProductDetailByProductId(int productId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(
                _productDal.GetProductDetails(c => c.Id == productId));
        }

        [CacheAspect]
        public IDataResult<List<ProductDetailDto>> GetProductDetailByBrandId(int brandId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(
                _productDal.GetProductDetails(c => c.BrandId == brandId));
        }

        public IDataResult<List<ProductDetailDto>> GetLimitedProductDetailsByProduct(int limit)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails().Take(limit).ToList());
        }

        public IDataResult<List<ProductDetailDto>> GetAllProductDetailsByProductWithPage(int page, int pageSize)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails().Skip((page - 1) * pageSize).Take(pageSize).ToList());
        }

        [CacheAspect]
        public IDataResult<List<ProductDetailDto>> GetProductDetailByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(
                _productDal.GetProductDetails(c => c.CategoryId == categoryId));
        }
        [CacheAspect]
        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId), "Ürünler kategoriye göre filtrelendi");
        }

    }
}
    