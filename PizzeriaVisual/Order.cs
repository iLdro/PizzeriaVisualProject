using PizzeriaVisual.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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

        public int ClerkId { get; set; }

        private CommunicationServices _communicationServices;

      
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
        private int _deliveryId;
         public int DeliveryId
        {
            get { return _deliveryId; }
            set
            {
                _deliveryId = value;
                ;
            }
        }
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
                
                sendMessagetoAllDelivery();
            }
            else if(this.Status == 1)
            {
                sendMessageToClerk();
            }
            else if(this.Status == 2)
            {
                sendMessageToClerk();
            }
        }

        public string developpOrder(List<Pizza> pizzas, List<string> toppings)
        {
            string orderList = "";
            string listPizza = "";
            string listTopping = "";
            string listDrink = "";
            int cpt = 0;
            foreach (Pizza pizza in pizzas)
            {   
                cpt++;
                listTopping = "";
                foreach (String topping in pizza.Toppings)
                {
                    listTopping += topping + " ";
                }
                listPizza += "Pizza " + cpt + " of size " + pizza.Size + " : with " + listTopping + "\n";
            }
            foreach (string drink in Drinks)
            {
                listDrink += drink + " ";
            }
            orderList = "Pizza : " + listPizza + "\n Drink : " + listDrink ;
            return orderList;
        }

        public void sendMessageToClient()
        {
            Console.WriteLine("Id",ClientId);
            string message = "Hello " + ClientName + "Your order is ready with " + developpOrder(Pizzas, Drinks);
            _communicationServices.SendMessage(message, "client_"+ ClientId);
        }

        public void sendMessageToKitchen()
        {
            string message = "The order n°" + Id + " is composed of " + developpOrder(Pizzas, Drinks) + " need to be prepared";
            _communicationServices.SendMessage(message, "kitchen");
        }

        public void sendMessageToClerk()
        { if (Status == 0)
            {
            string message = "The order  " + Id +
                            " made by " + ClientId +
                            " at " + Date + " registered by " + ClerkId +
                            " composed of " + developpOrder(Pizzas, Drinks) + " has been saved";
                _communicationServices.SendMessage(message, "clerk_" + ClerkId);
            }
            else if (Status == 1)
            {
                Console.WriteLine("je vais modifier");
                Console.WriteLine("nouveau deliveryID" + DeliveryId);
                DatabaseManager.UpdateItem<Order>(o => o.Id == Id, o => { o.Status = Status; o.DeliveryId = DeliveryId; }, "C:\\Users\\jukle\\source\\repos\\PizzeriaVisual\\PizzeriaVisual\\Databases\\Order.json");
                string message = "Order taken by delivery man id " + DeliveryId;
                _communicationServices.SendMessage(message, "clerk_" + ClerkId);
            }
            else if (Status == 2)
            {
                string message = "Closing order" + Id + " made by " + ClientId + " at " + Date + " registered by " + ClerkId + " composed of " + developpOrder(Pizzas, Drinks) + " has been saved";
                _communicationServices.SendMessage(message, "clerk_" + ClerkId);
            }
        }
        public void sendMessagetoAllDeliveryAsync()
        {
            var th = new Thread(() => sendMessagetoAllDelivery());
            th.Start();


        }

        public void sendMessagetoAllDelivery(){
            Thread.Sleep(1000);
            string message = "The order number " + Id + 
                            "\n Date : " + Date +
                            "\n Client n°" + ClientId + 
                            "\n product : " + developpOrder(Pizzas, Drinks);
            _communicationServices.SendMessage(message, "delivery");
        }
           }
}
