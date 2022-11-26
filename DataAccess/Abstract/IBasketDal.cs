using Core.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBasketDal : IEntityRepository<Basket>
    {
        List<BasketDetailDto> GetBasketDetails(Expression<Func<BasketDetailDto, bool>> filter = null);
    }
}