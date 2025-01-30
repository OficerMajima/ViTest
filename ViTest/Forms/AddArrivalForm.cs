using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViTest.Domain;

namespace ViTest.Forms
{
    public partial class AddArrivalForm : Form
    {
        ViTestDbContext _viTestDbContext;
        public AddArrivalForm(ViTestDbContext context)
        {
            _viTestDbContext = context;
            InitializeComponent();
            totalAmountNumBox.Maximum = 1_000_000;
            remainingAmountNumBox.Maximum = totalAmountNumBox.Maximum;
        }


        private async void confirmButton_Click(object sender, EventArgs e)
        {
            if (remainingAmountNumBox.Value > totalAmountNumBox.Value)
            {
                MessageBox.Show("Остаток в приходе не может превышать общую сумму прихода.", "Ошибка");
                return;
            }
            if (remainingAmountNumBox.Value == 0)
            {
                remainingAmountNumBox.Value = totalAmountNumBox.Value;
            }

            var arrivalDateParam = new SqlParameter("@ArrivalDate", dateTimePicker.Value);
            var arrivalTotalParam = new SqlParameter("@TotalAmount", totalAmountNumBox.Value);
            var arrivalRemainingParam = new SqlParameter("@RemainingAmount", remainingAmountNumBox.Value);

            try
            {
                await _viTestDbContext.Database.ExecuteSqlRawAsync("EXEC AddArrival @ArrivalDate, @TotalAmount, @RemainingAmount",
                arrivalDateParam, arrivalTotalParam, arrivalRemainingParam);
            }
            catch (SqlException dbEx)
            {
                var errorMessage = "Ошибка при обновлении данных: ";
                foreach (SqlError error in dbEx.Errors)
                {
                    errorMessage += $"{error.Message}\n";
                }
                MessageBox.Show(errorMessage, "Ошибка");
            }
            finally
            {
                Close();
            }
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
