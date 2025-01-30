using Microsoft.EntityFrameworkCore;
using System.Configuration;
using ViTest.Forms;
using ViTest.Domain;
using Microsoft.Data.SqlClient;

namespace ViTest
{
    public partial class MainForm : Form
    {
        private ViTestDbContext _viTestDbContext;

        private List<MoneyArrival> _arrivalList;
        private List<Order> _orderList;
        private List<Payment> _paymentList;
        private Order _currentOrder;
        private MoneyArrival _currentArrival;


        public MainForm()
        {
            InitializeComponent();
            InitializeDbContext();
            CheckDbConnection();
        }

        private void InitializeDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ViTestDbContext>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);

            _viTestDbContext = new ViTestDbContext(optionsBuilder.Options);
        }

        private bool CheckDbConnection()
        {
            try
            {
                using (var connection = new SqlConnection(_viTestDbContext.Database.GetDbConnection().ConnectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных:\n" + ex.Message, "Ошибка");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:\n" + ex.Message, "Ошибка");
                return false;
            }
        }

        private void LoadOrderPage()
        {
            InitializeDbContext();
            _orderList = _viTestDbContext.Orders.ToList();
            mainDataGridView.DataSource = _orderList;

            mainDataGridView.Columns["OrderId"].HeaderText = "Номер";
            mainDataGridView.Columns["OrderDate"].HeaderText = "Дата";
            mainDataGridView.Columns["TotalAmount"].HeaderText = "Сумма";
            mainDataGridView.Columns["AmountPaid"].HeaderText = "Выплачено";

            orderLabel.Text = "Здесь вы можете выбрать заказ\r\nдля оплаты из Вашегоприхода денег:\r\n";
            confirmOrderButton.Enabled = true;
            confirmOrderButton.Visible = true;
            confirmArrivalButton.Enabled = false;
            confirmArrivalButton.Visible = false;
        }

        private void LoadArrivalPage()
        {
            InitializeDbContext();
            _arrivalList = _viTestDbContext.MoneyArrivals.ToList();
            mainDataGridView.DataSource = _arrivalList;

            mainDataGridView.Columns["ArrivalId"].HeaderText = "Номер";
            mainDataGridView.Columns["ArrivalDate"].HeaderText = "Дата";
            mainDataGridView.Columns["TotalAmount"].HeaderText = "Сумма";
            mainDataGridView.Columns["RemainingAmount"].HeaderText = "Остаток";

            orderLabel.Text = "Здесь вы можете просмотреть Ваши\r\nприходы денег:\r\n";
            confirmOrderButton.Enabled = false;
            confirmOrderButton.Visible = false;
            if (_currentOrder != null)
            {
                confirmArrivalButton.Enabled = true;
                confirmArrivalButton.Visible = true;
            }

        }

        private void LoadPaymentsPage()
        {
            InitializeDbContext();
            _paymentList = _viTestDbContext.Payments.ToList();
            mainDataGridView.DataSource = _paymentList;

            mainDataGridView.Columns["PaymentId"].HeaderText = "Номер";
            mainDataGridView.Columns["PaymentId"].DisplayIndex = 0;
            mainDataGridView.Columns["OrderId"].HeaderText = "Номер заказа";
            mainDataGridView.Columns["ArrivalId"].HeaderText = "Номер прихода";
            mainDataGridView.Columns["PaymentAmount"].HeaderText = "Сумма";

            orderLabel.Text = "Здесь вы можете просмотреть Ваши\r\nплатежи:\r\n";
            confirmOrderButton.Enabled = false;
            confirmOrderButton.Visible = false;
            confirmArrivalButton.Enabled = false;
            confirmArrivalButton.Visible = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            if (!CheckDbConnection()) { return; }
            LoadOrderPage();
        }

        private void arrivalButton_Click(object sender, EventArgs e)
        {
            if (!CheckDbConnection()) { return; }
            LoadArrivalPage();
        }

        private void paymentsButton_Click(object sender, EventArgs e)
        {
            if (!CheckDbConnection()) { return; }
            LoadPaymentsPage();
        }

        private void confirmOrderButton_Click(object sender, EventArgs e)
        {
            if (mainDataGridView.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Выберите заказ", "Заказ не выбран");
                return;
            }

            var selectedOrderId = int.Parse(mainDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            _currentOrder = _orderList.First(o => o.OrderId == selectedOrderId);

            if (_currentOrder.AmountPaid >= _currentOrder.TotalAmount)
            {
                MessageBox.Show("Заказ уже оплачен полностью", "Заказ оплачен");
                return;
            }

            MessageBox.Show($"Заказ номер №{_currentOrder.OrderId} успешно выбран!\r\nТеперь выберите приход.", "Успех");
            LoadArrivalPage();
        }

        private void confirmArrivalButton_Click(object sender, EventArgs e)
        {
            if (mainDataGridView.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Выберите приход", "Приход не выбран");
                return;
            }

            var selectedMoneyArrivalId = int.Parse(mainDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            _currentArrival = _arrivalList.First(m => m.ArrivalId == selectedMoneyArrivalId);

            if (_currentArrival.RemainingAmount <= 0)
            {
                MessageBox.Show("В данном приходе денег нет остатка", "Приход денег пуст");
                return;
            }

            PayForm payForm = new PayForm(_currentOrder, _currentArrival, _viTestDbContext);
            payForm.ShowDialog();
            LoadOrderPage();
        }

        private void addOrderButton_Click(object sender, EventArgs e)
        {
            if (!CheckDbConnection()) { return; }

            AddOrderForm orderForm = new AddOrderForm(_viTestDbContext);
            orderForm.ShowDialog();
            LoadOrderPage();
        }

        private void addArrivalButton_Click(object sender, EventArgs e)
        {
            if (!CheckDbConnection()) { return; }

            AddArrivalForm arrivalForm = new AddArrivalForm(_viTestDbContext);
            arrivalForm.ShowDialog();
            LoadArrivalPage();
        }
    }
}
