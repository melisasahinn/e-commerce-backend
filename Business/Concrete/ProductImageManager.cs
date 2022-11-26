using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Results;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{

    public class ProductImageManager : IProductImageService
    {
        private IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(List<IFormFile> file, ProductImage productsImage)
        {
            var error = "";
            List<ProductImage> products = new List<ProductImage>();
            var imageCount = _productImageDal.GetAll(c => c.ProductId == productsImage.ProductId).Count;
            if (imageCount >= 5)
            {
                 return new ErrorResult("One product must have 5 or less images");
            }

            for (int i = 0; i < file.Count; i++)
            {
                var newImage = new ProductImage() { ProductId = productsImage.ProductId };
                var imageResult = FileHelper.Upload(file[i]);

                if (!imageResult.Success)
                {
                    error = imageResult.Message;
                    break;
                }
                else
                {
                    newImage.ImagePath = imageResult.Message;

                    products.Add(newImage);
                }
            }

            //_productImageDal.MultiAdd(products.ToArray());
            return new SuccessResult("Product image added");
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult DeleteById(int id)
        {
            var images = _productImageDal.Get(c => c.Id == id);
            _productImageDal.Delete(images);
            return new SuccessResult();
        }


        public IResult Add(IFormFile file, ProductImage entity)
        {
            throw new NotImplementedException();
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(ProductImage productsImage)
        {
            _productImageDal.Delete(productsImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
       // [ValidationAspect(typeof(ProductImagesValidator))]
        public IResult Update(IFormFile file, ProductImage productsImage)
        {
            _productImageDal.Update(productsImage);
            return new SuccessResult();
        }

        public IDataResult<ProductImage> Get(int id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        public IDataResult<List<ProductImage>> GetImagesByTId(int id)
        {
            throw new System.NotImplementedException();
        }
      

        private IResult CheckImageLimitExceeded(int productId)
        {
            var productsImageCount = _productImageDal.GetAll(p => p.ProductId == productId).Count;
            if (productsImageCount >= 5)
            {
                return new ErrorResult("Limit");
            }

            return new SuccessResult();
        }

        private IDataResult<List<ProductImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _productImageDal.GetAll(c => c.ProductId == id).Any();
                if (!result)
                {
                    List<ProductImage> productsImages = new List<ProductImage>();
                    productsImages.Add(new ProductImage { ProductId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<ProductImage>>(productsImages);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<ProductImage>>(exception.Message);
            }

            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(p => p.ProductId == id).ToList());
        }
        private IResult CarImageDelete(ProductImage ımage)
        {
            try
            {
                File.Delete(ımage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public IResult AddAsync(List<IFormFile> file, ProductImage productsImage)
        {
            throw new NotImplementedException();
        }
    }
}