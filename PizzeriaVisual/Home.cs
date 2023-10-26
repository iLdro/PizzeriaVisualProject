using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzeriaVisual
{
    public partial class Home : Form
    {
        private Timer timer1;
        public Home()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Interval = 10000; // Par exemple, rafraîchir toutes les secondes
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClienLogin().Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clerckToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ClerkLogin().Show();
        }

        private void loginToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new DeliveryLogin().Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //PerfClerk here
        }


        private void label2_Click(object sender, EventArgs e)
        {
            //AverageOrderPrice
        }
        private void label3_Click(object sender, EventArgs e)
        {
            //MostSuccessfullcustomer
        }
        private void UpdateAverageOrderPrice()
        {
            // Récupérez toutes les commandes
            List<Order> orders = DatabaseManager.AllItems<Order>("C:\\Users\\adria\\source\\repos\\skjdfkjsdfh\\PizzeriaVisual\\Databases\\Order.json");

            // Vérifiez s'il y a des commandes
            if (orders.Count > 0)
            {
                // Calculez le prix moyen
                double averagePrice = orders.Average(o => o.TotalPrice);

                // Mettez à jour le label
                label1.Text = $"Prix moyen des commandes : {averagePrice}";
            }
            else
            {
                label1.Text = "Aucune commande à afficher";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateAverageOrderPrice();
            CalculateMostActiveClerk();
            BestCustomer();
        }
        private void CalculateMostActiveClerk()
        {
            List<Order> orders = DatabaseManager.AllItems<Order>("C:\\Users\\adria\\source\\repos\\skjdfkjsdfh\\PizzeriaVisual\\Databases\\Order.json");


            var topClerks = orders
                .Where(order => order.Status == 2)
                .GroupBy(order => order.ClerkName)
                .Select(group => new
                {
                    ClerkName = group.Key,
                    TotalOrders = group.Count()
                })
                .OrderByDescending(c => c.TotalOrders)
                .Take(3);


            string clerksString = "Top 3 best Clerks: \n";


            foreach (var clerk in topClerks)
            {
                clerksString += $"Clerk: {clerk.ClerkName}\n";
            }

            label2.Text = clerksString;
        }

        public void BestCustomer()
        {
            List<Order> orders = DatabaseManager.AllItems<Order>("C:\\Users\\adria\\source\\repos\\skjdfkjsdfh\\PizzeriaVisual\\Databases\\Order.json");
            // Utilize LINQ to find the customer who spent the most money on orders and their most expensive order.
            var bestCustomerInfo = orders
                .GroupBy(order => order.ClientId) // Group by ClientId
                .Select(group => new
                {
                    ClientId = group.Key,
                    TotalSpent = group.Sum(order => order.TotalPrice),
                    MostExpensiveOrder = group.OrderByDescending(order => order.TotalPrice).FirstOrDefault()
                })
                .OrderByDescending(c => c.TotalSpent) // Sort by total amount spent in descending order
                .FirstOrDefault(); // Take the first (top) customer

            // Check if a best customer was found
            if (bestCustomerInfo != null)
            {
                string Bcusto = "";
                // Retrieve the customer's name based on ClientId
                var bestCustomerName = orders
                    .Where(order => order.ClientId == bestCustomerInfo.ClientId)
                    .Select(order => order.ClientName)
                    .FirstOrDefault();

                // Output the best customer's id, name, and most expensive order details
                Console.WriteLine($"Best Customer Id: {bestCustomerInfo.ClientId}");
                Bcusto = $"Best Customer Name: {bestCustomerName} \n";

                if (bestCustomerInfo.MostExpensiveOrder != null)
                {
                    // Output the most expensive order details
                    Console.WriteLine($"Most Expensive Order Id: {bestCustomerInfo.MostExpensiveOrder.Id}");
                    Bcusto += $"Higher price spent on an order: {bestCustomerInfo.MostExpensiveOrder.TotalPrice}";

                }
                else
                {
                    Console.WriteLine("No orders found for the best customer.");
                }
                label3.Text = Bcusto;
            }
            else
            {
                Console.WriteLine("No orders found in the database.");
            }


        }

    }
}
