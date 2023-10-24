using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzeriaVisual.Interfaces;
using RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

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
            _channel.QueueDeclare(
                queue: queueName,
                durable: false,    // false signifie que la file d'attente n'est pas durable
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
            _channel.QueueDeclarePassive(queueName);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            Console.WriteLine($"Sent to Queue '{queueName}': {message}");
        }

        public async Task<string> ProcessOneMessage(string queueName)
        {
            using (var channel = _connection.CreateModel())
            {
                Console.WriteLine("queueName: " + queueName);
                string receivedMessage = null;

                try
                {
                    var consumer = new EventingBasicConsumer(channel);

                  
                    var tcs = new TaskCompletionSource<string>();

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        receivedMessage = Encoding.UTF8.GetString(body);
                        Console.WriteLine($"Received from Queue '{queueName}': {receivedMessage}");                   

                       
                        tcs.SetResult(receivedMessage);
                    };

                    channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

                    // Attendre la réception d'un message.
                    receivedMessage = await tcs.Task;
                }
                catch (OperationInterruptedException ex)
                {
                    // Gérer l'exception ici.
                    Console.WriteLine($"La file d'attente '{queueName}' n'existe pas. Détails : {ex.Message}");
                }

                return receivedMessage;
            }
        }


        public List<string> ProcessAllMessages(string queueName)
        {
            using (var channel = _connection.CreateModel())
            {
                Console.WriteLine("queueName: " + queueName);
                var receivedMessages = new List<string>();

                try
                {
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var receivedMessage = Encoding.UTF8.GetString(body);
                        Console.WriteLine($"Received from Queue '{queueName}': {receivedMessage}");
                        receivedMessages.Add(receivedMessage);
                    };

                    channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
                }
                catch (OperationInterruptedException ex)
                {
                    // Gérer l'exception ici.
                    Console.WriteLine($"La file d'attente '{queueName}' n'existe pas. Détails : {ex.Message}");
                }

                return receivedMessages;
            }
        }
    }



}

