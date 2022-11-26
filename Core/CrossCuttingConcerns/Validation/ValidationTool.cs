using FluentValidation;


namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {//IValidator ---> kurallarımızın olduğu class
        public static void Validate(IValidator validator,object entity)
        {
            var context = new
                ValidationContext<object>(entity);//product için doğrulama
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
