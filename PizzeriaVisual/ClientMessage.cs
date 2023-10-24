using PizzeriaVisual.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PizzeriaVisual
{
    public partial class ClientMessage : Form
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private ClientServices clientServices;

        public ClientMessage()
        {
            InitializeComponent();
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            clientServices = new ClientServices();
        }
        public void Initialize(string phoneNumber)
        {
            InitializeComponent();

            ProcessMessage("client_" + clientServices.FindClientByPhoneNumber(phoneNumber).Id);

        }

        private void ClientMessage_load(object sender, EventArgs e)
        {

        }


        public void ProcessMessage(string queueName, bool consumeAll = false)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Received from Queue '{queueName}': {message}");
               
                this.Invoke((MethodInvoker)delegate {
             
                    label1.Text = $"Received from Queue '{queueName}': {message}";
                });
                if (!consumeAll)
                {
                    _channel.BasicAck(ea.DeliveryTag, false);
                }
            };

            _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
        }
        public void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
