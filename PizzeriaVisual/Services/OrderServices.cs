using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzeriaVisual.Interfaces;

namespace PizzeriaVisual.Services
{
    internal class OrderServices:IOrderServices
    {
        public List<Order> orders ;
        public OrderServices() {
        
        }
        public int CreateOrder(DateTime date, int NbPizza, List<string> Drinks, List<int> PizzaSize, List<List<string>> Toppings, int TotalPrice, string clientName, string clerkName, int clientId, int clerkId, int status= 0)
        {
            throw new NotImplementedException();
        }

        public int AddDelivery(int orderId, int deliveryId)
        {
            throw new NotImplementedException();
        }

        public int validateOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
