using Microsoft.EntityFrameworkCore;
using ViTest.Domain;

namespace ViTest.Forms
{
    public partial class PayForm : Form
    {
        private ViTestDbContext _context;
        private Order _order;
        private MoneyArrival _moneyArrival;
        public PayForm(Order order, MoneyArrival moneyArrival, ViTestDbContext context)
        {
            InitializeComponent();
            _context = context;
            _order = order;
            _moneyArrival = moneyArrival;
            arrivalOrderLabel.Text = $"Баланс в Вашем приходе №{moneyArrival.ArrivalId}: \r\nсодержит: {moneyArrival.RemainingAmount}." +
                $"\r\nДля полной оплаты заказа №{order.OrderId}\r\nтребуется сумма: {order.TotalAmount - order.AmountPaid}.";
            payNumBox.Maximum = Math.Min(_order.TotalAmount - _order.AmountPaid, _moneyArrival.RemainingAmount);
        }

        private async void payButton_Click(object sender, EventArgs e)
        {
            var orderCheck = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == _order.OrderId);
            var moneyArrivalCheck = await _context.MoneyArrivals.FirstOrDefaultAsync(m => m.ArrivalId == _moneyArrival.ArrivalId);

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

            Payment payment = new Payment();

            payment.OrderId = _order.OrderId;
            payment.ArrivalId = _moneyArrival.ArrivalId;
            payment.PaymentAmount = payNumBox.Value;

            await _context.Payments.AddAsync(payment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                MessageBox.Show("Ошибка при обновлении данных: " + dbEx.InnerException?.Message ?? dbEx.Message, "Ошибка");
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
