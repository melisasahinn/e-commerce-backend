using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerService;

        public CustomerManager(ICustomerDal customerService)
        {
            _customerService = customerService;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerService.GetAll());
        }
        public IResult Add(Customer customer)
        {
            _customerService.Add(customer);
            return new SuccessResult(Messages.AddedBasket);
        }

        public IResult Delete(Customer customer)
        {
            _customerService.Delete(customer);
            return new SuccessResult(Messages.DeletedBasket);
        }
        [CacheRemoveAspect("IBasketService.Get")]
        public IResult Update(Customer customer)
        {
            _customerService.Update(customer);
            return new SuccessResult(Messages.UpdatedBasket);
        }
    }
}