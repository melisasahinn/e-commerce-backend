using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerCreditCardDal : EfEntityRepositoryBase<CustomerCreditCard, YıldızContext>, ICustomerCreditCardDal
    {
        public List<CustomerPaymentDetailDto> GetDetails(Expression<Func<CustomerPaymentDetailDto, bool>> filter = null)
        {
            using (YıldızContext context = new YıldızContext())
            {
                var result = from customerCreditCard in context.CustomerCreditCard
                             join payment in context.Payments on customerCreditCard.CardId equals payment.Id
                             join user in context.Users on customerCreditCard.CustomerId equals user.Id
                             select new CustomerPaymentDetailDto()
                             {
                                 CardId = customerCreditCard.CardId,
                                 UserId = user.Id,
                                 NameOnTheCard = payment.NameOnTheCard,
                                 CardCvv = payment.CardCvv,
                                 CardNumber = payment.CardNumber,
                                 expirationDate = payment.ExpirationDate
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}