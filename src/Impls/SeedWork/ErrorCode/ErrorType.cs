using System;
using SeedWork.Models.Base;

namespace SeedWork.ErrorCode
{
    public class ErrorType : Enumeration
    { 
        public ErrorType(int id, string name)
            : base(id, name)
        {
        }

        // 错误码
        // 成功
        public static readonly ErrorType Success
            = new ErrorType(1, "Success");
    }
}
