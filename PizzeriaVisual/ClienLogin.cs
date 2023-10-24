using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PizzeriaVisual.Interfaces;
using PizzeriaVisual.Services;

namespace PizzeriaVisual
{
    public partial class ClienLogin : Form
    {
        private ClientServices clientServices;
        public ClienLogin()
        {
            InitializeComponent();
            clientServices = new ClientServices();
        }

        private void ClienLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var surname = textBox2.Text;
            var address = textBox3.Text;
            var streetnumber = textBox4.Text;
            var streetname = textBox5.Text;
            var city = textBox6.Text;
            var date = dateTimePicker1.Value;
            var PhoneNumber = textBox7.Text;

            clientServices.CreateClient(name, surname, address, PhoneNumber);

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            new Home().Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var PhoneNumber = textBox6.Text;
            Console.WriteLine(PhoneNumber);
            var client = clientServices.FindClientByPhoneNumber(PhoneNumber);
            Console.WriteLine(client);
            ClientMessage clientMessageForm = new ClientMessage();

            clientMessageForm.Initialize(PhoneNumber);  
            clientMessageForm.Show();
        }
    }
}
