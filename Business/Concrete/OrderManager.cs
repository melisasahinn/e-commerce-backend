using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager:IOrderService
    {
        private IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        [SecuredOperation("admin,user")]
        public IResult Add(Order order)
        {
            throw new NotImplementedException();
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.DeletedOrder);
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>( _orderDal.GetAll());
        }

        public IDataResult<long> GetByIdAdd(Order orders)
        {
            _orderDal.Add(orders);
            return new SuccessDataResult<long>(orders.Id, Messages.AddedOrder);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.UpdatedOrder);
        }
    }
}
