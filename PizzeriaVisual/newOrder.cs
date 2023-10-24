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
    public partial class newOrder : Form
    {
        OrderServices orderServices;
        Client client;
        Clerk clerk;
        public newOrder(Client clientCom, Clerk clerkCom)
        {
            client = clientCom;
            clerk = clerkCom;
            InitializeComponent();
            orderServices = new OrderServices();
        }

        private void newOrder_Load(object sender, EventArgs e)
        {
            // Remplissez la colonne "Toppings" de la DataGridViewComboBoxColumn avec les toppings disponibles.

            // Récupérez la colonne "Toppings" de votre DataGridView
            DataGridViewCheckBoxColumn CheeseColumn = (DataGridViewCheckBoxColumn)dataGridView1.Columns["Cheese"];
            DataGridViewCheckBoxColumn pepperoniColumn = (DataGridViewCheckBoxColumn)dataGridView1.Columns["Pepperoni"];
            DataGridViewCheckBoxColumn salmonColumn = (DataGridViewCheckBoxColumn)dataGridView1.Columns["Salmon"];


            DataGridViewComboBoxColumn sizeColuln = (DataGridViewComboBoxColumn)dataGridView1.Columns["Size"];

            sizeColuln.Items.Add("Small");
            sizeColuln.Items.Add("Medium");
            sizeColuln.Items.Add("Large");

            DataGridViewComboBoxColumn drinkColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["Drink"];

            drinkColumn.Items.Add("Cola");
            drinkColumn.Items.Add("Orange Juice");
            drinkColumn.Items.Add("Lemonade");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ajouter une nouvelle ligne à la DataGridView
            int rowIndex = dataGridView1.Rows.Add();

            // Définir des valeurs initiales pour les cellules de la nouvelle ligne
            dataGridView1.Rows[rowIndex].Cells["Size"].Value = "Small";
            dataGridView1.Rows[rowIndex].Cells["Quantité"].Value = 1;
            // Assurez-vous que "Toppings" est configuré comme DataGridViewComboBoxColumn pour pouvoir sélectionner un topping.

            // Si vous utilisez une DataGridViewComboBoxColumn, définissez la valeur sélectionnée comme suit :
            DataGridViewComboBoxColumn toppingsColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["Toppings"];
            dataGridView1.Rows[rowIndex].Cells[toppingsColumn.DisplayIndex].Value = "Cheese";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> drinks = new List<string>();
            List<Pizza> pizzas = new List<Pizza>();
            DateTime date = DateTime.Now;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["size"].Value != null)
                {
                    string size = row.Cells["Size"].Value as string;

                    List<string> toppingList = new List<string>();

                    // Vérifiez chaque case à cocher de topping
                    if (row.Cells["Cheese"].Value is bool cheeseChecked && cheeseChecked)
                    {
                        toppingList.Add("Cheese");
                        Console.WriteLine("Cheese");
                    }
                    if (row.Cells["Pepperoni"].Value is bool pepperoniChecked && pepperoniChecked)
                    {
                        toppingList.Add("Pepperoni");
                        Console.WriteLine("Pepperoni");
                    }
                    if (row.Cells["Salmon"].Value is bool salmonChecked && salmonChecked)
                    {
                        toppingList.Add("Salmon");
                        Console.WriteLine("Salmon");
                    }

                    Console.WriteLine("Topping list: " + string.Join(", ", toppingList));
                    Console.WriteLine("Size: " + size);
                    Pizza pizza = new Pizza(toppingList, size);
                    Console.WriteLine("Pizza created size: " + pizza.Size);
                    Console.WriteLine("Pizza created topping: " + string.Join(", ", pizza.Toppings));

                    pizzas.Add(pizza);

                    string drink = row.Cells["Drink"].Value as string;
                    Console.Write("drink Value",drink);
                    
                    if (drink == null)
                    {
                        drinks.Add("None");
                        Console.WriteLine("nooooooonnnneeee");
                    }
                    else { drinks.Add(drink); }
                   
                }
            }

            orderServices.CreateOrder(date, drinks, pizzas, 0, client.Name, clerk.Name, client.Id, clerk.Id, -1);

        }



    }
}
