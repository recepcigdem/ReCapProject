using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(bool success, string message, T data) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data, string message) : base(data, false)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }

        public ErrorDataResult(string messaage) : base(default, false, messaage)
        {

        }

    }
}
