using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserDetailDto : IDtos
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
       // public UserImage Image { get; set; }
    }
}