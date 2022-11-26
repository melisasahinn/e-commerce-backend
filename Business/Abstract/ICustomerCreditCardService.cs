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
    public interface ICustomerCreditCardService : IGenericCrudOperationService<CustomerCreditCard>
    {
        IDataResult<List<CustomerCreditCard>> GetByCustomerId(int customerId);
        IDataResult<List<CustomerPaymentDetailDto>> GetDetailsByCustomerId(int customerId);
    }
}