using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackExchange.Redis;
using System;

namespace SecKill.Test
{
    [TestClass]
    public class RedisClientLab
    {
        /**
         * StackExchange.Redis ≤‚ ‘
         */
        [TestMethod]
        public void StackExchangeRedisTest()
        {
            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost");

            IDatabase db = connection.GetDatabase();
            db.StringSet("name", "redis");
            var name = db.StringGet("name");

            Console.WriteLine(name);
        }
    }
}
