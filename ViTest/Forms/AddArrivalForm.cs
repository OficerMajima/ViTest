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
            if (totalAmountNumBox.Value <=  0)
            {
                MessageBox.Show("Приход не может быть равен 0 или быть отрицательным.", "Ошибка");
                return;
            }
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
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:\n" + ex.Message, "Ошибка");
                return;
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
