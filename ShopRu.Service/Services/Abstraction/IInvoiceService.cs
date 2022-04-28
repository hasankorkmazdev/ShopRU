using ShopRu.Common.Models;

namespace ShopRu.Service.Services.Abstraction
{
    public interface IInvoiceService
    {
        public decimal ApplyDiscountOnInvoice(Invoice invoice);
    }
}
