using System;
using PizzeriaVisual.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaVisual.Services
{
    internal class DeliveryServices : IDeliveryServices
    {
        public List<Delivery> delivers;

        public DeliveryServices()
        {
            delivers = new List<Delivery>();
            delivers = DatabaseManager.AllItems<Delivery>("C:\\Users\\adria\\source\\repos\\skjdfkjsdfh\\PizzeriaVisual\\Databases\\Delivery.json");
            Console.WriteLine(delivers);
        }

        public int CreateDelivery(string name, string surname, string phoneNumber)
        {
            int lastDeliveryId = delivers.Count > 0 ? delivers.Max(c => c.Id) : 0;
            int newDeliveryId = lastDeliveryId + 1;

            Delivery delivery = new Delivery(newDeliveryId, name, surname,  phoneNumber);

            DatabaseManager.CreateItem(delivery, "C:\\Users\\adria\\source\\repos\\skjdfkjsdfh\\PizzeriaVisual\\Databases\\Delivery.json");
            return newDeliveryId;
        }
    }

}