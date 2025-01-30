using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ViTest.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ViTest.Forms
{
    public partial class PayForm : Form
    {
        private ViTestDbContext _viTestDbContext;
        private Order _order;
        private MoneyArrival _moneyArrival;
        public PayForm(Order order, MoneyArrival moneyArrival, ViTestDbContext context)
        {
            InitializeComponent();
            _viTestDbContext = context;
            _order = order;
            _moneyArrival = moneyArrival;
            arrivalOrderLabel.Text = $"Баланс в Вашем приходе №{moneyArrival.ArrivalId}: \r\nсодержит: {moneyArrival.RemainingAmount}." +
                $"\r\nДля полной оплаты заказа №{order.OrderId}\r\nтребуется сумма: {order.TotalAmount - order.AmountPaid}.";
            payNumBox.Maximum = Math.Min(_order.TotalAmount - _order.AmountPaid, _moneyArrival.RemainingAmount);
        }

        private async void payButton_Click(object sender, EventArgs e)
        {
            var orderCheck = await _viTestDbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == _order.OrderId);
            var moneyArrivalCheck = await _viTestDbContext.MoneyArrivals.FirstOrDefaultAsync(m => m.ArrivalId == _moneyArrival.ArrivalId);

            if (orderCheck == null || moneyArrivalCheck == null)
            {
                MessageBox.Show("Заказ или приход денег не найдены в базе данных, обновление списков", "Данные устарели");
                Close();
                return;
            }
            if (orderCheck.AmountPaid != _order.AmountPaid || orderCheck.OrderDate != _order.OrderDate)
            {
                MessageBox.Show("Ваши данные о заказе устарели, обновление списков", "Данные устарели");
                Close();
                return;
            }
            if (moneyArrivalCheck.RemainingAmount != _moneyArrival.RemainingAmount || moneyArrivalCheck.ArrivalDate != _moneyArrival.ArrivalDate)
            {
                MessageBox.Show("Ваши данные о приходе денег устарели, обновление списков", "Данные устарели");
                Close();
                return;
            }

            var orderParam = new SqlParameter("@OrderId", _order.OrderId);
            var arrivalParam = new SqlParameter("@ArrivalId", _moneyArrival.ArrivalId);
            var payParam = new SqlParameter("@PaymentAmount", payNumBox.Value);

            try
            {
                await _viTestDbContext.Database.ExecuteSqlRawAsync("EXEC AddPayment @OrderId, @ArrivalId, @PaymentAmount",
                orderParam, arrivalParam, payParam);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
