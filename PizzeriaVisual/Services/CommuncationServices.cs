using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzeriaVisual.Interfaces;
using RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PizzeriaVisual.Services
{
    internal class CommunicationServices : ICommunicationServices
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public CommunicationServices()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }


        public void SendMessage(string message, string queueName)
        {
           
            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            Console.WriteLine($"Sent to Queue '{queueName}': {message}");
            
        }

        public void ProcessMessage(string queueName, bool consumeAll = false)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Received from Queue '{queueName}': {message}");
                if (!consumeAll)
                {
                    _channel.BasicAck(ea.DeliveryTag, false);
                }
            };

            _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
        }
    }
}
