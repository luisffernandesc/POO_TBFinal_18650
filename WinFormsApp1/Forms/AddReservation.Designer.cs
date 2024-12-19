namespace WinFormsApp1.Forms
{
    partial class AddReservation
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
            checkOutDatePicker = new DateTimePicker();
            label1 = new Label();
            checkInDatePicker = new DateTimePicker();
            label2 = new Label();
            totalPriceTextBox = new TextBox();
            label3 = new Label();
            pricePerNightTextBox = new TextBox();
            label4 = new Label();
            clientNameTextBox = new TextBox();
            label5 = new Label();
            clientContactTextBox = new TextBox();
            label6 = new Label();
            saveButton = new Button();
            propertyNameLabel = new Label();
            listBox1 = new ListBox();
            newClientButton = new Button();
            saveNewClientButton = new Button();
            SuspendLayout();
            // 
            // checkOutDatePicker
            // 
            checkOutDatePicker.Location = new Point(330, 130);
            checkOutDatePicker.Name = "checkOutDatePicker";
            checkOutDatePicker.Size = new Size(250, 27);
            checkOutDatePicker.TabIndex = 0;
            checkOutDatePicker.ValueChanged += checkOutDatePicker_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(330, 96);
            label1.Name = "label1";
            label1.Size = new Size(135, 20);
            label1.TabIndex = 1;
            label1.Text = "Data de Check-Out";
            // 
            // checkInDatePicker
            // 
            checkInDatePicker.Location = new Point(12, 130);
            checkInDatePicker.Name = "checkInDatePicker";
            checkInDatePicker.Size = new Size(250, 27);
            checkInDatePicker.TabIndex = 2;
            checkInDatePicker.ValueChanged += checkInDatePicker_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 96);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 3;
            label2.Text = "Data de Check-In";
            // 
            // totalPriceTextBox
            // 
            totalPriceTextBox.Location = new Point(330, 199);
            totalPriceTextBox.Name = "totalPriceTextBox";
            totalPriceTextBox.ReadOnly = true;
            totalPriceTextBox.Size = new Size(125, 27);
            totalPriceTextBox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 176);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 5;
            label3.Text = "Preço Total";
            // 
            // pricePerNightTextBox
            // 
            pricePerNightTextBox.Location = new Point(12, 199);
            pricePerNightTextBox.Name = "pricePerNightTextBox";
            pricePerNightTextBox.ReadOnly = true;
            pricePerNightTextBox.Size = new Size(125, 27);
            pricePerNightTextBox.TabIndex = 6;
            pricePerNightTextBox.TextChanged += pricePerNightTextBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 176);
            label4.Name = "label4";
            label4.Size = new Size(106, 20);
            label4.TabIndex = 7;
            label4.Text = "Preço p/ Noite";
            // 
            // clientNameTextBox
            // 
            clientNameTextBox.Location = new Point(12, 279);
            clientNameTextBox.Name = "clientNameTextBox";
            clientNameTextBox.ReadOnly = true;
            clientNameTextBox.Size = new Size(568, 27);
            clientNameTextBox.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 256);
            label5.Name = "label5";
            label5.Size = new Size(125, 20);
            label5.TabIndex = 9;
            label5.Text = "Nome do Cliente:";
            // 
            // clientContactTextBox
            // 
            clientContactTextBox.Location = new Point(12, 347);
            clientContactTextBox.Name = "clientContactTextBox";
            clientContactTextBox.ReadOnly = true;
            clientContactTextBox.Size = new Size(568, 27);
            clientContactTextBox.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 324);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 11;
            label6.Text = "Contacto:";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(638, 22);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(150, 29);
            saveButton.TabIndex = 12;
            saveButton.Text = "Guardar Reserva";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // propertyNameLabel
            // 
            propertyNameLabel.AutoSize = true;
            propertyNameLabel.Font = new Font("Segoe UI", 13F);
            propertyNameLabel.Location = new Point(12, 18);
            propertyNameLabel.Name = "propertyNameLabel";
            propertyNameLabel.Size = new Size(229, 30);
            propertyNameLabel.TabIndex = 13;
            propertyNameLabel.Text = "Nome da Propriedade";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(638, 130);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 224);
            listBox1.TabIndex = 14;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // newClientButton
            // 
            newClientButton.Location = new Point(714, 360);
            newClientButton.Name = "newClientButton";
            newClientButton.Size = new Size(74, 29);
            newClientButton.TabIndex = 15;
            newClientButton.Text = "Novo";
            newClientButton.UseVisualStyleBackColor = true;
            newClientButton.Click += newClientButton_Click;
            // 
            // saveNewClientButton
            // 
            saveNewClientButton.Enabled = false;
            saveNewClientButton.Location = new Point(638, 360);
            saveNewClientButton.Name = "saveNewClientButton";
            saveNewClientButton.Size = new Size(74, 29);
            saveNewClientButton.TabIndex = 16;
            saveNewClientButton.Text = "Guardar";
            saveNewClientButton.UseVisualStyleBackColor = true;
            saveNewClientButton.Click += saveNewClientButton_Click;
            // 
            // AddReservation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(saveNewClientButton);
            Controls.Add(newClientButton);
            Controls.Add(listBox1);
            Controls.Add(propertyNameLabel);
            Controls.Add(saveButton);
            Controls.Add(label6);
            Controls.Add(clientContactTextBox);
            Controls.Add(label5);
            Controls.Add(clientNameTextBox);
            Controls.Add(label4);
            Controls.Add(pricePerNightTextBox);
            Controls.Add(label3);
            Controls.Add(totalPriceTextBox);
            Controls.Add(label2);
            Controls.Add(checkInDatePicker);
            Controls.Add(label1);
            Controls.Add(checkOutDatePicker);
            Name = "AddReservation";
            Text = "Reserva";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker checkOutDatePicker;
        private Label label1;
        private DateTimePicker checkInDatePicker;
        private Label label2;
        private TextBox totalPriceTextBox;
        private Label label3;
        private TextBox pricePerNightTextBox;
        private Label label4;
        private TextBox clientNameTextBox;
        private Label label5;
        private TextBox clientContactTextBox;
        private Label label6;
        private Button saveButton;
        private Label propertyNameLabel;
        private ListBox listBox1;
        private Button newClientButton;
        private Button saveNewClientButton;
    }
}