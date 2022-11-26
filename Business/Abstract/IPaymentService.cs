using Business.Generics;
using Core.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  
public interface IPaymentService : IGenericCrudOperationService<Payment>
{
        IDataResult<int> GetByIdAdd(Payment fakeCard);
        IDataResult<Payment> GetById(int id);
        IDataResult<List<Payment>> GetByCardNumber(string cardNumber);
        IResult IsCardExist(Payment fakeCard);
    }
}
