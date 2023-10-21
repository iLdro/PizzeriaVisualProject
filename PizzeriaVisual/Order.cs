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
        public List<int> PizzaSize { get; set; }
        public List<List<string>> Toppings { get; set; }
        public int TotalPrice { get; set; }
        public string ClientName { get; set; }
        public string ClerkName { get; set; }
        public int ClientId { get; set; }

        private int _clerkId;

        public int ClerkId
        {
            get { return _clerkId; }
            set
            {
                _clerkId = value;

                // Modifiez le statut en fonction de la valeur de ClerkId
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
                sendMessage();
            }
        }

        public int DeliveryId { get; set; }
        public Order(int id, DateTime date, int nbPizza, List<string> drinks, List<int> pizzaSize, List<List<string>> toppings, int totalPrice, string clientName, string clerkName, int clientId, int clerkId, int status, int deliveryId)
        {
            Id = id;
            Date = date;
            NbPizza = nbPizza;
            Drinks = drinks;
            PizzaSize = pizzaSize;
            Toppings = toppings;
            TotalPrice = totalPrice;
            ClientName = clientName;
            ClerkName = clerkName;
            ClientId = clientId;
            ClerkId = -1;
            Status = 0;
            DeliveryId = deliveryId;
            this.sendMessage();
        }
        
        public void sendMessage()
        {
            if(this.Status == 0)
            {
                Console.WriteLine("Your order is being prepared");
            }
            else if(this.Status == 1)
            {
                Console.WriteLine("Your order is ready");
            }
            else if(this.Status == 2)
            {
                Console.WriteLine("Your order is being delivered");
            }
            else if(this.Status == 3)
            {
                Console.WriteLine("Your order has been delivered");
            }
            else
            {
                Console.WriteLine("Your order has been cancelled");
            }
        }
    }
}
