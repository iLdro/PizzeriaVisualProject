using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzeriaVisual.Interfaces;


namespace PizzeriaVisual.Services
{
    internal class ClerkServices : IClerkServices
    {

        public List<Clerk> clerks;

        public ClerkServices()
        {
            clerks = new List<Clerk>();
            clerks = DatabaseManager.AllItems<Clerk>("C:\\Users\\adria\\source\\repos\\skjdfkjsdfh\\PizzeriaVisual\\Databases\\Clerk.json");
            Console.WriteLine(clerks);

        }
        public Clerk CreateClerk(string name, string surname, string address, string phoneNumber)
        {
            int lastClerkId = clerks.Count > 0 ? clerks.Max(c => c.Id) : 0;
            int newClerkId = lastClerkId + 1;

            Clerk clerk = new Clerk(newClerkId, name, surname, address, phoneNumber);
            clerks.Add(clerk);

            DatabaseManager.CreateItem(clerk, "C:\\Users\\adria\\source\\repos\\skjdfkjsdfh\\PizzeriaVisual\\Databases\\Clerk.json");
            return clerk;
        }

        public Clerk FindClerkByPhoneNumber(string phoneNumber)
        {
            Clerk a = DatabaseManager.FindBy<Clerk>("C:\\Users\\adria\\source\\repos\\skjdfkjsdfh\\PizzeriaVisual\\Databases\\Client.json", c => c.PhoneNumber == phoneNumber).FirstOrDefault();
            Console.WriteLine(a.Id);
            return a;
        }
    }
}
