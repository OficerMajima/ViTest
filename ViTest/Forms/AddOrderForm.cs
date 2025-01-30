using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ViTest.Domain;

namespace ViTest.Forms
{
    public partial class AddOrderForm : Form
    {
        private ViTestDbContext _viTestDbContext;
        public AddOrderForm(ViTestDbContext context)
        {
            InitializeComponent();
            _viTestDbContext = context;
            totalAmountNumBox.Maximum = 1_000_000;
            amountPaidNumBox.Maximum = totalAmountNumBox.Maximum;
        }

        private async void confirmButton_Click(object sender, EventArgs e)
        {
            if (totalAmountNumBox.Value < amountPaidNumBox.Value)
            {
                MessageBox.Show("Выплаченная сумма не может превышать общую сумму заказа.", "Ошибка");
                return;
            }

            var orderDateParam = new SqlParameter("@OrderDate", dateTimePicker1.Value);
            var arrivalParam = new SqlParameter("@TotalAmount", totalAmountNumBox.Value);
            var payParam = new SqlParameter("@AmountPaid", amountPaidNumBox.Value);

            try
            {
                await _viTestDbContext.Database.ExecuteSqlRawAsync("EXEC AddOrder @OrderDate, @TotalAmount, @AmountPaid",
                orderDateParam, arrivalParam, payParam);
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
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
