namespace PizzeriaVisual
{
    partial class newOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Size = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Cheese = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Pepperoni = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Salmon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Drink = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Size,
            this.Cheese,
            this.Pepperoni,
            this.Salmon,
            this.Drink});
            this.dataGridView1.Location = new System.Drawing.Point(28, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(550, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add pizza";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(492, 296);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Create Order";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            // 
            // Cheese
            // 
            this.Cheese.HeaderText = "Cheese";
            this.Cheese.Name = "Cheese";
            // 
            // Pepperoni
            // 
            this.Pepperoni.HeaderText = "Pepperoni";
            this.Pepperoni.Name = "Pepperoni";
            // 
            // Salmon
            // 
            this.Salmon.HeaderText = "Salmon";
            this.Salmon.Name = "Salmon";
            // 
            // Drink
            // 
            this.Drink.HeaderText = "Drink";
            this.Drink.Name = "Drink";
            // 
            // newOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "newOrder";
            this.Text = "New Order";
            this.Load += new System.EventHandler(this.newOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Size;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cheese;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pepperoni;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Salmon;
        private System.Windows.Forms.DataGridViewComboBoxColumn Drink;
    }
}