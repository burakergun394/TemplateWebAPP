using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T>: Result, IDataResult<T>
    {
        public T Data { get; }
        public DataResult(T data, bool isSuccess) : base(isSuccess)
        {
            Data = data;
        }

        public DataResult(T data, List<string> messages, bool isSuccess) : base(messages, isSuccess)
        {
            Data = data;
        }
        public DataResult(T data, string messages, bool isSuccess) : base(messages, isSuccess)
        {
            Data = data;
        }

    }
}
