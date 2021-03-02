using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(bool success, string message, T data) : base(data, true, message)
        {

        }

        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }

        public SuccessDataResult() : base(default, true)
        {

        }

        public SuccessDataResult(string messaage) : base(default, true, messaage)
        {

        }
    }
}
