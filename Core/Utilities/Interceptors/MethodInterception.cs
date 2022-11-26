using Castle.DynamicProxy;
using System;
//Interceptors ---> araya girmek methodun başında sonunda çalışmak.
namespace Core.Utilities.Interceptors
{
    //virtual method :ezmeni bekleyen method
    // nerede çalışsın istersek ilgili methodların (OnBefore,OnAfter,OnException,....) yerlerini eziyoruz.
    //invocation Add,update,get,getbycateggory gibi fonksiyonlar
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {//invocation :business method
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
