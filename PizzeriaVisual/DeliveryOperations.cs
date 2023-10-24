using PizzeriaVisual.Services;
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
    public partial class DeliveryOperations : Form
    {
        private Delivery delivery;
        private CommunicationServices communicationServices;
        private List<string> privateMessage;
        private string command;
        private int commandId;
        private OrderServices orderServices;

        public DeliveryOperations(Delivery del)
        {
            InitializeComponent();
            delivery = del;
            communicationServices = new CommunicationServices();
            orderServices = new OrderServices();
           
        }

        private async void DeliveryOperations_Load(object sender, EventArgs e)
        {
            bool consumeAll = true;

            // Réception des messages de "delivery_{delivery.Id}" de manière asynchrone
            privateMessage = await Task.Run(() => communicationServices.ProcessAllMessages("delivery_" + delivery.Id));
            label1.Text = string.Join(Environment.NewLine, privateMessage);

            consumeAll = false;

            // Réception d'un message de "delivery" de manière asynchrone
            command = await Task.Run(() => communicationServices.ProcessOneMessage("delivery"));
            Console.WriteLine("Received message: " + command);

            if (!string.IsNullOrEmpty(command))
            {
                label4.Text = command;
                string[] words = command.Split(' ');

                if (words.Length > 2)
                {
                    commandId = Convert.ToInt32(words[3]);
                }
                else
                {
                    // Gérer le cas où la chaîne ne contient pas suffisamment de mots.
                    // Peut-être afficher un message d'erreur.
                }
            }
            else
            {
                // Gérer le cas où command est null ou vide (pas de message dans la file d'attente).
                // Peut-être afficher un message indiquant qu'aucun message n'a été trouvé.
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            orderServices.AddDelivery(commandId, delivery.Id);
        }
    }
}
