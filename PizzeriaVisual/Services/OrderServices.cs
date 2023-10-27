using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzeriaVisual.Interfaces;

namespace PizzeriaVisual.Services
{
    internal class OrderServices : IOrderServices
    {
        public List<Order> orders;
        Dictionary<string, double> pizzaSizes;
        Dictionary<string, double> toppingPrices;
        Dictionary<string, double> drinkPrices;

        public OrderServices()
        {
            pizzaSizes = new Dictionary<string, double>
            {
                ["Small"] = 8.99,
                ["Medium"] = 10.99,
                ["Large"] = 12.99
                // Ajoutez les prix pour d'autres tailles de pizza si nécessaire
            };

            toppingPrices = new Dictionary<string, double>
            {
                ["Cheese"] = 1.0, // Le fromage peut être gratuit
                ["Pepperoni"] = 2.0,
                ["Salmon"] = 3.0
            };

            drinkPrices = new Dictionary<string, double>
            {
                ["Cola"] = 1.99,
                ["Orange Juice"] = 2.49,
                ["Lemonade"] = 1.79,
                ["None"] = 0.0
            };

            orders = new List<Order>();
            orders = DatabaseManager.AllItems<Order>("C:\\Users\\adria\\source\\repos\\skjdfkjsdfh\\PizzeriaVisual\\Databases\\Order.json");
        }

        public int CreateOrder(DateTime date, List<string> Drinks, List<Pizza> pizzas, int TotalPrice, string clientName, string clerkName, int clientId, int clerkId, int status = 0)
        {
            Console.WriteLine("pizza",pizzas);
            double totalPizzaPrice = 0;
            double totalDrinkPrice = 0;

            Console.WriteLine("calcul du prix");
            // Calcul du coût total des pizzas
            foreach (var pizza in pizzas)
            {
                Console.WriteLine("Pizza createdORder size: " + pizza.Size);
                Console.WriteLine("Pizza createdORder topping: " + string.Join(", ", pizza.Toppings));
                string pizzaSize = pizza.Size;
                double pizzaPrice = 0.0;

                if (pizzaSizes.ContainsKey(pizzaSize))
                {
                    pizzaPrice = pizzaSizes[pizzaSize];
                }
                else
                {
                    return -1;
                }

                foreach (string topping in pizza.Toppings)
                {
                    if (toppingPrices.ContainsKey(topping))
                    {
                        pizzaPrice += toppingPrices[topping];
                    }
                    else
                    {
                        return -1;
                    }
                }

                totalPizzaPrice += pizzaPrice;
            }

            Console.WriteLine("calcul du prix des boissons");

            // Calcul du coût total des boissons
            foreach (string drink in Drinks)
            {
                if (drink == null)
                {
                    continue;
                }
               
                if (drinkPrices.ContainsKey(drink))
                {
                    totalDrinkPrice += drinkPrices[drink];
                }
                else
                {
                    return -1;  
                }
            }

            double totalPrice = totalPizzaPrice + totalDrinkPrice;

            Console.WriteLine("calcul du prix total");

            Console.WriteLine("Total Pizza Price: " + totalPizzaPrice);
            Console.WriteLine("Total Drink Price: " + totalDrinkPrice);
            Console.WriteLine("Total Price: " + totalPrice);

            Order neword = new Order(orders.Count, date, pizzas.Count, Drinks, pizzas, totalPrice, clientName, clerkName, clientId, clerkId);
            orders.Add(neword);

            Console.WriteLine(neword);

            DatabaseManager.CreateItem(neword, "C:\\Users\\adria\\source\\repos\\skjdfkjsdfh\\PizzeriaVisual\\Databases\\Order.json");
            neword.sendMessage();

            return 1;
        }

        public void AddDelivery(int orderId, int deliveryId)
        {
            Console.WriteLine("Oder" + orderId + "DeliveryId" + deliveryId);
            Order a = DatabaseManager.FindBy<Order>("C:\\Users\\jukle\\source\\repos\\PizzeriaVisual\\PizzeriaVisual\\Databases\\Order.json", o => o.Id == orderId).FirstOrDefault();
            Console.WriteLine("Find this one " + a.Id);
            a.DeliveryId = deliveryId;
            a.Status = 1;
            a.sendMessage();    
        }

        public int validateOrder(int orderId)
        {
          
            Order a = DatabaseManager.FindBy<Order>("C:\\Users\\jukle\\source\\repos\\PizzeriaVisual\\PizzeriaVisual\\Databases\\Order.json", o => o.Id == orderId).FirstOrDefault();
            if (a.Status == 1) { 
                a.Status = 2;
                a.sendMessage();
            }
            return 1;
        }
    }
}
