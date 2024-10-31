namespace WinFormsApp1
{
    partial class management
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
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBoxNameRental = new TextBox();
            textBoxAddress = new TextBox();
            comboBoxTypes = new ComboBox();
            label5 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 25);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 384);
            listBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(202, 25);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "Nome";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(186, 164);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 2;
            label2.Text = "Reservas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(191, 69);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 3;
            label3.Text = "Morada";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(213, 111);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 4;
            label4.Text = "Tipo";
            // 
            // textBoxNameRental
            // 
            textBoxNameRental.Location = new Point(258, 22);
            textBoxNameRental.Name = "textBoxNameRental";
            textBoxNameRental.Size = new Size(486, 27);
            textBoxNameRental.TabIndex = 5;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(258, 66);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(486, 27);
            textBoxAddress.TabIndex = 6;
            // 
            // comboBoxTypes
            // 
            comboBoxTypes.FormattingEnabled = true;
            comboBoxTypes.Location = new Point(258, 110);
            comboBoxTypes.Name = "comboBoxTypes";
            comboBoxTypes.Size = new Size(151, 28);
            comboBoxTypes.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(481, 113);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 9;
            label5.Text = "Preço p/ Noite";
            label5.Click += label5_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(593, 108);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 27);
            textBox1.TabIndex = 10;
            // 
            // management
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(comboBoxTypes);
            Controls.Add(textBoxAddress);
            Controls.Add(textBoxNameRental);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Name = "management";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxNameRental;
        private TextBox textBoxAddress;
        private ComboBox comboBoxTypes;
        private Label label5;
        private TextBox textBox1;
    }
}