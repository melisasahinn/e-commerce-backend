using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ProductImage:IEntity
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }

        public ProductImage()
        {
            Date = DateTime.Now;
        }
    }
}

