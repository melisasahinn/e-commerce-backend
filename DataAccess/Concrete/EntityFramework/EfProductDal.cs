using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, YıldızContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails(Expression<Func<ProductDetailDto, bool>> filter = null)
        {
            using (YıldızContext context = new YıldızContext())
            {
                var result = from product in context.Products
                             join category in context.Categories
                                 on product.CategoryId equals category.CategoryId
                           
                             select new ProductDetailDto
                             {
                                 Id = product.Id,
                               
                                 CategoryId = category.CategoryId,
                                 CategoryName = category.CategoryName,
                               
                                 ProductName = product.Name,
                                 Description = product.Description,
                                 Code = product.Code,
                                 Rating = product.Rating,
                                 DiscountRate = product.DiscountRate,
                                 Price = product.Price,
                                 CreateDate = product.CreateDate,
                                 Active = product.Active,
                                 Image = (from image in context.ProductImages where image.ProductId == product.Id select image).ToList(),
                                 Images = (from i in context.ProductImages where i.ProductId == product.Id select i.ImagePath).ToList(),

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
