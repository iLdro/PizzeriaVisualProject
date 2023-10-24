using PizzeriaVisual.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaVisual
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NbPizza { get; set; }
        public List<string> Drinks { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public double TotalPrice { get; set; }
        public string ClientName { get; set; }
        public string ClerkName { get; set; }
        public int ClientId { get; set; }

        private int _clerkId;

        private CommunicationServices _communicationServices;

        public int ClerkId
        {
            get { return _clerkId; }
            set
            {
                _clerkId = value;
                if (value >= 0)
                {
                    Status = 1;
                }
            }
        }

        private int _status;
        public int Status
        {
            get { return _status; }
            set
            {
                _status = value;
               ;
            }
        }

        public int DeliveryId { get; set; }
        public Order(int id, DateTime date, int nbPizza, List<string> drinks, List<Pizza> pizzas, double totalPrice, string clientName, string clerkName, int clientId, int clerkId)
        {
            Id = id;
            Date = date;
            NbPizza = nbPizza;
            Drinks = drinks;
            Pizzas = pizzas;
            TotalPrice = totalPrice;
            ClientName = clientName;
            ClerkName = clerkName;
            ClientId = clientId;
            ClerkId = clerkId;
            Status = 0;
            DeliveryId = -1;
            _communicationServices = new CommunicationServices();
        }

        public void sendMessage()
        {
            if(Status == 0)
            {
                Console.WriteLine("Your order is being prepared");
                sendMessageToClient();
                sendMessageToClerk();
                sendMessagetoAllDelivery();
            }
            else if(this.Status == 1)
            {
                Console.WriteLine("Your order is ready");
            }
            else if(this.Status == 2)
            {
                Console.WriteLine("Your order is being delivered");
            }
        }

        public void sendMessageToClient()
        {
            Console.WriteLine("Id",ClientId);
            string message = "Your order is ready wiht " + Pizzas + "drinks" + Drinks;
            _communicationServices.SendMessage(message, "client_"+ ClientId);
        }

        public void sendMessageToClerk()
        {
            string message = "Your order is ready wiht ";
            _communicationServices.SendMessage(message, "clerk_" + ClerkId);
        }
        public void sendMessagetoAllDelivery()
        {
            string message = "The order number " + Id + " is ready to be taken";
            _communicationServices.SendMessage(message, "delivery");
        }
        
    }
}
