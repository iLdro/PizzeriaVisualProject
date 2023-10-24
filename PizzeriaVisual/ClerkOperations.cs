using PizzeriaVisual.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzeriaVisual
{
    public partial class ClerkOperations : Form
    {
        private ClientServices clientServices;
        private OrderServices orderServices;
        private Clerk clerk;
        public ClerkOperations(Clerk clerkGet)
        {
            InitializeComponent();
            this.clerk = clerkGet;
            Console.WriteLine(clerk.Name);
            clientServices = new ClientServices();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var phoneNumber = textBox1.Text;
            Console.WriteLine(phoneNumber);
            Client client = clientServices.FindClientByPhoneNumber(phoneNumber);
            if (client == null)
            {
                MessageBox.Show("Client not found");
                return;
            }
            else
            {
                var newOrder = new newOrder(client, clerk);
                newOrder.Show();
                this.Hide();
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var clerkLogin = new ClerkLogin();
            clerkLogin.Show();
            this.Hide();
        }

        private void ClerkOperations_Load(object sender, EventArgs e)
        {

        }
    }
}
