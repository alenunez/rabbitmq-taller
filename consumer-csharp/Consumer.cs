using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace App
{
    class Consumer
    {
        static void Main(string[] args)
        {
            Thread.Sleep(15000); // Espera a que RabbitMQ esté listo

            var factory = new ConnectionFactory()
            {
                UserName = "miusuario",
                Password = "mipassword"
            };

            using var connection = factory.CreateConnection(new string[] { "rabbitmq" });
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"📥 [C# CONSUMER] Mensaje recibido: {message}");
            };

            channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);

            // Mantiene el contenedor vivo
            Console.WriteLine("⏳ Esperando mensajes. Presiona CTRL+C para salir.");
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
