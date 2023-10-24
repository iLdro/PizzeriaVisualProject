using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzeriaVisual.Interfaces;

namespace PizzeriaVisual.Services
{
    internal class ClientServices : IClientServices
    {
        public List<Client> clients;
        public ClientServices()
        {
            clients = new List<Client>();
            clients = DatabaseManager.AllItems<Client>("C:\\Users\\jukle\\source\\repos\\PizzeriaVisual\\PizzeriaVisual\\Databases\\Client.json");
            Console.WriteLine(clients);
        }

        public Client CreateClient(string name, string surname, string address, string phoneNumber)
        {
            Console.WriteLine(clients);
            Console.WriteLine("Nombre de clients avant l'ajout : " + clients.Count);
            Console.WriteLine("ID du dernier client : " + (clients.Count > 0 ? clients.Max(c => c.Id) : 0));

            int lastClientId = clients.Count > 0 ? clients.Max(c => c.Id) : 0;
            int newClientId = lastClientId + 1;

            Client client = new Client(newClientId, name, surname, address, phoneNumber);

            clients.Add(client);

            DatabaseManager.CreateItem(client, "C:\\Users\\jukle\\source\\repos\\PizzeriaVisual\\PizzeriaVisual\\Databases\\Client.json");

            return client;
        }


        public Client FindClientByPhoneNumber(string phoneNumber)
        {
            Client a = DatabaseManager.FindBy<Client>("C:\\Users\\jukle\\source\\repos\\PizzeriaVisual\\PizzeriaVisual\\Databases\\Client.json", c => c.PhoneNumber == phoneNumber).FirstOrDefault();
            Console.WriteLine(a.Id);
            return a;
        }
    }

}
