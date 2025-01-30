namespace ViTest.Forms
{
    partial class AddArrivalForm
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
            closeButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dateTimePicker = new DateTimePicker();
            totalAmountNumBox = new NumericUpDown();
            remainingAmountNumBox = new NumericUpDown();
            confirmButton = new Button();
            ((System.ComponentModel.ISupportInitialize)totalAmountNumBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)remainingAmountNumBox).BeginInit();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Location = new Point(461, 12);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(35, 35);
            closeButton.TabIndex = 0;
            closeButton.Text = "X";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 13.8F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(384, 27);
            label1.TabIndex = 1;
            label1.Text = "Форма для добавления прихода";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(232, 28);
            label2.TabIndex = 2;
            label2.Text = "Выберите дату прихода:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 163);
            label3.Name = "label3";
            label3.Size = new Size(250, 28);
            label3.TabIndex = 3;
            label3.Text = "Выберите сумму прихода:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 251);
            label4.Name = "label4";
            label4.Size = new Size(241, 84);
            label4.TabIndex = 4;
            label4.Text = "Введите баланс прихода:\r\n(Или оставьте \r\nбез изменений)";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(266, 80);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(212, 27);
            dateTimePicker.TabIndex = 5;
            // 
            // totalAmountNumBox
            // 
            totalAmountNumBox.Location = new Point(266, 168);
            totalAmountNumBox.Name = "totalAmountNumBox";
            totalAmountNumBox.Size = new Size(212, 27);
            totalAmountNumBox.TabIndex = 6;
            // 
            // remainingAmountNumBox
            // 
            remainingAmountNumBox.Location = new Point(266, 256);
            remainingAmountNumBox.Name = "remainingAmountNumBox";
            remainingAmountNumBox.Size = new Size(212, 27);
            remainingAmountNumBox.TabIndex = 7;
            // 
            // confirmButton
            // 
            confirmButton.FlatAppearance.BorderSize = 0;
            confirmButton.FlatStyle = FlatStyle.Flat;
            confirmButton.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            confirmButton.ForeColor = SystemColors.ControlDarkDark;
            confirmButton.Location = new Point(266, 320);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(212, 55);
            confirmButton.TabIndex = 8;
            confirmButton.Text = "Подтвердить";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // AddArrivalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 410);
            Controls.Add(confirmButton);
            Controls.Add(remainingAmountNumBox);
            Controls.Add(totalAmountNumBox);
            Controls.Add(dateTimePicker);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(closeButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddArrivalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddArrivalForm";
            ((System.ComponentModel.ISupportInitialize)totalAmountNumBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)remainingAmountNumBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button closeButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePicker;
        private NumericUpDown totalAmountNumBox;
        private NumericUpDown remainingAmountNumBox;
        private Button confirmButton;
    }
}