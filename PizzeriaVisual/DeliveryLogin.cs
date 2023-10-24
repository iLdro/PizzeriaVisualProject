using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PizzeriaVisual.Services;

namespace PizzeriaVisual
{
    public partial class DeliveryLogin : Form
    {
        private DeliveryServices deliveryServices;
        public DeliveryLogin()
        {
            InitializeComponent();
            deliveryServices = new DeliveryServices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var surname = textBox2.Text;
            var phoneNumber = textBox3.Text;

            var result = deliveryServices.CreateDelivery(name, surname, phoneNumber);
            Console.WriteLine(result);
        }

        private void DeliveryLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var phone = textBox4.Text;
            var result = deliveryServices.FindDeliveryByPhoneNumber(phone);
            if (result != null)
            {
                new DeliveryOperations(result).Show();
            }
            else
            {
                MessageBox.Show("Delivery not found");
            }
        }
    }
}
