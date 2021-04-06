using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class Result: IResult
    {
        public List<string> Messages { get; }
        public string Message { get; set; }
        public bool IsSuccess { get; }

        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public Result(List<string> messages, bool isSuccess): this(isSuccess)
        {
            Messages = messages;
        }

        public Result(string message, bool isSuccess) : this(isSuccess)
        {
            Message = message;
        }
    }
}
