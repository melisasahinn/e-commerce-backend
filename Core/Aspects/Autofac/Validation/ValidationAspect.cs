using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {//Aspect:methodun başında sonunda hata verdiğinde çalışacak yapı
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding ---->savunma kodu
            //validatorType bir IValidator mı? kontrol et demek
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }

        //MethodInterception ---->OnBefore fonksiyonunu ezdi
        protected override void OnBefore(IInvocation invocation)
        { //CreateInstance: çalışma anında instance oluşturmak istedğinde kullanılır.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
