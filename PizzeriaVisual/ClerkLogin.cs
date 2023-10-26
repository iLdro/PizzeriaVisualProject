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
    public partial class ClerkLogin : Form
    {
        private ClerkServices clerkServices;

        public ClerkLogin()
        {
            InitializeComponent();
            clerkServices = new ClerkServices();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var surname = textBox2.Text;
            var restaurant = textBox3.Text;
            var address = textBox4.Text;

            var result = clerkServices.CreateClerk(name, surname, restaurant, address);

            if (result.Id != null)
            {
                Console.WriteLine("Clerk created");
            }
        }

        private void ClerkLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var phoneNumber = textBox5.Text;
            var clerk = clerkServices.FindClerkByPhoneNumber(phoneNumber);
            if (clerk == null)
            {
                MessageBox.Show("Clerk not found");
                return;
            }
            else if (clerk != null)
            {
                var clerkOperations = new ClerkOperations(clerk);
                clerkOperations.Show();
                this.Close();
            }

        }
    }
}
