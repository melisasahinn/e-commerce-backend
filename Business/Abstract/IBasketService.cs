
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Generics;
using Core.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBasketService : IGenericCrudOperationService<Basket>
    {
        IDataResult<List<BasketDetailDto>> GetBasketDetails();
        IDataResult<List<BasketDetailDto>> GetBasketDetailsByUserId(int userId);
    }
}
