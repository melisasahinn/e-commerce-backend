using Business.Generics;
using Core.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductImageService : IGenericImagesService<ProductImage>
    {
        IResult AddAsync(List<IFormFile> file, ProductImage productsImage);
        IResult DeleteById(int id);
    }
}