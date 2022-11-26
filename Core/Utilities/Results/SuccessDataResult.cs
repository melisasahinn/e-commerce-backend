using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {//versiyonlar


        public SuccessDataResult(T data, string message) : base(data, true, message)//data+mesaj
        {

        }
        public SuccessDataResult(T data) : base(data, true)//data
        {

        }

        public SuccessDataResult(string message) : base(default, true, message)//mesaj
        {

        }

        public SuccessDataResult() : base(default, true)//hiç verme
        {

        }


    }
}
