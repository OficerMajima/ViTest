using System.ComponentModel.DataAnnotations;

namespace ViTest.Domain
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public int ArrivalId { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
