using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {//versiyonlar
        public ErrorDataResult(T data, string message) : base(data, false, message)//data+mesaj
        {

        }
        public ErrorDataResult(T data) : base(data, false)//data
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)//mesaj
        {

        }

        public ErrorDataResult() : base(default, false)//hiç verme
        {

        }
    }
}
