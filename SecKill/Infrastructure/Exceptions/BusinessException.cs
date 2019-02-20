using System;
using System.Runtime.Serialization;

namespace SecKill.Infrastructure.Exceptions
{
    /// <summary>
    /// 违反业务规则而引发的异常
    /// </summary>

    public class BusinessException : Exception
    {
        #region Constructor

        public BusinessException()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        #endregion
    }
}
