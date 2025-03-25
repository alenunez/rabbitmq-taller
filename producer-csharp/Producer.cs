using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

namespace App
{
    class Producer
    {
        static void Main(string[] args)
        {
Thread.Sleep(15000);
            var factory = new ConnectionFactory()
            {
                HostName = "rabbitmq",
                UserName = "miusuario",
                Password = "mipassword"
            };

            using var connection = factory.CreateConnection(new string[] { "rabbitmq" });
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            int i = 1;
            while (true)
            {
                string message = $"Mensaje {i++} desde C# Producer 🚀";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine($"📤 Enviado: {message}");
                Thread.Sleep(2000); // Espera 2 segundos
            }
        }
    }
}
