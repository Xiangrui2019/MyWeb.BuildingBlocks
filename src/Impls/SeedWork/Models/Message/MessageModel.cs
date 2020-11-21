using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.Models.Message
{
    public class MessageModel
    {
        // 错误码
        public virtual ErrorType Code { get; set; }
        // 错误消息
        public virtual string Message { get; set; }
        // 返回时间
        public virtual DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }
}
