using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorResult: Result
    {
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(List<string> messages) : base(messages, false)
        {
        }
    }
}
