using RabbitMQ.Client;
using System;
using System.Text;

namespace Rabbitmq.Publisher
{
    class Pubilsher
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Press [exit] to exit.");
            // 连接工厂
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "123456" };
            // 创建连接
            using (var connection = factory.CreateConnection())
            {
                // 创建通信通道
                using (var channel = connection.CreateModel())
                {
                    // 声明队列
                    channel.QueueDeclare(queue: "routeKeyTest",
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);
                    var message = "";
                    try
                    {
                        while (message != "exit")
                        {
                            message = Console.ReadLine();
                            var body = Encoding.UTF8.GetBytes(message);
                            channel.BasicPublish(exchange: "",
                                                 routingKey: "routeKeyTest",
                                                 basicProperties: null,
                                                 body: body);
                            Console.WriteLine(" [x] Sent {0}", message);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }


        }
    }
}
