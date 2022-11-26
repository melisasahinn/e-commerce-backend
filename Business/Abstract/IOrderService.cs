using Business.Generics;
using Core.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService:IGenericCrudOperationService<Order>
    {
        IDataResult<long> GetByIdAdd(Order orders);
    }
}
