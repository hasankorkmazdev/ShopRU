using ShopRu.Common.Models.Abstraction;

namespace ShopRu.Common.Models
{
    public class Invoice : BaseModel<Guid>
    {
        public DateTime Date { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; } = new();
        public User? User { get; set; }
        public List<Discount> Discounts { get; set; } = new();

    }
}
