using SecKill.Domain.SeedWork;
using System;

namespace SecKill.Domain.AggregatesModel
{
    public class User : Entity, IAggregateRoot
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        /// <value>The user identifier.</value>
        public Guid UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }

    
}
