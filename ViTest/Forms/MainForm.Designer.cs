namespace ViTest
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            paymentsButton = new Button();
            arrivalButton = new Button();
            label1 = new Label();
            orderButton = new Button();
            closeButton = new Button();
            panel2 = new Panel();
            orderLabel = new Label();
            confirmOrderButton = new Button();
            mainDataGridView = new DataGridView();
            confirmArrivalButton = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainDataGridView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 39, 40);
            panel1.Controls.Add(paymentsButton);
            panel1.Controls.Add(arrivalButton);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(orderButton);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(150, 782);
            panel1.TabIndex = 5;
            // 
            // paymentsButton
            // 
            paymentsButton.FlatAppearance.BorderSize = 0;
            paymentsButton.FlatStyle = FlatStyle.Flat;
            paymentsButton.Font = new Font("Segoe UI Semibold", 15.2F, FontStyle.Bold);
            paymentsButton.ForeColor = SystemColors.AppWorkspace;
            paymentsButton.Location = new Point(3, 204);
            paymentsButton.Name = "paymentsButton";
            paymentsButton.Size = new Size(144, 58);
            paymentsButton.TabIndex = 8;
            paymentsButton.Text = "Платежи";
            paymentsButton.UseVisualStyleBackColor = true;
            paymentsButton.Click += paymentsButton_Click;
            // 
            // arrivalButton
            // 
            arrivalButton.FlatAppearance.BorderSize = 0;
            arrivalButton.FlatStyle = FlatStyle.Flat;
            arrivalButton.Font = new Font("Segoe UI Semibold", 15.2F, FontStyle.Bold);
            arrivalButton.ForeColor = SystemColors.AppWorkspace;
            arrivalButton.Location = new Point(3, 140);
            arrivalButton.Name = "arrivalButton";
            arrivalButton.Size = new Size(144, 58);
            arrivalButton.TabIndex = 7;
            arrivalButton.Text = "Приходы";
            arrivalButton.UseVisualStyleBackColor = true;
            arrivalButton.Click += arrivalButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = SystemColors.AppWorkspace;
            label1.Location = new Point(3, 24);
            label1.Name = "label1";
            label1.Size = new Size(142, 46);
            label1.TabIndex = 6;
            label1.Text = "МЕНЮ:";
            // 
            // orderButton
            // 
            orderButton.FlatAppearance.BorderSize = 0;
            orderButton.FlatStyle = FlatStyle.Flat;
            orderButton.Font = new Font("Segoe UI Semibold", 15.2F, FontStyle.Bold);
            orderButton.ForeColor = SystemColors.AppWorkspace;
            orderButton.Location = new Point(3, 76);
            orderButton.Name = "orderButton";
            orderButton.Size = new Size(144, 58);
            orderButton.TabIndex = 5;
            orderButton.Text = "Заказы";
            orderButton.UseVisualStyleBackColor = true;
            orderButton.Click += orderButton_Click;
            // 
            // closeButton
            // 
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            closeButton.ForeColor = SystemColors.AppWorkspace;
            closeButton.Location = new Point(1258, 12);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(62, 62);
            closeButton.TabIndex = 5;
            closeButton.Text = "X";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(178, 8, 55);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(150, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1184, 10);
            panel2.TabIndex = 7;
            // 
            // orderLabel
            // 
            orderLabel.AutoSize = true;
            orderLabel.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            orderLabel.ForeColor = Color.FromArgb(64, 64, 64);
            orderLabel.Location = new Point(153, 12);
            orderLabel.Name = "orderLabel";
            orderLabel.Size = new Size(521, 64);
            orderLabel.TabIndex = 8;
            orderLabel.Text = "Для начала работы выберите страницу\r\nиз меню слева:";
            // 
            // confirmOrderButton
            // 
            confirmOrderButton.Enabled = false;
            confirmOrderButton.FlatAppearance.BorderSize = 0;
            confirmOrderButton.FlatStyle = FlatStyle.Flat;
            confirmOrderButton.Font = new Font("Segoe UI Semibold", 15.2F, FontStyle.Bold);
            confirmOrderButton.ForeColor = Color.FromArgb(64, 64, 64);
            confirmOrderButton.Location = new Point(885, 12);
            confirmOrderButton.Name = "confirmOrderButton";
            confirmOrderButton.Size = new Size(367, 62);
            confirmOrderButton.TabIndex = 9;
            confirmOrderButton.Text = "Подтвердить выбор заказа.";
            confirmOrderButton.UseVisualStyleBackColor = true;
            confirmOrderButton.Visible = false;
            confirmOrderButton.Click += confirmOrderButton_Click;
            // 
            // mainDataGridView
            // 
            mainDataGridView.AllowUserToAddRows = false;
            mainDataGridView.AllowUserToDeleteRows = false;
            mainDataGridView.AllowUserToResizeColumns = false;
            mainDataGridView.AllowUserToResizeRows = false;
            mainDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            mainDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            mainDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            mainDataGridView.Location = new Point(156, 79);
            mainDataGridView.Name = "mainDataGridView";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            mainDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            mainDataGridView.RowHeadersWidth = 51;
            mainDataGridView.Size = new Size(1164, 691);
            mainDataGridView.TabIndex = 10;
            // 
            // confirmArrivalButton
            // 
            confirmArrivalButton.Enabled = false;
            confirmArrivalButton.FlatAppearance.BorderSize = 0;
            confirmArrivalButton.FlatStyle = FlatStyle.Flat;
            confirmArrivalButton.Font = new Font("Segoe UI Semibold", 15.2F, FontStyle.Bold);
            confirmArrivalButton.ForeColor = Color.FromArgb(64, 64, 64);
            confirmArrivalButton.Location = new Point(862, 12);
            confirmArrivalButton.Name = "confirmArrivalButton";
            confirmArrivalButton.Size = new Size(390, 62);
            confirmArrivalButton.TabIndex = 11;
            confirmArrivalButton.Text = "Подтвердить выбор прихода.";
            confirmArrivalButton.UseVisualStyleBackColor = true;
            confirmArrivalButton.Visible = false;
            confirmArrivalButton.Click += confirmArrivalButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1334, 782);
            Controls.Add(confirmArrivalButton);
            Controls.Add(mainDataGridView);
            Controls.Add(confirmOrderButton);
            Controls.Add(orderLabel);
            Controls.Add(closeButton);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mainDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Button closeButton;
        private Panel panel2;
        private Button paymentsButton;
        private Button arrivalButton;
        private Label label1;
        private Button orderButton;
        private Label orderLabel;
        private Button confirmOrderButton;
        private DataGridView mainDataGridView;
        private Button confirmArrivalButton;
    }
}
