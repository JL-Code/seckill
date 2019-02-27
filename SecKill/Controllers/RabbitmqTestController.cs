using Microsoft.AspNetCore.Mvc;
using NLog;
using RabbitMQ.Client;
using SecKill.Application.Models;
using SecKill.Infrastructure;
using SecKill.Infrastructure.Utils;
using System;
using System.Text;

namespace SecKill.Controllers
{
    [Route("api/[controller]")]
    public class RabbitmqTestController : Controller
    {
        const string SECKILL_QUEUE = "seckill_queue";

        private static ILogger logger = LogManager.GetCurrentClassLogger();

        [HttpPost("publish")]
        public IActionResult Post()
        {
            // 连接工厂
            var factory = new ConnectionFactory() { HostName = "192.168.31.99", UserName = "admin", Password = "123456" };
            // 创建连接
            using (var connection = factory.CreateConnection())
            {
                // 创建通信通道
                using (var channel = connection.CreateModel())
                {
                    // 声明队列
                    channel.QueueDeclare(queue: SECKILL_QUEUE,
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);

                    var seckillMessage = new SeckillMessage()
                    {
                        GoodsId = Guid.NewGuid(),
                        User = new UserDto
                        {
                            UserId = Guid.NewGuid(),
                            UserName = "蒋勇"
                        }
                    };
                    var message = JsonUtil.Serialize(seckillMessage);
                    try
                    {
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish(exchange: "",
                                             routingKey: SECKILL_QUEUE, // 当没有启用交换机时 routingKey = queueName
                                             basicProperties: null,
                                             body: body);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, ex.Message);
                    }
                }
            }

            return Accepted(CodeMessage.IN_QUEUE);
        }
    }
}