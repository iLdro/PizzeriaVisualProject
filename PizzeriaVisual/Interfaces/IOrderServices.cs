using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaVisual.Interfaces
{
    internal interface IOrderServices
    {
         int CreateOrder(DateTime date, List<string> Drinks, List<Pizza> pizzas, int TotalPrice, string clientName, string clerkName, int clientId, int clerkId, int status = 0);


        void AddDelivery(int orderId, int deliveryId);

        int validateOrder(int orderId);
    }
}
 