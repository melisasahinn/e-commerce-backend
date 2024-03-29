﻿using Business.Generics;
using Core.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService : IGenericCrudOperationService<Category>
    {
        IResult Add(Category category);
        IResult MultiAdd(Category[] categories);
    }
}
