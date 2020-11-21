using SeedWork.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.Models.Message
{
    public class ErrorType : Enumeration
    {
        public ErrorType(int id, string name)
            : base(id, name)
        {
        }

        // 错误码
    }
}
