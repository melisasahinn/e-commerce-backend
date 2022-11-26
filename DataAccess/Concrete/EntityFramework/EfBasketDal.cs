using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBasketDal : EfEntityRepositoryBase<Basket, YıldızContext>, IBasketDal
    {
        public List<BasketDetailDto> GetBasketDetails(Expression<Func<BasketDetailDto, bool>> filter = null)
        {
            using (YıldızContext context = new YıldızContext())
            {
                var result = from basket in context.Baskets
                             join product in context.Products on basket.ProductId equals product.Id
                             join user in context.Users on basket.UserId equals user.Id
                             select new BasketDetailDto
                             {
                                 Id = basket.Id,
                                 UserId = user.Id,
                                 ProductId = product.Id,
                                 ProductName = product.Name,
                                 UserFullName = $"{user.FirstName} {user.LastName}",
                                 Price = product.Price,
                                 Images =
                             (from i in context.ProductImages where i.ProductId == product.Id select i.ImagePath).ToList(),

                                 Count = basket.Count,
                                 CreateDate = basket.CreateDate,
                                 Active = basket.Active
                             };
                return filter == null ?  result.ToList() :  result.Where(filter).ToList();
            }
        }
    }
}