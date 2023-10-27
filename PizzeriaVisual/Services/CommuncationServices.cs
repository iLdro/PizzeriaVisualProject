using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            try
            {
                using (var channel = _connection.CreateModel())
                {
                    Console.WriteLine("queueName: " + queueName);
                    string receivedMessage = null;

                    var result = await Task.Run(() => channel.BasicGet(queueName, autoAck: true));

                    if (result != null)
                    {
                        var body = result.Body.ToArray();
                        receivedMessage = Encoding.UTF8.GetString(body);
                        Console.WriteLine($"Received from Queue '{queueName}': {receivedMessage}");
                    }

                    return receivedMessage;
                }
            }
            catch (Exception ex)
            {
                // Gérer les exceptions ici.
                Console.WriteLine($"Erreur lors de la récupération du message : {ex.Message}");
                return null;
            }
        }







        public async Task<List<string>> ProcessAllMessages(string queueName)
        {
            var receivedMessages = new List<string>();

            using (var channel = _connection.CreateModel())
            {
                Console.WriteLine("queueName: " + queueName);
                try{ 
                var result = channel.BasicGet(queueName, autoAck: true);

                while (result != null)
                {
                    var body = result.Body.ToArray();
                    var receivedMessage = Encoding.UTF8.GetString(body);
                    receivedMessages.Add(receivedMessage);
                    result = channel.BasicGet(queueName, autoAck: true); // Obtient le message suivant.
                }
                }catch(OperationInterruptedException ex)
                {
                    // Gérer l'exception ici.
                    Console.WriteLine($"La file d'attente '{queueName}' n'existe pas. Détails : {ex.Message}");
                }

                Console.WriteLine("Received from Queue '" + queueName + "': " + string.Join(", ", receivedMessages));
                Console.WriteLine("Longueur du message : " + receivedMessages.Count);

                return receivedMessages; // Renvoie la liste des messages reçus.

            }
        }
    }



}

