namespace ViTest.Forms
{
    partial class AddOrderForm
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
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            totalAmountNumBox = new NumericUpDown();
            amountPaidNumBox = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            exitButton = new Button();
            confirmButton = new Button();
            ((System.ComponentModel.ISupportInitialize)totalAmountNumBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountPaidNumBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(362, 27);
            label1.TabIndex = 0;
            label1.Text = "Форма для добавления заказа";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(266, 80);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(212, 27);
            dateTimePicker1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(212, 28);
            label2.TabIndex = 3;
            label2.Text = "Выберите дату заказа:";
            // 
            // totalAmountNumBox
            // 
            totalAmountNumBox.Location = new Point(266, 168);
            totalAmountNumBox.Name = "totalAmountNumBox";
            totalAmountNumBox.Size = new Size(212, 27);
            totalAmountNumBox.TabIndex = 4;
            // 
            // amountPaidNumBox
            // 
            amountPaidNumBox.Location = new Point(266, 256);
            amountPaidNumBox.Name = "amountPaidNumBox";
            amountPaidNumBox.Size = new Size(212, 27);
            amountPaidNumBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 163);
            label3.Name = "label3";
            label3.Size = new Size(214, 28);
            label3.TabIndex = 6;
            label3.Text = "Введите сумму заказа:\r\n";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 251);
            label4.Name = "label4";
            label4.Size = new Size(201, 56);
            label4.TabIndex = 7;
            label4.Text = "Сколько выплачено:\r\n(Если выплачено)\r\n";
            // 
            // exitButton
            // 
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Location = new Point(461, 12);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(35, 35);
            exitButton.TabIndex = 8;
            exitButton.Text = "X";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // confirmButton
            // 
            confirmButton.FlatAppearance.BorderSize = 0;
            confirmButton.FlatStyle = FlatStyle.Flat;
            confirmButton.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            confirmButton.ForeColor = SystemColors.ControlDarkDark;
            confirmButton.Location = new Point(266, 320);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(212, 55);
            confirmButton.TabIndex = 9;
            confirmButton.Text = "Подтвердить";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // AddOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 410);
            Controls.Add(confirmButton);
            Controls.Add(exitButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(amountPaidNumBox);
            Controls.Add(totalAmountNumBox);
            Controls.Add(label2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddOrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddArrivalForm";
            ((System.ComponentModel.ISupportInitialize)totalAmountNumBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountPaidNumBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private NumericUpDown totalAmountNumBox;
        private NumericUpDown amountPaidNumBox;
        private Label label3;
        private Label label4;
        private Button exitButton;
        private Button confirmButton;
    }
}