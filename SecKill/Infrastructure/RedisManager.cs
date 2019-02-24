using StackExchange.Redis;

namespace SecKill.Infrastructure
{
    public class RedisManager
    {
        private readonly IDatabase _redisDb;
        private readonly ConnectionMultiplexer _redis;

        public RedisManager(ConfigurationOptions configuration)
        {
            _redis = ConnectionMultiplexer.Connect(configuration);
            _redisDb = _redis.GetDatabase();
        }

        public RedisManager(string configuration)
        {
            _redis = ConnectionMultiplexer.Connect(configuration);
            _redisDb = _redis.GetDatabase();
        }

        public IDatabase RedisDb { get => _redisDb; }
    }
}
