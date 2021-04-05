using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T>: DataResult<T>
    {
        public ErrorDataResult(T data) : base(data, false)
        {
        }

        public ErrorDataResult(T data, List<string> messages) : base(data, messages, false)
        {
        }
        public ErrorDataResult(List<string> messages) : base(default, messages, false)
        {
        }
        public ErrorDataResult() : base(default, false)
        {
        }
    }
}
