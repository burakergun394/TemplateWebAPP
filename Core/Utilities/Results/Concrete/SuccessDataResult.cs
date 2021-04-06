using System.Collections.Generic;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult(T data, List<string> messages) : base(data, messages, true)
        {
        }
        public SuccessDataResult(T data, string message) : base(data, message, true)
        {
        }
        public SuccessDataResult(string message) : base(default, message, true)
        {
        }
        public SuccessDataResult(List<string> messages) : base(default, messages, true)
        {
        }
        public SuccessDataResult() : base(default, true)
        {
        }
    }
}