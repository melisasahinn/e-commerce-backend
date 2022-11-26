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
    public interface ICustomerCreditCardDal : IEntityRepository<CustomerCreditCard>
    {
        List<CustomerPaymentDetailDto> GetDetails(Expression<Func<CustomerPaymentDetailDto, bool>> filter = null);

    }
}
