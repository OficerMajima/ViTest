namespace ViTest.Forms
{
    partial class PayForm
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
            button1 = new Button();
            payNumBox = new NumericUpDown();
            arrivalOrderLabel = new Label();
            payButton = new Button();
            ((System.ComponentModel.ISupportInitialize)payNumBox).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(352, 10);
            button1.Margin = new Padding(1);
            button1.Name = "button1";
            button1.Size = new Size(31, 29);
            button1.TabIndex = 0;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // payNumBox
            // 
            payNumBox.Location = new Point(39, 145);
            payNumBox.Margin = new Padding(30, 3, 30, 3);
            payNumBox.Name = "payNumBox";
            payNumBox.Size = new Size(300, 27);
            payNumBox.TabIndex = 1;
            // 
            // arrivalOrderLabel
            // 
            arrivalOrderLabel.AutoSize = true;
            arrivalOrderLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            arrivalOrderLabel.Location = new Point(39, 42);
            arrivalOrderLabel.Name = "arrivalOrderLabel";
            arrivalOrderLabel.Size = new Size(270, 46);
            arrivalOrderLabel.TabIndex = 2;
            arrivalOrderLabel.Text = "Введите сумму которую \r\nВы хотите потратить из прихода:";
            // 
            // payButton
            // 
            payButton.FlatAppearance.BorderSize = 0;
            payButton.FlatStyle = FlatStyle.Flat;
            payButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            payButton.ForeColor = Color.FromArgb(64, 64, 64);
            payButton.Location = new Point(102, 178);
            payButton.Name = "payButton";
            payButton.Size = new Size(185, 60);
            payButton.TabIndex = 3;
            payButton.Text = "ОПЛАТИТЬ";
            payButton.UseVisualStyleBackColor = true;
            payButton.Click += payButton_Click;
            // 
            // PayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 250);
            Controls.Add(payButton);
            Controls.Add(arrivalOrderLabel);
            Controls.Add(payNumBox);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PayForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PayForm";
            ((System.ComponentModel.ISupportInitialize)payNumBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private NumericUpDown payNumBox;
        private Label arrivalOrderLabel;
        private Button payButton;
    }
}