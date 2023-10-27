using PizzeriaVisual.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzeriaVisual
{
    public partial class ClientOperations : Form
    {
        private Client client;
        private List<string> privateMessage;
        private CommunicationServices communicationServices;
        public ClientOperations(Client ClientRecieve)
        {
            client = ClientRecieve;
            communicationServices = new CommunicationServices();
            InitializeComponent();
        }

        private async void ClientOperations_Load(object sender, EventArgs e)
        {
            privateMessage = await Task.Run(() => communicationServices.ProcessAllMessages("client_" + client.Id));
            foreach (string priv in privateMessage)
            {
                Console.WriteLine(priv);
            };
            label2.Text = string.Join(Environment.NewLine, privateMessage);
        }
    }
}
