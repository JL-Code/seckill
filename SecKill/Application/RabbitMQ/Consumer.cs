using NLog;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SecKill.Application.Models;
using SecKill.Infrastructure.Utils;
using System;
using System.Text;
using System.Threading;

namespace SecKill.Application.RabbitMQ
{
    /// <summary>
    /// TODO: 后期采用 EventBus 代替
    /// </summary>
    public sealed class ConsumerSingleton
    {
        const string SECKILL_QUEUE = "seckill_queue";
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private static object syncRoot = new object();
        // refs: https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/volatile
        private volatile bool _start = false;

        //1. 延迟加载
        //2. 防止被继承
        //3. 控制new入口
        private ConsumerSingleton()
        {

        }

        internal class Nested
        {
            // 静态属性初始化不确定 所以添加一个静态构造函数 精确静态属性的初始化时间
            static Nested()
            {

            }

            internal static ConsumerSingleton Instance { get; } = new ConsumerSingleton();
        }

        public static ConsumerSingleton Instance { get => Nested.Instance; }

        public void Start(string server)
        {
            logger.Info("秒杀订单处理消费者已启动");
            if (!_start)
            {
                lock (syncRoot)
                {
                    _start = true;
                }
            }
            Execute(server);
        }

        private void Execute(string server)
        {
            var factory = new ConnectionFactory() { HostName = server, UserName = "admin", Password = "123456" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: SECKILL_QUEUE,
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

            var consumer = new EventingBasicConsumer(channel);


            BasicDeliverEventArgs args = null;
            try
            {
                consumer.Received += (model, ea) =>
                {
                    args = ea;
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var seckillMessage = JsonUtil.Deserialize<SeckillMessage>(message);
                    logger.Info($"秒杀成功: {message}");
                    // DeliveryTag 相当于message id 是一个 64位长整型
                    // 延迟500ms 确认消息
                    channel.BasicAck(ea.DeliveryTag, false);
                };

            }
            catch (Exception ex)
            {
                if (args != null) channel.BasicNack(args.DeliveryTag, multiple: false, requeue: false);
                logger.Error(ex, ex.ToString());
            }
            finally
            {
                if (args != null) channel.BasicAck(args.DeliveryTag, false);
            }


            // 确认订阅队列
            channel.BasicConsume(queue: SECKILL_QUEUE,
                                 autoAck: false,
                                 consumer: consumer);
        }
    }
}
